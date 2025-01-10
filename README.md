# Source2 Client Preferences Plugin

### Supported databases

- SQLite
- MySQL
- PostgreSQL

Available field **driver** [values](https://github.com/kerillovi4/clientprefs/blob/master/clientprefs/Config/AppSettings.cs#L7)

### Dependencies

- Plugify Framework Installed
- [C# Language Module](https://github.com/untrustedmodders/plugify-module-dotnet)
- [Source2 SDK Plugin](https://github.com/untrustedmodders/plugify-source-2)

### API

```C#
delegate void OnClientCookiesCachedCallback(int clientIndex);

// Subscribe to an event that is called after the client's cookie is loaded from the database.
void OnClientCookiesCached_Register(OnClientCookiesCachedCallback callback);

// Unsubscribe to an event that is called after loading the client's cookie from the database.
void OnClientCookiesCached_UnRegister(OnClientCookiesCachedCallback callback);

// Creates a new Client preference cookie.
int RegisterClientCookie(string name, string description);

// Set the value of a Client preference cookie.
void SetClientCookie(int cookieId, int clientIndex, string value);

// Retrieve the value of a Client preference cookie.
string GetClientCookie(int cookieId, int clientIndex);

// Checks if a clients cookies have been loaded from the database.
bool AreClientCookiesCached(int clientIndex);
```
