namespace nothinbutdotnetstore.web.core
{
  public interface IStoreRoutes 
  {
    void register_route_to<Command>() where Command : IProcessAnApplicationSpecificBehaviour;
  }
}