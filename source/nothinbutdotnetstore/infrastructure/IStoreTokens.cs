using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
  public interface IStoreTokens : IEnumerable<KeyValuePair<string,object>>
  {
    void store_token(string key, object value);
  }
}