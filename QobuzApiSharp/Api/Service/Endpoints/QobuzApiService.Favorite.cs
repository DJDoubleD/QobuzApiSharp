using QobuzApiSharp.Exceptions;
using QobuzApiSharp.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using QobuzApiSharp.Models;

namespace QobuzApiSharp.Service
{
    public sealed partial class QobuzApiService : IDisposable
    {
        /// <summary>
        /// Add tracks, albums &amp; artists to the authenticated user's favorites.
        /// At least 1 type of favorite to add is required as parameter.
        /// </summary>
        /// <param name="trackIds">Ids of the tracks to add, comma separated list. (optional)</param>
        /// <param name="albumIds">Ids of the albums to add, comma separated list. (optional)</param>
        /// <param name="artistIds">Ids of the artists to add, comma separated list. (optional)</param>
        /// <returns>A <see cref="QobuzApiStatusResponse"/> that identifies if the request was successful (<see cref="QobuzApiStatusResponse.Status"/> = "success") or not.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while adding the user favorites.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public QobuzApiStatusResponse AddUserFavorites(string trackIds, string albumIds, string artistIds)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "track_ids", trackIds },
                { "artist_ids", artistIds },
                { "album_ids", albumIds }
            };
            return GetApiResponse<QobuzApiStatusResponse>("/favorite/create", parameters, true);
        }

        /// <summary>
        /// Add tracks, albums &amp; artists to the authenticated user's favorites.
        /// At least 1 type of favorite to add is required as parameter.
        /// </summary>
        /// <param name="trackIds">Ids of the tracks to add. (optional)</param>
        /// <param name="albumIds">Ids of the albums to add. (optional)</param>
        /// <param name="artistIds">Ids of the artists to add. (optional)</param>
        /// <returns>A <see cref="QobuzApiStatusResponse"/> that identifies if the request was successful (<see cref="QobuzApiStatusResponse.Status"/> = "success") or not.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while adding the user favorites.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public QobuzApiStatusResponse AddUserFavorites(IEnumerable<string> trackIds, IEnumerable<string> albumIds, IEnumerable<string> artistIds)
        {
            return AddUserFavorites(string.Join(",", trackIds??Enumerable.Empty<string>()), string.Join(",", albumIds??Enumerable.Empty<string>()), string.Join(",", artistIds??Enumerable.Empty<string>()));
        }

        /// <summary>
        /// Removes tracks, albums &amp; artists from the authenticated user's favorites.
        /// At least 1 type of favorite to remove is required as parameter.
        /// </summary>
        /// <param name="trackIds">Ids of the tracks to remove, comma separated list. (optional)</param>
        /// <param name="albumIds">Ids of the albums to remove, comma separated list. (optional)</param>
        /// <param name="artistIds">Ids of the artists to remove, comma separated list. (optional)</param>
        /// <returns>A <see cref="QobuzApiStatusResponse"/> that identifies if the request was successful (<see cref="QobuzApiStatusResponse.Status"/> = "success") or not.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while removing the user favorites.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public QobuzApiStatusResponse DeleteUserFavorites(string trackIds, string albumIds, string artistIds)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "track_ids", trackIds },
                { "artist_ids", artistIds },
                { "album_ids", albumIds }
            };
           return GetApiResponse<QobuzApiStatusResponse>("/favorite/delete", parameters, true);
        }

        /// <summary>
        /// Removes the track from the favorites.
        /// </summary>
        /// <param name="trackIds">Ids of the tracks to remove.</param>
        /// <param name="albumIds">Ids of the albums to remove.</param>
        /// <param name="artistIds">Ids of the artists to remove.</param>
        /// <returns>A <see cref="QobuzApiStatusResponse"/> that identifies if the request was successful (<see cref="QobuzApiStatusResponse.Status"/> = "success") or not.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while removing the user favorites.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public QobuzApiStatusResponse DeleteUserFavorites(IEnumerable<string> trackIds, IEnumerable<string> albumIds, IEnumerable<string> artistIds)
        {
            return DeleteUserFavorites(string.Join(",", trackIds??Enumerable.Empty<string>()), string.Join(",", albumIds??Enumerable.Empty<string>()), string.Join(",", artistIds??Enumerable.Empty<string>()));
        }

        /// <summary>
        /// Gets the ids of the user favorites for the authenticated user or user with the specified user ID.
        /// </summary>
        /// <param name="userId">The User ID to fetch the favorites from. If omitted, returns favorites of the logged in user using user_auth_token (optional).</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 5000, minimum 1, maximum 999999. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0. (optional).</param>
        /// <returns>The <see cref="UserFavoritesIds"/> containing the ids of the user favorites.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the UserFavoritesIds.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public UserFavoritesIds GetUserFavoriteIds(string userId, int limit = 5000, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "user_id ", userId },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<UserFavoritesIds>("/favorite/getUserFavoriteIds", parameters, true);
        }

        /// <summary>
        /// Gets user favorites of the authenticated user or user with the specified user ID.
        /// </summary>
        /// <param name="userId">The User ID to fetch the favorites from. If omitted, returns favorites of the logged in user using user_auth_token (optional).</param>
        /// <param name="type">Type of favorites to include in the response (optional). <br/>
        /// Possible values are 'tracks', 'albums', 'artists' &amp; articles'. <br/>
        /// If no type defined, all types are returned.</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 50, minimum 1, maximum 500. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>The <see cref="UserFavorites"/> of the authorised or selected user.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the UserFavorites.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public UserFavorites GetUserFavorites(string userId, string type = null, int limit = 50, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "user_id ", userId },
                { "type " , type },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<UserFavorites>("/favorite/getUserFavorites", parameters, true);
        }
    }
}