namespace nothinbutdotnetstore.infrastructure
{
  public interface IProcessElementsOf<Item>
  {
    void visit(Item item);
  }
}