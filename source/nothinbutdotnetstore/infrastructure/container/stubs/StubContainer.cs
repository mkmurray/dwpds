using System;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.infrastructure.container.stubs
{
  public class StubContainer : IFetchDependencies
  {
    public Dependency an<Dependency>()
    {
      object item = new StubDepartmentMapper();
      return (Dependency) item;
    }

    public object an(Type dependency)
    {
      throw new NotImplementedException();
    }
  }

  public class StubDepartmentMapper : IMapADiscretePair<Payload, DepartmentItem>
  {
    public DepartmentItem map(Payload input)
    {
      return new DepartmentItem {id = 42, name = "Arthur Deent"};
    }
  }
}