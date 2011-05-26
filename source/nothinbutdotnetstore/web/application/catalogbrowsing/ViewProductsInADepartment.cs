using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewProductsInADepartment : IProcessAnApplicationSpecificBehaviour
  {
    ICanRenderInformation display_engine;
    ICanFindDetailsInTheStore store_catalog;

    public ViewProductsInADepartment(ICanRenderInformation display_engine,
                                     ICanFindDetailsInTheStore store_catalog)
    {
      this.display_engine = display_engine;
      this.store_catalog = store_catalog;
    }

    public void run(IContainRequestInformation request)
    {
      display_engine.display(store_catalog.get_products_for(request.map<DepartmentItem>()));
    }
  }
}