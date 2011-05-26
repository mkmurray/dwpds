using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_processing_each_item_in_an_iterator_with_a_dynamic_visitor : concern
    {
      Establish c = () =>
      {
        visitor = x => number_of_items_visited++;
        all_items = Enumerable.Range(1, 100).ToList();
      };

      Because b = () =>
        EnumerableExtensions.visit_each(all_items, visitor);


      It should_visit_each_item_using_the_visitor = () =>
        number_of_items_visited.ShouldEqual(all_items.Count);


      static IList<int> all_items;
      static int number_of_items_visited;
      static Action<int> visitor;
    }
    public class when_processing_each_item_with_a_explicit_visitor : concern
    {
      Establish c = () =>
      {
        visitor = fake.an<IProcessElementsOf<int>>();
        all_items = Enumerable.Range(1, 100).ToList();
      };

      Because b = () =>
        EnumerableExtensions.visit_using(all_items, visitor);


      It should_visit_each_item_using_the_visitor = () =>
        all_items.each(x => visitor.received(y => y.visit(x)));


      static IList<int> all_items;
      static int number_of_items_visited;
      static IProcessElementsOf<int> visitor;
    }
    public class when_getting_the_result_of_visiting_all_items_with_a_visitor : concern
    {
      Establish c = () =>
      {
        visitor = fake.an<IProcessAndGenerate<int,string>>();
        the_result = "sdfsdfsdf";
        all_items = Enumerable.Range(1, 100).ToList();

        visitor.setup(x => x.get_result()).Return(the_result);
      };

      Because b = () =>
        result = EnumerableExtensions.get_result_of_visiting_all_items_with(all_items, visitor);


      It should_visit_each_item_using_the_visitor = () =>
        all_items.each(x => visitor.received(y => y.visit(x)));

      It should_return_the_result_of_the_visitor = () =>
        result.ShouldEqual(the_result);


      static IList<int> all_items;
      static IProcessAndGenerate<int,string> visitor;
      static string result;
      static string the_result;
    }
  }
}
