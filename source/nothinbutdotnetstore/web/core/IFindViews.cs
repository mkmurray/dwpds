namespace nothinbutdotnetstore.web.core
{
  public interface IFindViews
  {
    IView get_the_view_that_can_display(IReportModel report_model);
  }
}