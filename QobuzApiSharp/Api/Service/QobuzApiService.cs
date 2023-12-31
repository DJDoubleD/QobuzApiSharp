using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace QobuzApiSharp.Service
{
    /// <summary>
    /// The qobuz api service.
    /// </summary>
    public sealed partial class QobuzApiService : IDisposable
    {
        private readonly HttpClient QobuzHttpClient;

        /// <summary>
        /// Gets the app id.
        /// </summary>
        public string AppId { get; }
        /// <summary>
        /// Gets the app secret.
        /// </summary>
        public string AppSecret { get; }
        /// <summary>
        /// Gets or sets the user auth token.
        /// </summary>
        public string UserAuthToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QobuzApiService"/> class using dynamic retrieval of the app_id and app_secret from the Qobuz Web Player.
        /// </summary>
        public QobuzApiService() : this(null, null, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QobuzApiService"/> class with custom app_id and app_secret.
        /// </summary>
        /// <param name="appId">The app id.</param>
        /// <param name="appSecret">The app secret.</param>
        public QobuzApiService(string appId, string appSecret) : this(appId, appSecret, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QobuzApiService"/> class.<br/>
        /// </summary>
        /// <param name="appId">The app id.</param>
        /// <param name="appSecret">The app secret.</param>
        /// <param name="useWebPlayerAppIdAndSecret">If true, use web player app id and secret.</param>
        private QobuzApiService(string appId, string appSecret, bool useWebPlayerAppIdAndSecret)
        {
            if (!useWebPlayerAppIdAndSecret && (string.IsNullOrEmpty(appId) || string.IsNullOrEmpty(appSecret)))
            {
                throw new ArgumentException("App ID and App Secret must be provided if not using Web Payer values.");
            }

            QobuzHttpClient = new HttpClient();
            QobuzHttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/110.0");

            if (useWebPlayerAppIdAndSecret)
            {
                this.AppSecret = QobuzApiHelper.GetWebPlayerAppSecret();

                if (string.IsNullOrEmpty(this.AppSecret))
                {
                    throw new QobuzApiInitializationException("Failed to find Web Player App Secret in bundje.js.");
                }

                this.AppId = QobuzApiHelper.GetWebPlayerAppId();

                if (string.IsNullOrEmpty(this.AppId))
                {
                    throw new QobuzApiInitializationException("Failed to find Web Player app_id in bundje.js.");
                }

                QobuzHttpClient.DefaultRequestHeaders.Add("X-App-Id", this.AppId);
            }
            else
            {
                this.AppId = appId;
                QobuzHttpClient.DefaultRequestHeaders.Add("X-App-Id", this.AppId);
                this.AppSecret = appSecret;
            }
        }

        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by the System.Net.Http.HttpMessageInvoker.
        /// </summary>
        public void Dispose()
        {
            QobuzHttpClient?.Dispose();
        }

        /// <summary>
        /// Send an HTTP request as an asynchronous operation to the Qobuz REST API.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="withAuthToken">If true, with user_auth_token in request header.</param>
        /// <param name="body">Plain text body if needed.</param>
        /// <returns>A Task.</returns>
        private async Task<HttpResponseMessage> SendAsync(HttpMethod method, string endpoint, IDictionary<string, string> parameters = null, bool withAuthToken = false, string body = null)
        {
            UriBuilder uriBuilder = new UriBuilder(QobuzApiConstants.API_BASE_URL + endpoint);
            if (parameters != null)
            {
                uriBuilder.Query = QobuzApiHelper.ToQueryString(parameters);
            }

            using (HttpRequestMessage request = new HttpRequestMessage(method, uriBuilder.Uri))
            {
                if (withAuthToken)
                {
                    request.Headers.Add("X-User-Auth-Token", UserAuthToken);
                }

                if (!string.IsNullOrEmpty(body))
                {
                    request.Content = new StringContent(body, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                }

                return await QobuzHttpClient.SendAsync(request).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends a request to the Qobuz REST API and if successful, tries to parse the api response.
        /// </summary>
        /// <param name="apiEndpoint">The api endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="requiresAuth">If true, requires auth.</param>
        /// <returns>Requested Model object containing parsed API response</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        private T GetApiResponse<T>(string apiEndpoint, Dictionary<string, string> parameters, bool requiresAuth = false)
        {
            return SendRestMessageAndDeserializeResponse<T>(apiEndpoint, HttpMethod.Post, null, parameters, requiresAuth);
        }

        /// <summary>
        /// Sends a request to the Qobuz REST API and if successful, tries to parse the api response.
        /// </summary>
        /// <param name="apiEndpoint">The api endpoint.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="bodyParameters">The parameters.</param>
        /// <param name="requiresAuth">If true, requires auth.</param>
        /// <returns>Requested Model object containing parsed API response</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        private T PostApiResponse<T>(string apiEndpoint, Dictionary<string, string> parameters, Dictionary<string, string> bodyParameters, bool requiresAuth = false)
        {
            return SendRestMessageAndDeserializeResponse<T>(apiEndpoint, HttpMethod.Post, QobuzApiHelper.ToQueryString(bodyParameters), parameters, requiresAuth);
        }

        /// <summary>
        /// Sends a request to the Qobuz REST API and if successful, tries to parse the api response.
        /// </summary>
        /// <param name="apiEndpoint">The api endpoint.</param>
        /// <param name="method">The method of the request.</param>
        /// <param name="body">Body of the request</param>
        /// <param name="parameters">Query parameters of the request.</param>
        /// <param name="requiresAuth">If true, requires auth.</param>
        /// <returns>Requested Model object containing parsed API response</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        private T SendRestMessageAndDeserializeResponse<T>(string apiEndpoint, HttpMethod method, string body, Dictionary<string, string> parameters, bool requiresAuth)
        {
            HttpResponseMessage response = this.SendAsync(method, apiEndpoint, parameters, requiresAuth, body).Result;

            if (!response.IsSuccessStatusCode)
            {
                QobuzApiStatusResponse errorResponse = QobuzApiHelper.DeserializeResponse<QobuzApiStatusResponse>(response);
                throw new ApiErrorResponseException($"API request failed for endpoint {apiEndpoint}.", response.RequestMessage.ToString(), errorResponse);
            }

            return QobuzApiHelper.DeserializeResponse<T>(response);
        }

        /// <summary>
        /// Check if the App Secret is valid by trying to fetch the streaming URL for the track with id 7398.
        /// User must be logged in before testing App Secret.
        /// </summary>
        /// <returns>bool indicating if the API returned a valid response</returns>
        public bool IsAppSecretValid()
        {
            string thrillerUrl = null;

            try
            {
                FileUrl thrillerFileUrl = GetTrackFileUrl("7398", "27");
                thrillerUrl = thrillerFileUrl.Url;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("AppSecret test with Thriller Hi-Res track failed with exception:");
                Trace.WriteLine(ex);
            }

            return !string.IsNullOrEmpty(thrillerUrl);
        }
    }
}