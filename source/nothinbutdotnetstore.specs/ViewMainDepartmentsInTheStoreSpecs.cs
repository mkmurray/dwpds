 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(ViewMainDepartmentsInTheStore))]  
  public class ViewMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                      ViewMainDepartmentsInTheStore>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        report_model_creator = depends.on<ICreateReportModel>();
        view_registry = depends.on<IFindViews>();

        view_that_can_display_the_report_model = fake.an<IView>();
        request_information = fake.an<IContainRequestInformation>();
        report_model = fake.an<IReportModel>();

        report_model_creator.setup(x => x.create_report_model_from_request_information(request_information)).Return(report_model);
        view_registry.setup(x => x.get_the_view_that_can_display(report_model))
          .Return(view_that_can_display_the_report_model);
      };

      Because b = () =>
        sut.run(request_information);


      It should_delegate_the_display_to_the_view_that_can_handle_the_report_model = () =>
        view_that_can_display_the_report_model.received(x => x.display(report_model));

      static IReportModel report_model;
      static IView view_that_can_display_the_report_model;
      static IFindViews view_registry;
      static IContainRequestInformation request_information;
      static ICreateReportModel report_model_creator;
    }
  }
}
