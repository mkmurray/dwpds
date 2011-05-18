using System;

namespace nothinbutdotnetstore.web.core
{
  public class ViewMainDepartmentsInTheStore : IProcessAnApplicationSpecificBehaviour
  {
    ICreateReportModel report_model_creator;
    IFindViews find_views;

    public ViewMainDepartmentsInTheStore(ICreateReportModel report_model_creator, IFindViews find_views)
    {
      this.report_model_creator = report_model_creator;
      this.find_views = find_views;
    }

    public void run(IContainRequestInformation request)
    {
      var report_model = report_model_creator.create_report_model_from_request_information(request);
      find_views.get_the_view_that_can_display(report_model).display(report_model);
    }
  }
}