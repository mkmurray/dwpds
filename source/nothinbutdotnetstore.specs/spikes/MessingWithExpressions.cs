using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure;
using System.Linq;

namespace nothinbutdotnetstore.specs.spikes
{
  [Subject(typeof(Expression<>))]
  public class MessingWithExpressions
  {
    public abstract class concern : Observes
    {

    }

    public class when_playing_around_with_expressions : concern
    {
      It should_be_able_to_get_at_the_name_of_a_property_pointed_at_by_an_expression = () =>
      {
        Expression<PropertyAccessor<Person, string>> name_accessor = x => x.name;
        var name = name_accessor.Body.downcast_to<MemberExpression>().Member.Name;

        name.ShouldEqual("name");
      };
        
      It should_be_able_to_get_the_value_pointed_at_by_an_expression = () =>
      {
        var person = new Person {name = "jp"};
        Expression<PropertyAccessor<Person, string>> name_accessor = x => x.name;

        var accessor = name_accessor.Compile();

        accessor(person).ShouldEqual(person.name);
      };

      It should_be_able_to_create_code_at_runtime = () =>
      {
        var results = new List<Person>().Where(x => x.name.StartsWith("J"))
          .Where(x => x.age > 10)
          .Select(x => x.name.Substring(1, 4));


        Func<int, bool> is_even = x => x%2 == 0;
        is_even(2).ShouldBeTrue();

        var parameter = Expression.Parameter(typeof(int), "x");
        var the_number_2 = Expression.Constant(2);

        var modulus = Expression.Modulo(parameter, the_number_2);
        var is_even_expression = Expression.Equal(modulus, Expression.Constant(0));

        var final_expression = Expression.Lambda<Func<int, bool>>(is_even_expression, parameter);

        var dynamic_code = final_expression.Compile();

        dynamic_code(2).ShouldBeTrue();
      };

  
    }
  }

  class Person
  {
    public string name { get; set; }
    public int age { get; set; }
    public DateTime birthday { get; set; }
  }
}
