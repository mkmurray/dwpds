using System;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.infrastructure
{
  public static class CommandUrl
  {
    public static UrlBuilderFactory builder_factory = () =>
    {
      throw new NotImplementedException("This needs to be configured by the startup pipeline");
    };

    public static IAddExtraInformationForABehaviourTarget to_run<Behaviour>() where Behaviour : IProcessAnApplicationSpecificBehaviour
    {
      return builder_factory().target<Behaviour>();
    }
  }
}