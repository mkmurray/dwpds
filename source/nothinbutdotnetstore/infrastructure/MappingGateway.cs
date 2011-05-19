using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.infrastructure
{
  public class MappingGateway : IMapFromOneTypeToAnother
  {
    IFetchDependencies container;

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