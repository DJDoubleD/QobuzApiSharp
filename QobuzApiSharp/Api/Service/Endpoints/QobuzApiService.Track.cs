using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;
using QobuzApiSharp.Models;

namespace QobuzApiSharp.Service
{
    /// <summary>
    /// The qobuz api service.
    /// </summary>
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Gets the track with the specified track ID.
        /// </summary>
        /// <param name="trackId">The ID of the track to get.</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <returns>The track with the specified artist ID.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the track.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public Track GetTrack(string trackId, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> { { "track_id", trackId } };

            return GetApiResponse<Track>("/track/get", parameters, withAuth);
        }

        /// <summary>
        /// Returns the file URL of the track with the specified track ID and format ID.
        /// </summary>
        /// <param name="trackId">The ID of the track.</param>
        /// <param name="formatId">The ID of the format.
        /// <list type="bullet">
        /// <item><description>5 for MP3 320</description></item>
        /// <item><description>6 for FLAC Lossless</description></item>
        /// <item><description>7 for FLAC Hi-Res 24 bit =&lt; 96kHz</description></item>
        /// <item><description>27 for FLAC Hi-Res 24 bit &gt;96 kHz &amp; =&lt; 192 kHz</description></item>
        /// </list>
        /// </param>
        /// <returns>The file URL of the track in the specified format.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the file URL.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public FileUrl GetTrackFileUrl(string trackId, string formatId)
        {
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string signature = QobuzApiHelper.GenerateFileUrlRequestSignature(formatId, trackId, timestamp, AppSecret);

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "track_id", trackId },
                { "format_id", formatId },
                { "intent", "stream" },
                { "request_ts", timestamp },
                { "request_sig", signature }
            };

            return GetApiResponse<FileUrl>("/track/getFileUrl", parameters, true);
        }

        /// <summary>
        /// Searches for tracks using the specified query.
        /// </summary>
        /// <param name="query">String to search for</param>
        /// <param name="limit">The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first result to return. Defaults to 0.  (optional).</param>
        /// <param name="withAuth">Execute search with or without user_auth_token. Defaults to false (optional).</param>
        /// <returns>A SearchResult object containing the search results.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public SearchResult SearchTracks(string query, int limit = 50, int offset = 0, bool withAuth = false)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"query", query},
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            };

            return GetApiResponse<SearchResult>("/track/search", parameters, withAuth);
        }

        /// <summary>
        /// Add the track to the current user favorites.
        /// </summary>
        /// <param name="trackId">Id of the track to add.</param>
        /// <returns>A boolean that indicates whenever the action was succesful or not.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown when the API request returns an error.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public bool AddToFavourites(long trackId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "track_ids", trackId.ToString() }
            };
            var resp = GetApiResponse<QobuzApiStatusResponse>("/favorite/create", parameters, true);
            return resp.Status == "success";
        }
    }
}