using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public class PathRegistry : Dictionary<Type,string>,IFindAspxPagesForReportModels
  {
    public string get_the_path_to_a_page_that_can_render<ReportModel>()
    {
      return this[typeof(ReportModel)];
    }
  }
}