using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewMainDepartmentsInTheStore : IProcessAnApplicationSpecificBehaviour, IProvideAUrlToRunACommand
  {
    ICanFindDetailsInTheStore store_catalog;
    ICanRenderInformation display_engine;

    public ViewMainDepartmentsInTheStore(ICanFindDetailsInTheStore store_catalog, ICanRenderInformation display_engine)
    {
      this.store_catalog = store_catalog;
      this.display_engine = display_engine;
    }

    public void run(IContainRequestInformation request)
    {
      display_engine.display(store_catalog.get_the_main_departments());
    }

    public string get_url()
    {
      throw new NotImplementedException();
    }
  }
}