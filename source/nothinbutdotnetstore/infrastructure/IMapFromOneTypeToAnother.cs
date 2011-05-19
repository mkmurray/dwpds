namespace nothinbutdotnetstore.infrastructure
{
  public interface IMapFromOneTypeToAnother
  {
    Output map<Input, Output>(Input item);
  }
}