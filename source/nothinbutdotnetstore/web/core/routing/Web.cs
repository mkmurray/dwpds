using System;

namespace nothinbutdotnetstore.web.core.routing
{
  public class Web
  {
    public static RequestCriteriaBuilderFactory request_criteria_factory = () =>
    {
      throw new NotImplementedException("This should be configured at startup");
    };

    public static ICreateRequestSpecifications IncomingRequest
    {
      get { return request_criteria_factory(); }
    }
  }
}