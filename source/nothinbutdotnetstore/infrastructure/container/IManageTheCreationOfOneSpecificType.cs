namespace nothinbutdotnetstore.infrastructure.container
{
  public interface IManageTheCreationOfOneSpecificType
  {
    object create();
  }

  public class SimpleDependencyFactory : IManageTheCreationOfOneSpecificType
  {
    ItemFactory item_factory;

    public SimpleDependencyFactory(ItemFactory item_factory)
    {
      this.item_factory = item_factory;
    }

    public object create()
    {
      return item_factory();
    }
  }
}