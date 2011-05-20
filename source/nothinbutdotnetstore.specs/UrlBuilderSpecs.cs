 using System;
 using System.Linq.Expressions;
 using System.Security.Policy;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.specs
{  
  [Subject(typeof(UrlBuilder))]  
  public class UrlBuilderSpecs
  {
    public abstract class concern : Observes<IBuildUrls,
                                      UrlBuilder>
    {
      Establish c = () =>
      {
        token_store = depends.on<IStoreTokens>();
      };

      protected static IStoreTokens token_store;
    }

   
    public class when_provided_a_behaviour_to_target : concern
    {

      Because b = () =>
        result = sut.target<TheBehaviourToRun>();

      It should_store_the_token_for_the_targeted_behaviour = () =>
        token_store.received(x => x.store_token(UrlBuilder.command_key, typeof(TheBehaviourToRun)));

      It should_return_a_url_adorner = () =>
        result.ShouldBeAn<UrlBuilder>().ShouldNotEqual(sut);
  

      static IAddExtraInformationForABehaviourTarget result;
    }

    public abstract class concern_for_url_adorner : Observes<IAddExtraInformationForABehaviourTarget, UrlBuilder>
    {

      Establish c = () =>
      {
        token_store = depends.on<IStoreTokens>();
      };

      protected static IStoreTokens token_store;
    }

    public class when_appending_the_details_of_an_input_model_to_the_url : concern_for_url_adorner
    {
      Establish c = () =>
      {
        i_create_item_details = depends.on<ICreateItemDetailSpecifiers>();
        the_item_detail = fake.an<ISpecifyItemDetails<OurItemModel>>();

        configuration = x =>
        {
          x.ShouldEqual(the_item_detail);
          configured_item = true;
        };

        the_model = new OurItemModel();

        i_create_item_details.setup(x => x.create_specifier_for(the_model,token_store)).Return(the_item_detail);
      };

      Because b = () =>
        result = sut.include(the_model, configuration);

      It should_run_the_configuration_block_against_the_created_item_configurator = () =>
        configured_item.ShouldBeTrue();

      It should_return_a_new_detail_target = () =>
        result.ShouldBeAn<UrlBuilder>().ShouldNotEqual(sut);
  

      static IAddExtraInformationForABehaviourTarget result;
      static bool configured_item;
      static PayloadDetailConfiguration<OurItemModel> configuration;
      static OurItemModel the_model;
      static ISpecifyItemDetails<OurItemModel> the_item_detail;
      static ICreateItemDetailSpecifiers i_create_item_details;
    }

  class TheBehaviourToRun:IProcessAnApplicationSpecificBehaviour
  {
    public void run(IContainRequestInformation request)
    {
      throw new NotImplementedException();
    }
  }
  class OurItemModel
  {
  }
  }

}
