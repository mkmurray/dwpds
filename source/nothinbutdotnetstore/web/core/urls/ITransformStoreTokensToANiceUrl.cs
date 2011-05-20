using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface ITransformStoreTokensToANiceUrl
  {
    string get_result();
    void visit(KeyValuePair<string, object> key_value_pair);
  }
}