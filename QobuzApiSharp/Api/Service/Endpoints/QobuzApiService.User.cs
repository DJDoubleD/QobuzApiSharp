using Newtonsoft.Json;
using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models;
using QobuzApiSharp.Models.User;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace QobuzApiSharp.Service
{
    /// <summary>
    /// The qobuz api service.
    /// </summary>
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Login to Qobuz API with email and MD5 hashed password.<br/>
        /// On successful login, saves the user_auth_token in service for API requests.<br/>
        /// Login is required to use API methods which require authentication.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">MD5 hashed user password</param>
        /// <returns>An instance of the Login class containing the logged in User instance and user_auth_token.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Login LoginWithEmail(string email, string password)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "email", email },
                { "password", password }
            };
            HttpResponseMessage response = this.SendAsync(HttpMethod.Get, "/user/login", parameters).Result;

            if (!response.IsSuccessStatusCode)
            {
                QobuzApiStatusResponse errorResponse = QobuzApiHelper.DeserializeResponse<QobuzApiStatusResponse>(response);
                throw new ApiErrorResponseException($"Failed to login user with email {email} and password {password}.", response.RequestMessage.ToString(), errorResponse);
            }

            try
            {
                Login login = JsonConvert.DeserializeObject<Login>(response.Content.ReadAsStringAsync().Result);
                this.UserAuthToken = login.AuthToken;
                return login;
            }
            catch (Exception ex)
            {
                throw new ApiResponseParseErrorException("Failed to parse API response.", ex);
            }
        }

        /// <summary>
        /// Login to Qobuz API with username and MD5 hashed password.<br/>
        /// On successful login, saves the user_auth_token in service for API requests.<br/>
        /// Login is required to use API methods which require authentication.
        /// </summary>
        /// <param name="username">User username</param>
        /// <param name="password">MD5 hashed user password</param>
        /// <returns>An instance of the Login class containing the logged in User instance and user_auth_token.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Login LoginWithUsername(string username, string password)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "username", username },
                { "password", password }
            };
            HttpResponseMessage response = this.SendAsync(HttpMethod.Get, "/user/login", parameters).Result;

            if (!response.IsSuccessStatusCode)
            {
                QobuzApiStatusResponse errorResponse = QobuzApiHelper.DeserializeResponse<QobuzApiStatusResponse>(response);
                throw new ApiErrorResponseException($"Failed to login user with username {username} and password {password}.", response.RequestMessage.ToString(), errorResponse);
            }

            try
            {
                Login login = JsonConvert.DeserializeObject<Login>(response.Content.ReadAsStringAsync().Result);
                this.UserAuthToken = login.AuthToken;
                return login;
            }
            catch (Exception ex)
            {
                throw new ApiResponseParseErrorException("Failed to parse API response.", ex);
            }
        }

        /// <summary>
        /// Login to Qobuz API with user ID and user_auth_token.<br/>
        /// On successful login, saves the user_auth_token in service for API requests.<br/>
        /// Login is required to use API methods which require authentication.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="userAuthToken">User authentication token</param>
        /// <returns>An instance of the Login class containing the logged in User instance and user_auth_token.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Login LoginWithToken(string userId, string userAuthToken)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "user_id", userId },
                { "user_auth_token", userAuthToken }
            };
            HttpResponseMessage response = this.SendAsync(HttpMethod.Get, "/user/login", parameters).Result;

            if (!response.IsSuccessStatusCode)
            {
                QobuzApiStatusResponse errorResponse = QobuzApiHelper.DeserializeResponse<QobuzApiStatusResponse>(response);
                throw new ApiErrorResponseException($"Failed to login user with ID {userId} and Token {userAuthToken}.", response.RequestMessage.ToString(), errorResponse);
            }

            try
            {
                Login login = JsonConvert.DeserializeObject<Login>(response.Content.ReadAsStringAsync().Result);
                this.UserAuthToken = login.AuthToken;
                return login;
            }
            catch (Exception ex)
            {
                throw new ApiResponseParseErrorException("Failed to parse API response.", ex);
            }
        }

        /// <summary>
        /// Requests password reset link for the user with given username address.
        /// </summary>
        /// <param name="email">The user's username.</param>
        /// <returns>A QobuzApiStatusResponse indicating if the request succeeded or failed.</returns>
        public QobuzApiStatusResponse ResetPasswordForEmail(string email)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"username ", email }
            };

            return GetApiResponse<QobuzApiStatusResponse>("/user/resetPassword", parameters, false);
        }

        /// <summary>
        /// Requests password reset link for the user with given username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A QobuzApiStatusResponse indicating if the request succeeded or failed.</returns>
        public QobuzApiStatusResponse ResetPassword(string username)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"username ", username }
            };

            return GetApiResponse<QobuzApiStatusResponse>("/user/resetPassword", parameters, false);
        }
    }
}