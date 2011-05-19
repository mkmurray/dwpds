namespace nothinbutdotnetstore.web.core
{
  public class RequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_request_from(CurrentContextResolver context)
    {
      return new FrontControllerRequest(context().Request.Url.PathAndQuery);
    }
  }
}