# QobuzApiSharp

## Overview

QobuzApiSharp provides an unofficial c# library for the public REST API offered by the [Qobuz streaming service](https://www.qobuz.com/).

## API Endpoint

API endpoint used by QobuzApiSharp:

>     https://www.qobuz.com/api.{format}/{version}/

+ Current version number : `0.2`
+ Parsed output format : `json`

## Usage

### Instantiation and application authentication

In order to use the API, you need to authenticate your application with an application ID and application secret.  
Official apps can contact Qobuz to request application credentials (`app_id` and `app_secret` values).
These can then be used to instantiate the QobuzApiService class, which provides acces to the Qobuz API endpoints:

```csharp
QobuzApiService apiService = new QobuzApiService(appId, userAuthToken);
```

Alternatively, QobuzApiSharp offers to option to attempt to fetch the application credentials from the [Qobuz Web Player](https://play.qobuz.com/). To use this option, simply instantiate the QobuzApiService class without any arguments:

```csharp
QobuzApiService apiService = new QobuzApiService();
```

**Disclaimer : Please note that using the Qobuz Web Player credentials may break at any time due to updates to the Qobuz Web Player**

## User authentication

Once an instance of the QobuzApiService is successfuly created, a login needs to be performed before accessing endpoint methods which require user authentication.
Once a successful login method is performed, the `user_auth_token` will be cashed in the QobuzApiService for further use.  

The QobuzApiService offers 2 types of login methods:

#### 1. Login with username or email and password

When logging in with the user email of username, the plain text password first needs to be converted to a MD5 hash. The MD5 hashed password can be used to perform a login with either of the following methods:

```csharp
apiService.LoginWithEmail(email, MD5Password);
```

```csharp
apiService.LoginWithUsername(username, MD5Password);
```

#### 2. Login with user ID and user Auth Token

If a user ID and `user_auth_token` is already available, these can be used to login with the following method:

```csharp
apiService.LoginWithToken(userID, userAuthToken);
```

## Endpoint method calls

All available endpoints and their methods are available in the QobuzApiService class. Every attempt is made to keep the QobuzApiService well documented in the code using c# XML comments, so please refer to the internal documentation for more info.
