 using System.Linq.Expressions;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{   
    public class ItemDetailSpecifierSpecs
    {
        public abstract class concern : Observes<ISpecifyItemDetails<OurModel>,
                                            ItemDetailSpecifier<OurModel>>
        {
        
        }

        [Subject(typeof(ISpecifyItemDetails<OurModel>))]
        public class wheb_including_an_item : concern
        {
            private Establish c = () =>
                                      {
                                          theModel = new OurModel();
                                          propertyAccessor = x => x.name;
                                      };

            private Because b = () =>
                                    {
                                        sut.item(propertyAccessor);
                                    };


            private It needs_to_create_a_name_value_pair_for_the_token_store = () => { };

            private It should_invoke_the_property_accessor_against_the_input_model = () => { };
            private static OurModel theModel;
            private static Expression<PropertyAccessor<OurModel, string>> propertyAccessor;
            private static bool invokedPropertyAccessor;
        }

        public class OurModel
        {
            public string name;
        }
    }
}
