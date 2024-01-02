using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Service
{
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Search the Qobuz catalog in it's entirety or for the requested content type
        /// </summary>
        /// <param name="query">String to search for</param>
        /// <param name="limit">The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first result to return. Defaults to 0.  (optional).</param>
        /// <param name="type">Limit results to given type, accepted values are 'tracks', 'albums', 'artists', 'articles', 'playlists', 'focus' &amp; 'stories'. (optional)</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).<br/>
        /// Only when seach is executed with authentication is the `most_popular` content included in the result (optional)</param>
        /// <returns>A SearchResult object containing the search results.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public SearchResult SearchCatalog(string query, int limit = 50, int offset = 0, string type = null, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"query", query},
                {"type", type},
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            };

            return GetApiResponse<SearchResult>("/catalog/search", parameters, withAuth);
        }
    }
}