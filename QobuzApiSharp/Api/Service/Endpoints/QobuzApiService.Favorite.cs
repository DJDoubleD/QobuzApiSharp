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
        /// Gets the ids of the user favorites for the authenticated user or user with the specified user ID.
        /// </summary>
        /// <param name="userId">The User ID to fetch the favorites from. If omitted, returns favorites of the logged in user using user_auth_token (optional).</param>
        /// <param name="limit">The maximum number of extra results to return. Defaults to 5000, minimum 1, maximum 999999. (optional).</param>
        /// <param name="offset">The offset of the first extra result to return. Defaults to 0.  (optional).</param>
        /// <returns>The UserFavoriteIds the ids of the user favorites.</returns>
        /// <exception cref="ApiErrorResponseException">Thrown if an error occurs while retrieving the UserFavoritesIds.</exception>
        /// <exception cref="ApiResponseParseErrorException">Thrown when the API response could not be parsed.</exception>
        public UserFavoritesIds GetUserFavoriteIds(string userId, string type = null, int limit = 5000, int offset = 0)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "user_id ", userId },
                { "limit", limit.ToString() },
                { "offset", offset.ToString() }

            };

            return GetApiResponse<UserFavoritesIds>("/favorite/getUserFavoriteIds", parameters, true);
        }

        /// <summary>
        /// Removes the track from the favorites.
        /// </summary>
        /// <param name="favoriteTrackId">Id of the track to remove.</param>
        /// <returns>A response that identifies if the request had success or not.</returns>
        public QobuzApiStatusResponse RemoveUserFavorite(long favoriteTrackId)
        {
            return PostApiResponse<QobuzApiStatusResponse>("/favorite/delete", null, new Dictionary<string, string>() { { "track_ids", favoriteTrackId.ToString() } }, true);
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
        /// <returns>The UserFavorites of the authorised or selected user.</returns>
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