namespace nothinbutdotnetstore.web.core
{
  public class MissingApplicationBehaviour : IProcessRequestInformation
  {
    public void run(IContainRequestInformation request)
    {
      throw new CommandNotRegisteredException(request);
    }

    public bool can_process(IContainRequestInformation request)
    {
      return false;
    }
  }
}