using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;

namespace QobuzApiSharp.Service
{
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Gets Playlist with the specified playlist ID.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist to get.</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <param name="extra">Extra information to include in the response (optional). <br/>
        /// Possible values are 'tracks', 'subscribers', 'getSimilarPlaylists', 'focus', 'focusAll' &amp; 'track_ids'. <br/>
        /// Values can be combined in comma separated list to request multiple extras</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 25, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>The Playlist with the specified playlist ID.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the playlist.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Playlist GetPlaylist(string playlistId, bool withAuth = false, string extra = null, int limit = 25, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "playlist_id", playlistId },
                { "extra" , extra },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<Playlist>("/playlist/get", parameters, withAuth);
        }

        /// <summary>
        /// Searches for playlists using the specified query.
        /// </summary>
        /// <param name="query">String to search for</param>
        /// <param name="limit">The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first result to return. Defaults to 0.  (optional).</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <returns>A SearchResult object containing the search results.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public SearchResult SearchPlaylists(string query, int limit = 50, int offset = 0, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"query", query},
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            };

            return GetApiResponse<SearchResult>("/playlist/search", parameters, withAuth);
        }
    }
}