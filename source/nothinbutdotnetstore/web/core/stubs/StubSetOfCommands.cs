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
      yield return register_command<ViewMainDepartmentsInTheStore>();
      yield return register_command<ViewProductsInADepartment>();
      yield return register_command<ViewTheDepartmentsInADepartment>();
    }

    IProcessRequestInformation register_command<Command>() where Command
                                                             : IProcessAnApplicationSpecificBehaviour
    {
      return new RequestCommand(Web.IncomingRequest.is_for<Command>(),
                                null);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}