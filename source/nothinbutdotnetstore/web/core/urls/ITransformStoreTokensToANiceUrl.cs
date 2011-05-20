using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface ITransformStoreTokensToANiceUrl :IProcessAndGenerate<KeyValuePair<string,object>,string >
  {
  }
}