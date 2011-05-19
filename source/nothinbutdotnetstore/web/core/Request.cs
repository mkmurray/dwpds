using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
  public class Request : IContainRequestInformation
  {
    public IMapFromOneTypeToAnother mapping_gateway;
    public Payload payload;

    public Request(IMapFromOneTypeToAnother mapping_gateway, Payload payload)
    {
      this.mapping_gateway = mapping_gateway;
      this.payload = payload;
    }

    public InputModel map<InputModel>()
    {
      return mapping_gateway.map<Payload, InputModel>(payload);
    }
  }
}