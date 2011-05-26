using System.Web;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public class WebFormFactory : ICreateAnAspxTemplateForAReportModel
  {
    PageFactory page_factory;

    IFindAspxPagesForReportModels page_registry;

    public WebFormFactory(PageFactory page_factory, IFindAspxPagesForReportModels page_registry)
    {
      this.page_factory = page_factory;
      this.page_registry = page_registry;
    }

    public IHttpHandler create_view_to_render<ReportModel>(ReportModel report_model)
    {
      var view =
        (IReportModelBoundAspx<ReportModel>)
          page_factory(page_registry.get_the_path_to_a_page_that_can_render<ReportModel>(),
                       typeof(IReportModelBoundAspx<ReportModel>));
      view.model = report_model;
      return view;
    }
  }
}