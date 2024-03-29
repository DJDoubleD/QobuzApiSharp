# QobuzApiService.LoginWithEmail method

Login to Qobuz API with email and MD5 hashed password. On successful login, saves the user_auth_token in service for API requests. Login is required to use API methods which require authentication.

```csharp
public Login LoginWithEmail(string email, string password)
```

| parameter | description |
| --- | --- |
| email | User email |
| password | MD5 hashed user password |

## Return Value

An instance of the Login class containing the logged in User instance and user_auth_token.

## Exceptions

| exception | condition |
| --- | --- |
| [ApiErrorResponseException](../../QobuzApiSharp.Exceptions/ApiErrorResponseException.md) | Thrown when the API request returns an error. |
| [ApiResponseParseErrorException](../../QobuzApiSharp.Exceptions/ApiResponseParseErrorException.md) | Thrown when the API response could not be parsed. |

## See Also

* class [Login](../../QobuzApiSharp.Models.User/Login.md)
* class [QobuzApiService](../QobuzApiService.md)
* namespace [QobuzApiSharp.Service](../../QobuzApiSharp.md)

<!-- DO NOT EDIT: generated by xmldocmd for QobuzApiSharp.dll -->
