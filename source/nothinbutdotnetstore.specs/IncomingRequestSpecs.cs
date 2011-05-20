using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(IncomingRequest))]
  public class IncomingRequestSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_targeting_a_specific_incoming_command : concern
    {
      It first_observation = () =>
        
    }
  
}
