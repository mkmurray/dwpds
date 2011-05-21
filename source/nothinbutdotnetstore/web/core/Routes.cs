using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.web.core
{
  public class Routes
  {
    public static void register<Command>() where Command : IProcessAnApplicationSpecificBehaviour
    {
      Container.resolve.an<IStoreRoutes>().register_route_to<Command>();
    }
  }
}