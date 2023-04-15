using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Service
{
    /// <summary>
    /// The qobuz api service.
    /// </summary>
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Gets Label with the specified label ID.
        /// </summary>
        /// <param name="labelId">The ID of the label to get.</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <param name="extra">Extra information to include in the response (optional). <br/>
        /// Possible values are 'albums', 'focus' &amp; 'focusAll'. <br/>
        /// Values can be combined in comma separated list to request multiple extras</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 25, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>The Label with the specified label ID.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the label.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Label GetLabel(string labelId, bool withAuth = false, string extra = null, int limit = 25, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "label_id", labelId },
                { "extra" , extra },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<Label>("/label/get", parameters, withAuth);
        }
    }
}