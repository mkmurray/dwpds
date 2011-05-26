using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(SimpleDependencyFactory))]
  public class SimpleDependencyFactorySpecs
  {
    public abstract class concern : Observes<IManageTheCreationOfOneSpecificType, SimpleDependencyFactory>
    {
    }

    public class when_creating_one_specific_type : concern
    {
      Establish e = () =>
      {
        the_item = new MyTestClass();
        depends.on<ItemFactory>(() => the_item);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_type_created_by_the_explicit_factory = () =>
        result.ShouldEqual(the_item);

      static object result;
      static object the_item;
    }
  }

  class MyTestClass
  {
  }
}