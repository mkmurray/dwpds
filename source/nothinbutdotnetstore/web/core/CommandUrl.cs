using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.web.core
{
  public static class CommandUrl
  {
    public static IAddExtraInformationForABehaviourTarget to_run<Behaviour>()
      where Behaviour : IProcessAnApplicationSpecificBehaviour
    {
      var url_builder_factory = Container.resolve.an<UrlBuilderFactory>();
      return url_builder_factory().target<Behaviour>();
    }
  }
}