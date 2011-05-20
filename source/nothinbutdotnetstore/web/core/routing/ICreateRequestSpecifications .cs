namespace nothinbutdotnetstore.web.core.routing
{
  public interface ICreateRequestSpecifications 
  {
    RequestCriteria is_for<Command>() where Command : IProcessAnApplicationSpecificBehaviour;
  }
}