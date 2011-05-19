using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewTheProductsInADepartment : IProcessAnApplicationSpecificBehaviour
  {
    ICanFindDetailsInTheStore store_catalog;
    ICanRenderInformation view_engine;

    public ViewTheProductsInADepartment(ICanFindDetailsInTheStore store_catalog, ICanRenderInformation view_engine)
    {
      this.store_catalog = store_catalog;
      this.view_engine = view_engine;
    }

    public void run(IContainRequestInformation request)
    {
      var products = store_catalog.get_products_for_department(request.map<DepartmentItem>());
      view_engine.display(products);
    }
  }
}