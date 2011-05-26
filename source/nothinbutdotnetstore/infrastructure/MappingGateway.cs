using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.infrastructure.container.stubs;
using nothinbutdotnetstore.infrastructure.stubs;

namespace nothinbutdotnetstore.infrastructure
{
  public class MappingGateway : IMapFromOneTypeToAnother
  {
    IFetchDependencies container;

    public MappingGateway():this(Stub.with<StubContainer>())
    {
    }

    public MappingGateway(IFetchDependencies container)
    {
      this.container = container;
    }

    public Output map<Input, Output>(Input item)
    {
      return container.an<IMapADiscretePair<Input, Output>>().map(item);
    }
  }
}