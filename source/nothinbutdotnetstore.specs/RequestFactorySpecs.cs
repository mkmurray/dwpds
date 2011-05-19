 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
  public class RequestFactorySpecs
  {
    [Subject(typeof(RequestFactory))]
    public abstract class concern : Observes<ICreateRequests,
                                      RequestFactory>
    {
        
    }

    public class when_creating_a_request_from_an_http_context : concern
    {
      Establish c = () =>
      {
        current_context = () => ObjectFactory.web.create_http_context();

        path_and_query = ObjectFactory.web.create_request().Url.PathAndQuery;
        request_command = new FrontControllerRequest(path_and_query);
      };

      Because b = () =>
        result = sut.create_request_from(current_context);

      It should_construct_a_command_request_passing_url_and_query_string = () =>
        result.ShouldBeTheSameAs(request_command);

      static CurrentContextResolver current_context;
      static IContainRequestInformation result;
      static FrontControllerRequest request_command;
      static string path_and_query;
    }
  }
}
