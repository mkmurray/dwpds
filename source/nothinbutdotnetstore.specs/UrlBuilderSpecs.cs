using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
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
      Establish c = () => { token_store = depends.on<IStoreTokens>(); };

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
      Establish c = () => { token_store = depends.on<IStoreTokens>(); };

      protected static IStoreTokens token_store;
    }

    public class when_appending_the_details_of_an_input_model_to_the_url : concern_for_url_adorner
    {
      Establish c = () =>
      {
        the_model = new OurItemModel();
        the_item_detail = fake.an<ISpecifyItemDetails<OurItemModel>>();
        i_create_item_details = depends.on<ICreateItemDetailSpecifiers>();
        depends.on(i_create_item_details);

        configuration = x =>
        {
          x.ShouldEqual(the_item_detail);
          configured_item = true;
        };

        i_create_item_details.setup(x => x.create_specifier_for(the_model, token_store)).Return(the_item_detail);
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

    public class when_converting_to_a_string : concern_for_url_adorner
    {
      Establish c = () =>
      {
        all_tokens = new List<KeyValuePair<string, object>>();
        Enumerable.Range(1, 100).each(x => all_tokens.Add(new KeyValuePair<string, object>(x.ToString(), x)));
        url_transforming_visitor = depends.on<ITransformStoreTokensToANiceUrl>();
        url_built_by_the_visitor = "sdfsdfsfdsfdsdf";
        token_store.setup(x => x.GetEnumerator()).Return(all_tokens.GetEnumerator());

        url_transforming_visitor.setup(x => x.get_result()).Return(url_built_by_the_visitor);
      };

      Because b = () =>
        result = sut.ToString();

      It should_have_used_the_visitor_to_process_each_of_the_tokens = () =>
        all_tokens.each(x => url_transforming_visitor.received(y => y.visit(x)));

      It should_return_the_url_built_by_the_url_formatting_token_store_visitor = () =>
        result.ShouldEqual(url_built_by_the_visitor);

      static string result;
      static string url_built_by_the_visitor;
      static ITransformStoreTokensToANiceUrl url_transforming_visitor;
      static List<KeyValuePair<string, object>> all_tokens;
    }

    public class TheBehaviourToRun : IProcessAnApplicationSpecificBehaviour
    {
      public void run(IContainRequestInformation request)
      {
        throw new NotImplementedException();
      }
    }

    public class OurItemModel
    {
    }
  }
}