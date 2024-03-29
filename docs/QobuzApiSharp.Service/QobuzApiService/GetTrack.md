# QobuzApiService.GetTrack method

Gets the track with the specified track ID.

```csharp
public Track GetTrack(string trackId, bool withAuth = false)
```

| parameter | description |
| --- | --- |
| trackId | The ID of the track to get. |
| withAuth | Execute search with or without user_auth_token. Defaults to false (optional). |

## Return Value

The track with the specified artist ID.

## Exceptions

| exception | condition |
| --- | --- |
| [ApiErrorResponseException](../../QobuzApiSharp.Exceptions/ApiErrorResponseException.md) | Thrown if an error occurs while retrieving the track. |
| [ApiResponseParseErrorException](../../QobuzApiSharp.Exceptions/ApiResponseParseErrorException.md) | Thrown when the API response could not be parsed. |

## See Also

* class [Track](../../QobuzApiSharp.Models.Content/Track.md)
* class [QobuzApiService](../QobuzApiService.md)
* namespace [QobuzApiSharp.Service](../../QobuzApiSharp.md)

<!-- DO NOT EDIT: generated by xmldocmd for QobuzApiSharp.dll -->
