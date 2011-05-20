using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
  public class TokenStore : Dictionary<string, object>, IStoreTokens
  {
    public void store_token(string key, object value)
    {
      this[key] = value;
    }
  }
}