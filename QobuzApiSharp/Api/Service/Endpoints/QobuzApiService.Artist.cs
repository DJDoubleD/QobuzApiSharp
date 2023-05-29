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
        /// Return the list of releases for the artist with the specified artist ID.
        /// </summary>
        /// <param name="artistId">The artist ID of which to fetch the list of releases</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <param name="release_type">Release types to include in result, all by default (optional). <br/>
        /// Possible values are 'all', 'album', 'live', 'compilation', 'epSingle', 'other' &amp; 'download'. <br/>
        /// Values can be combined in comma separated list to request multiple extras</param>
        /// <param name="sort">Sort releases by selected value, default is by release date (optional). <br/>
        /// Possible values are 'release_date', 'relevant' &amp; 'release_date_by_priority'</param>
        /// <param name="order">Sort releases in requested order. Default is descending (optional). <br/>
        /// Possible values are 'desc' &amp; 'asc'.</param>
        /// <param name="track_size">Maximum number of tracks to return in each release (optional). <br/>
        /// Defaults to 10, minimum 1, maximum 30.</param>
        /// <param name="limit">The maximum number of releases to return. Defaults to 50, minimum 1, maximum 100. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>A <see cref="ReleasesList"/> object, containing the releases corresponding to the request parameters</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the releaselist.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public ReleasesList GetReleaseList(string artistId, bool withAuth = false, string release_type = null, string sort = null,
            string order = null, int track_size = 10,  int limit = 50, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "artist_id", artistId },
                { "release_type " , release_type  },
                { "sort", sort },
                { "order " , order  },
                { "track_size " , track_size.ToString()  },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<ReleasesList>("/artist/getReleasesList", parameters, withAuth);
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