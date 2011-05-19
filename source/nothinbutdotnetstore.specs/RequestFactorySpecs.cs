 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(RequestFactory))]  
  public class RequestFactorySpecs
  {
    public abstract class concern : Observes<ICreateRequests,
                                      RequestFactory>
    {
        
    }

   
    public class when_creating_a_request_from_an_http_context : concern
    {

      Establish c = () =>
      {
        the_mapping_gateway = depends.on<IMapFromOneTypeToAnother>();
        context = ObjectFactory.web.create_http_context();
        the_created_payload = fake.an<Payload>();  
        depends.on<PayloadFactory>(x =>
        {
          x.ShouldEqual(context);
          return the_created_payload;
        });

      };
      Because b = () =>
        result = sut.create_request_from(context);


      It should_return_a_well_formed_request = () =>
      {
        var request = result.ShouldBeAn<Request>();
        request.mapping_gateway.ShouldEqual(the_mapping_gateway);
        request.payload.ShouldEqual(the_created_payload);
      };

      static IContainRequestInformation result;
      static Payload the_created_payload;
      static IMapFromOneTypeToAnother the_mapping_gateway;
      static HttpContext context;
    }
  }
}
