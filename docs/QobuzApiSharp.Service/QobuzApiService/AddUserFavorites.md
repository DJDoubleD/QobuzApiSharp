# QobuzApiService.AddUserFavorites method (1 of 2)

Add tracks, albums &amp; artists to the authenticated user's favorites. At least 1 type of favorite to add is required as parameter.

```csharp
public QobuzApiStatusResponse AddUserFavorites(IEnumerable<string> trackIds, 
    IEnumerable<string> albumIds, IEnumerable<string> artistIds)
```

| parameter | description |
| --- | --- |
| trackIds | Ids of the tracks to add. (optional) |
| albumIds | Ids of the albums to add. (optional) |
| artistIds | Ids of the artists to add. (optional) |

## Return Value

A [`QobuzApiStatusResponse`](../../QobuzApiSharp.Models/QobuzApiStatusResponse.md) that identifies if the request was successful ([`Status`](../../QobuzApiSharp.Models/QobuzApiStatusResponse/Status.md) = "success") or not.

## Exceptions

| exception | condition |
| --- | --- |
| [ApiErrorResponseException](../../QobuzApiSharp.Exceptions/ApiErrorResponseException.md) | Thrown if an error occurs while adding the user favorites. |
| [ApiResponseParseErrorException](../../QobuzApiSharp.Exceptions/ApiResponseParseErrorException.md) | Thrown when the API response could not be parsed. |

## See Also

* class [QobuzApiStatusResponse](../../QobuzApiSharp.Models/QobuzApiStatusResponse.md)
* class [QobuzApiService](../QobuzApiService.md)
* namespace [QobuzApiSharp.Service](../../QobuzApiSharp.md)

---

# QobuzApiService.AddUserFavorites method (2 of 2)

Add tracks, albums &amp; artists to the authenticated user's favorites. At least 1 type of favorite to add is required as parameter.

```csharp
public QobuzApiStatusResponse AddUserFavorites(string trackIds, string albumIds, string artistIds)
```

| parameter | description |
| --- | --- |
| trackIds | Ids of the tracks to add, comma separated list. (optional) |
| albumIds | Ids of the albums to add, comma separated list. (optional) |
| artistIds | Ids of the artists to add, comma separated list. (optional) |

## Return Value

A [`QobuzApiStatusResponse`](../../QobuzApiSharp.Models/QobuzApiStatusResponse.md) that identifies if the request was successful ([`Status`](../../QobuzApiSharp.Models/QobuzApiStatusResponse/Status.md) = "success") or not.

## Exceptions

| exception | condition |
| --- | --- |
| [ApiErrorResponseException](../../QobuzApiSharp.Exceptions/ApiErrorResponseException.md) | Thrown if an error occurs while adding the user favorites. |
| [ApiResponseParseErrorException](../../QobuzApiSharp.Exceptions/ApiResponseParseErrorException.md) | Thrown when the API response could not be parsed. |

## See Also

* class [QobuzApiStatusResponse](../../QobuzApiSharp.Models/QobuzApiStatusResponse.md)
* class [QobuzApiService](../QobuzApiService.md)
* namespace [QobuzApiSharp.Service](../../QobuzApiSharp.md)

<!-- DO NOT EDIT: generated by xmldocmd for QobuzApiSharp.dll -->