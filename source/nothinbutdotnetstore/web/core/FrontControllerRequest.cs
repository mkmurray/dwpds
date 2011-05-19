using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
  public class FrontControllerRequest : IContainRequestInformation
  {
    public string path_and_query { get; private set; }

    public FrontControllerRequest(string path_and_query)
    {
      this.path_and_query = path_and_query;
    }

    public InputModel map<InputModel>()
    {
      object item = new DepartmentItem();
      return (InputModel) item;
    }
  }
}