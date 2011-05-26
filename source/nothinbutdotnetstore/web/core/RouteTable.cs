using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.web.core.routing;

namespace nothinbutdotnetstore.web.core
{
  public class RouteTable : List<IProcessRequestInformation>, IStoreRoutes
  {
    IFetchDependencies container;
    ICreateRequestSpecifications incoming_request;

    public RouteTable(IFetchDependencies container, ICreateRequestSpecifications incoming_request)
    {
      this.container = container;
      this.incoming_request = incoming_request;
    }

    public void register_route_to<Command>() where Command : IProcessAnApplicationSpecificBehaviour
    {
      Add(new RequestCommand(incoming_request.is_for<Command>(),
                             container.an<Command>()));
    }
  }
}