using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
  public class Request : IContainRequestInformation
  {
    public IMapFromOneTypeToAnother mapping_gateway;
    public string raw_url { get; set; }

    public Payload payload;

    public Request(IMapFromOneTypeToAnother mapping_gateway, Payload payload)
    {
      this.mapping_gateway = mapping_gateway;
      this.payload = payload;
      this.raw_url = raw_url;
    }

    public InputModel map<InputModel>()
    {
      return mapping_gateway.map<Payload, InputModel>(payload);
    }
  }
}