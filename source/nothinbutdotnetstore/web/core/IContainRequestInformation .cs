namespace nothinbutdotnetstore.web.core
{
  public interface IContainRequestInformation
  {
    InputModel map<InputModel>();
    string raw_url { get; }
  }
}