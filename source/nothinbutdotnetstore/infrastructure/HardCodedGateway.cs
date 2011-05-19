using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure
{
    public class HardCodedGateway
    {
        static public IEnumerable<IProcessRequestInformation> CommandList()
        {
            yield return new RequestCommand(x => true, new ViewMainDepartmentsInTheStore());
            yield return new RequestCommand(x => true, new ViewTheDepartmentsInADepartment());
            yield return new RequestCommand(x => true, new ViewProductsInADepartment());
        }  
    }
}