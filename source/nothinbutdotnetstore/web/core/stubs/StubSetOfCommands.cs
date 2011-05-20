using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.routing;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessRequestInformation>
  {
    public IEnumerator<IProcessRequestInformation> GetEnumerator()
    {
      yield return new RequestCommand(Web.IncomingRequest.is_for<ViewProductsInADepartment>(), new ViewProductsInADepartment());
      yield return new RequestCommand(Web.IncomingRequest.is_for<ViewMainDepartmentsInTheStore>(), new ViewMainDepartmentsInTheStore());
    yield return new RequestCommand(Web.IncomingRequest.is_for<ViewProductsInADepartment>(), new ViewTheDepartmentsInADepartment());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}