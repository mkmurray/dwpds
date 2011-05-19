using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
    public class SetOfCommands : IEnumerable<IProcessRequestInformation>
    {
        public IEnumerator<IProcessRequestInformation> GetEnumerator()
        {
          return HardCodedGateway.CommandList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}