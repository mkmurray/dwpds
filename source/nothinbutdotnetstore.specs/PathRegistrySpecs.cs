 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{   
    [Subject(typeof(PathRegistry))]
    public class PathRegistrySpecs
    {
        public abstract class concern : Observes<IFindAspxPagesForReportModels,
                                            PathRegistry>
        {
        
        }

        public class when_a_page_for_a_product_is_requested : concern
        {
            private Because b = () =>
                                result = sut.get_the_path_to_a_page_that_can_render<IEnumerable<ProductItem>>();


            It should_call_the_get_the_path_to_a_page_that_can_render = () =>
            {
            };

            It should_return_a_department_view = () => result.ShouldEqual("~/views/ProductBrowser.aspx");

            static string result;
        }

        public class when_a_page_for_a_department_is_requested : concern
        {
          private Because b = () =>
                              result = sut.get_the_path_to_a_page_that_can_render<IEnumerable<DepartmentItem>>();

          It should_call_the_get_the_path_to_a_page_that_can_render = () =>
          {
          };

          It should_return_a_department_view = () => result.ShouldEqual("~/views/DepartmentBrowser.aspx");

          static string result;
        }
    }
}
