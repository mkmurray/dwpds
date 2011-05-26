using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(TokenStore))]
  public class TokenStoreSpecs
  {
    public abstract class concern : Observes<IStoreTokens,
                                      TokenStore>
    {
    }

    public class when_an_token_is_added_to_a_token_store : concern
    {
      Establish c = () =>
      {
        key = "thekey";
        value = "the value";
      };

      Because b = () =>
        sut.store_token(key, value);

      It should_store_the_pair_correctly = () =>
      {
        concrete_sut[key].ShouldEqual(value);
      };

      static string key;
      static object value;
    }

    public class when_attempting_to_add_the_same_key_twice : concern
    {
      Establish c = () =>
      {
        key = "thekey";
        value = "the value";
        new_value = "second value";

        sut_setup.run(x => x.store_token(key, value));
      };

      Because b = () =>
        sut.store_token(key, new_value);

      It should_overwrite_the_previous_value = () =>
        concrete_sut[key].ShouldEqual(new_value);

      static string key;
      static object value;
      static object new_value;
    }
  }
}