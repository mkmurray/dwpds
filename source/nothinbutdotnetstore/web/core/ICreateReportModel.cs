namespace nothinbutdotnetstore.web.core
{
  public interface ICreateReportModel
  {
    IReportModel create_report_model_from_request_information(IContainRequestInformation request);
  }
}