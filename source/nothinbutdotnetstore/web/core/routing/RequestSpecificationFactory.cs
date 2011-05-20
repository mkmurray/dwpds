namespace nothinbutdotnetstore.web.core.routing
{
  public class RequestSpecificationFactory : ICreateRequestSpecifications
  {
    public RequestCriteria is_for<Command>() where Command : IProcessAnApplicationSpecificBehaviour
    {
      return x => x.raw_url.ToLower().Contains(typeof(Command).Name.ToLower());
    }
  }
}