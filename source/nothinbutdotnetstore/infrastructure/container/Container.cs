using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public static class Container
  {
    public static ContainerGatewayResolver gateway_resolver = () =>
    {
      throw new NotImplementedException("This needs to be set by the startup pipeline");
    };

    public static IFetchDependencies resolve
    {
      get { return gateway_resolver();}
    }
  }
}