using System.Linq.Expressions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.urls;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
  public class ItemDetailSpecifierSpecs
  {
    public abstract class concern : Observes<ISpecifyItemDetails<OurModel>,
                                      ItemDetailSpecifier<OurModel>>
    {
    }

    [Subject(typeof(ISpecifyItemDetails<OurModel>))]
    public class when_including_an_item : concern
    {
      Establish c = () =>
      {
        the_model = new OurModel {name = "sdfsdfsdf"};
        depends.on(the_model);
        token_store = depends.on<IStoreTokens>();
        property_key_mapper = depends.on<IMapAnPropertyExpressionToAMeaningfulUrlTokenKey>();
        mapped_key = "sfsdfsdf";
        property_accessor = x => x.name;

        property_key_mapper.setup(x => x.map(property_accessor)).Return(mapped_key);
      };

      Because b = () => 
        sut.item(property_accessor); 


      It should_store_the_id_and_value_that_correspond_to_the_details_on_the_expression = () =>
        token_store.received(x => x.store_token(mapped_key, the_model.name));

      static OurModel the_model;
      static Expression<PropertyAccessor<OurModel, string>> property_accessor;
      static IStoreTokens token_store;
      static string mapped_key;
      static IMapAnPropertyExpressionToAMeaningfulUrlTokenKey property_key_mapper;
    }

    public class OurModel
    {
      public string name;
    }
  }
}