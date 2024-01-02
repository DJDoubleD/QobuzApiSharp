using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Service
{

    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Retrieves an album with the specified ID.
        /// </summary>
        /// <param name="albumId">The ID of the album to retrieve.</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <param name="extra">Additional album information to include in the response (optional).<br/>
        /// Accepted values are 'albumsFromSameArtist', 'focus', 'focusAll' &amp; "track_ids"</param>
        /// <param name="limit">The maximum number of tracks to include in the response (optional. default: 1200, min: 1, max: 1200).</param>
        /// <param name="offset">The offset of the first track to include in the response (optional. default: 0).</param>
        /// <returns>An instance of the Album class representing the retrieved album.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Album GetAlbum(string albumId, bool withAuth = false, string extra = null, int limit = 1200, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "album_id", albumId },
                { "extra", extra },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }
            };

            return GetApiResponse<Album>("/album/get", parameters, withAuth);
        }

        /// <summary>
        /// Searches for albums using the specified query.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="limit">The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first result to return. Defaults to 0.  (optional).</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <returns>A SearchResult object containing the search results.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public SearchResult SearchAlbums(string query, int limit = 50, int offset = 0, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"query", query},
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            };

            return GetApiResponse<SearchResult>("/album/search", parameters, withAuth);
        }
    }
}