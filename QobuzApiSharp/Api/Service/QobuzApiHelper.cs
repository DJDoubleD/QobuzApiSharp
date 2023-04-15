using Newtonsoft.Json;
using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QobuzApiSharp.Service
{
    /// <summary>
    /// Qobuz api service helper class.
    /// </summary>
    internal static class QobuzApiHelper
    {
        private static string CachedBundleString;

        /// <summary>
        /// Fetches the bundle.js string from the Qobuz Web Player.
        /// </summary>
        private static void FetchBundleString()
        {
            using (WebClient QobuzWebClient = new WebClient())
            {
                string bundleHTML = QobuzWebClient.DownloadString($"{QobuzApiConstants.WEB_PLAYER_BASE_URL}/login");

                try
                {
                    // Grab link to bundle.js
                    string bundleSuffix = Regex.Match(bundleHTML, "<script src=\"(?<bundleJS>\\/resources\\/\\d+\\.\\d+\\.\\d+-[a-z]\\d{3}\\/bundle\\.js)").Groups[1].Value;
                    CachedBundleString = QobuzWebClient.DownloadString($"{QobuzApiConstants.WEB_PLAYER_BASE_URL}{bundleSuffix}");
                }
                catch (Exception ex)
                {
                    // If obtaining bundle.js info fails, throw error.
                    throw new ApiErrorResponseException("Failed to download bundje.js.", ex);
                }
            }
        }

        /// <summary>
        /// Gets the Qobuz Web Player app_id. Valid as of bundle-7.0.1-b018.js.
        /// </summary>
        /// <returns>Bundle.js as string</returns>
        internal static string GetWebPlayerAppId()
        {
            if (CachedBundleString == null)
            {
                FetchBundleString();
            }

            // Grab "app_id" from bundle.js
            // The bundle.js seems to contain app_id's for 4 environments: "integration", "nightly", "recette" and "production".
            // We want the "production" (live) environment, so this is the app_id we need:
            return Regex.Match(CachedBundleString, "production:{api:{appId:\"(?<appID>.*?)\",appSecret:").Groups[1].Value;
        }

        /// <summary>
        /// Gets theQobuz Web Player app_secret. Valid as of bundle-7.0.1-b018.js.
        /// </summary>
        /// <returns>A string.</returns>
        internal static string GetWebPlayerAppSecret()
        {
            if (CachedBundleString == null)
            {
                FetchBundleString();
            }

            // Grab "seed"
            // The bundle.js contains a line like this:
            // ## return"recette"===e?d.initialSeed("MTBiMjUxYzI4NmNmYmY2NGQ2YjcxMD",window.utimezone.london):"integration"===e?d.initialSeed("MmFiNzEzMWQzODM2MjNjZjQwM2NmM2",window.utimezone.algier):d.initialSeed("OTc5NTQ5NDM3ZmNjNGEzZmFhZDQ4Nj",window.utimezone.berlin)
            // This line tells us the seed for the live "production" environment (not "recette" or "integration") and the corresponding timezone used (in this case "berlin").
            const string seedAndTimezonePattern = "\\):[a-z]\\.initialSeed\\(\"(?<seed>.*?)\",window\\.utimezone\\.(?<timezone>[a-z]+)\\)";
            Match seedAndTimezoneMatch = Regex.Match(CachedBundleString, seedAndTimezonePattern);
            string seed = seedAndTimezoneMatch.Groups[1].Value;
            string productionTimezone = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(seedAndTimezoneMatch.Groups[2].Value);

            // Grab "info" and "extras" from "timezones" array in bundle.js for the "production" timezone detected when grabbing the seed.
            string infoAndExtrasPattern = "timezones:\\[.*?name:\".*?\\/" + productionTimezone + "\\\",info:\\\"(?<info>.*?)\\\",extras:\\\"(?<extras>.*?)\\\"";
            Match infoAndExtrasMatch = Regex.Match(CachedBundleString, infoAndExtrasPattern);
            string info = infoAndExtrasMatch.Groups[1].Value;
            string extras = infoAndExtrasMatch.Groups[2].Value;

            // App Secret is Base64 encoded in concatenated seed, info & extras fields with last 44 characters of the resulting string removed.
            // So first concatenate previously recovered seed, info & extras fields into 1 string
            string Base64EncodedAppSecret = seed + info + extras;

            // Remove last 44 characters from resulting string
            Base64EncodedAppSecret = Base64EncodedAppSecret.Remove(Base64EncodedAppSecret.Length - 44, 44);

            // Perform Base64 decode on resulting string to obtain app secret bytes
            byte[] decodedAppSecretBytes = Convert.FromBase64String(Base64EncodedAppSecret);

            // Get app_secret using using UTF-8 encoding from bytes
            return Encoding.UTF8.GetString(decodedAppSecretBytes);
        }

        /// <summary>
        /// Deserializes the response.
        /// </summary>
        /// <typeparam name="T">Expected result object type</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        internal static T DeserializeResponse<T>(HttpResponseMessage response)
        {
            string jsonResultString = "";

            try
            {
                jsonResultString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(jsonResultString);
            }
            catch (Exception ex)
            {
                throw new ApiResponseParseErrorException($"Failed to parse API response for type {typeof(T).Name}.", jsonResultString, ex);
            }
        }


        /// <summary>
        /// Generates the file url request signature.
        /// </summary>
        /// <param name="format_id">The format_id.</param>
        /// <param name="track_id">The track_id.</param>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="app_secret">The app_secret.</param>
        /// <returns>A string.</returns>
        internal static string GenerateFileUrlRequestSignature(string format_id, string track_id, string timestamp, string app_secret)
        {
            string dataToSign = String.Concat("trackgetFileUrlformat_id", format_id, "intentstreamtrack_id", track_id, timestamp, app_secret);

            using (var md5Hash = MD5.Create())
            {
                return MD5Utilities.GetMd5Hash(md5Hash, dataToSign);
            }
        }

        /// <summary>
        /// Create a query string with provided key/value parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A string.</returns>
        internal static string ToQueryString(IDictionary<string, string> parameters)
        {
            var array = parameters
                .Where(kv => !string.IsNullOrEmpty(kv.Value))
                .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value)}")
                .ToArray();

            return string.Join("&", array);
        }

    }
}