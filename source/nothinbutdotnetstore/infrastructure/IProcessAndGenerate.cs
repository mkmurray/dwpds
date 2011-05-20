namespace nothinbutdotnetstore.infrastructure
{
  public interface IProcessAndGenerate<ItemToVisit,Result> : IProcessElementsOf<ItemToVisit>
  {
    Result get_result();
  }
}