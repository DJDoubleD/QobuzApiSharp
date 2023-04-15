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
        /// Gets the artist with the specified artist ID.
        /// </summary>
        /// <param name="artistId">The ID of the artist to get.</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <param name="extra">Extra information to include in the response (optional). <br/>
        /// Possible values are 'albums', 'playlists' &amp; 'albums_with_last_release'. <br/>
        /// Values can be combined in comma separated list to request multiple extras</param>
        /// <param name="sort">Sort requested extra information (optional). <br/>
        /// Possible values are 'release_desc' &amp; 'official'.</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>The artist with the specified artist ID.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the artist.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Artist GetArtist(string artistId, bool withAuth = false, string extra = null, string sort = null, int limit = 50, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "artist_id", artistId },
                { "extra" , extra },
                { "sort", sort },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<Artist>("/artist/get", parameters, withAuth);
        }

        /// <summary>
        /// Searches for artists using the specified query.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="limit">The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first result to return. Defaults to 0.  (optional).</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <returns>A SearchResult object containing the search results.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public SearchResult SearchArtists(string query, int limit = 50, int offset = 0, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"query", query},
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            };

            return GetApiResponse<SearchResult>("/artist/search", parameters, withAuth);
        }
    }
}