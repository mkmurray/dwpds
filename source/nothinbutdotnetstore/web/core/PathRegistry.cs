using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.web.core
{
  public class PathRegistry : IFindAspxPagesForReportModels
  {
    public string get_the_path_to_a_page_that_can_render<ReportModel>()
    {
      if (typeof (ReportModel).Equals(typeof (IEnumerable<DepartmentItem>)))
        return create_path_to("DepartmentBrowser");
      return create_path_to("ProductBrowser");
    }

    private string create_path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }

  }
}