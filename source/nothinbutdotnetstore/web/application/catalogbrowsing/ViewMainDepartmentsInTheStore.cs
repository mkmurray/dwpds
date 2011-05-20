using System;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewMainDepartmentsInTheStore : IProcessAnApplicationSpecificBehaviour, IProvideAUrlToRunACommand
  {
    ICanFindDetailsInTheStore store_catalog;
    ICanRenderInformation display_engine;

    public ViewMainDepartmentsInTheStore() : this(Stub.with<StubStoreCatalog>(),
                                                  new WebFormDisplayEngine())
    {
    }

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