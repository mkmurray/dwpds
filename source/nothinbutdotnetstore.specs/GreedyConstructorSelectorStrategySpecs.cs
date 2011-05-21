 using System.CodeDom.Compiler;
 using System.Data;
 using System.Reflection;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.infrastructure.container;
 using nothinbutdotnetstore.specs.utility;

namespace nothinbutdotnetstore.specs
{   

  [Subject(typeof(GreedyConstructorSelectorStrategy))]
  public class GreedyConstructorSelectorStrategySpecs
  {
    public abstract class concern : Observes<GreedyConstructorSelectorStrategy>
    {
        
    }

    public class when_finding_the_correct_ctor_on_a_type : concern
    {
      Establish c = () =>
      {
        the_greediest = ObjectFactory.expressions.get_the_constructor_pointed_at_by<OurItemWithItems>(
          () => new OurItemWithItems(null, null));
      };

      Because b = () =>
        result = sut.find_on(typeof(OurItemWithItems));

      It should_return_the_one_with_the_most_arguments = () =>
        result.ShouldEqual(the_greediest);

      static ConstructorInfo result ;
      static ConstructorInfo the_greediest;
    }
  }

  public class OurItemWithItems
  {
    public OurItemWithItems(IDbConnection connection, IDbCommand command)
    {
      this.connection = connection;
      this.command = command;
    }

    public OurItemWithItems(IDbCommand command)
    {
      this.command = command;
    }

    public IDbConnection connection { get; set; }
    public IDbCommand command { get; set; }
  }
}
