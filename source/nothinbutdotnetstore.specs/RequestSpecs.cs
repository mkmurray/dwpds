using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(Request))]
  public class RequestSpecs
  {
    public abstract class concern : Observes<IContainRequestInformation,
                                      Request>
    {
    }

    public class when_mapping_an_input_model_from_its_payload : concern
    {
      Establish c = () =>
      {
        the_mapped_model = new ThisModel();
        mapping_gateway = depends.on<IMapFromOneTypeToAnother>();
        payload = fake.an<Payload>();
        depends.on(payload);

        mapping_gateway.setup(x => x.map<Payload, ThisModel>(payload))
          .Return(the_mapped_model);
      };

      Because b = () =>
        result = sut.map<ThisModel>();

      It should_return_item_mapped_using_the_mapping_gateway = () =>
        result.ShouldEqual(the_mapped_model);

      static ThisModel result;
      static ThisModel the_mapped_model;
      static IMapFromOneTypeToAnother mapping_gateway;
      static Payload payload;
    }

    class ThisModel
    {
    }
  }
}