using System.Web;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.stubs;

namespace nothinbutdotnetstore.web.core
{
  public interface ICreateRequests
  {
    IContainRequestInformation create_request_from(HttpContext context);
  }

  public class RequestFactory : ICreateRequests
  {
    IMapFromOneTypeToAnother mapping_gateway;
    PayloadFactory payload_factory;


    public RequestFactory(IMapFromOneTypeToAnother mapping_gateway, PayloadFactory payload_factory)
    {
      this.mapping_gateway = mapping_gateway;
      this.payload_factory = payload_factory;
    }

    public IContainRequestInformation create_request_from(HttpContext context)
    {
      return new Request(mapping_gateway, payload_factory(context)){raw_url = context.Request.RawUrl};
    }
  }
}