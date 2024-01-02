# QobuzApiService.SearchCatalog method

Search the Qobuz catalog in it's entirety or for the requested content type

```csharp
public SearchResult SearchCatalog(string query, int limit = 50, int offset = 0, string type = null, 
    bool withAuth = false)
```

| parameter | description |
| --- | --- |
| query | String to search for |
| limit | The maximum number of results to return. Defaults to 50, minimum 1, maximum 500. (optional). |
| offset | The offset of the first result to return. Defaults to 0. (optional). |
| type | Limit results to given type, accepted values are 'tracks', 'albums', 'artists', 'articles', 'playlists', 'focus' &amp; 'stories'. (optional) |
| withAuth | Execute search with or without user_auth_token. Defaults to false (optional). Only when seach is executed with authentication is the `most_popular` content included in the result (optional) |

## Return Value

A SearchResult object containing the search results.

## Exceptions

| exception | condition |
| --- | --- |
| [ApiErrorResponseException](../../QobuzApiSharp.Exceptions/ApiErrorResponseException.md) | Thrown when the API request returns an error. |
| [ApiResponseParseErrorException](../../QobuzApiSharp.Exceptions/ApiResponseParseErrorException.md) | Thrown when the API response could not be parsed. |

## See Also

* class [SearchResult](../../QobuzApiSharp.Models.Content/SearchResult.md)
* class [QobuzApiService](../QobuzApiService.md)
* namespace [QobuzApiSharp.Service](../../QobuzApiSharp.md)

<!-- DO NOT EDIT: generated by xmldocmd for QobuzApiSharp.dll -->