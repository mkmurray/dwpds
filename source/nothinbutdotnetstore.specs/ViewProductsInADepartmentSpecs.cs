 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
  [Subject(typeof(ViewTheProductsInADepartment))]
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<IProcessAnApplicationSpecificBehaviour,
                                      ViewTheProductsInADepartment>
    {
        
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        store_catalog = depends.on<ICanFindDetailsInTheStore>();
        display_engine = depends.on<ICanRenderInformation>();
        request = fake.an<IContainRequestInformation>();

        products = new List<ProductItem>
        {
          new ProductItem()
        };
        department = new DepartmentItem();

        store_catalog.setup(x => x.get_products_for_department(department)).Return(products);
        request.setup(x => x.map<DepartmentItem>()).Return(department);
      };

      Because b = () =>
        sut.run(request);


      It should_tell_the_display_engine_to_display_products_in_the_department = () =>
        display_engine.received(x => x.display(products));
        
      static IContainRequestInformation request;
      static ICanRenderInformation display_engine;
      static IEnumerable<ProductItem> products;
      static ICanFindDetailsInTheStore store_catalog;
      static DepartmentItem department;
    }
  }
}
