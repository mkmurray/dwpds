namespace nothinbutdotnetstore.web.core
{
  public interface IContainRequestInformation
  {
    string path_and_query { get; }
    InputModel map<InputModel>();
  }
}