using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
  public static class EnumerableExtensions
  {
    public static void visit_each<ItemToVisit>(this IEnumerable<ItemToVisit> items, Action<ItemToVisit> visitor)
    {
      foreach (var item_to_visit in items) visitor(item_to_visit);
    }

    public static void visit_using<ItemToVisit>(this IEnumerable<ItemToVisit> items,
                                               IProcessElementsOf<ItemToVisit> visitor)
    {
      items.visit_each(visitor.visit);
    }

    public static Result get_result_of_visiting_all_items_with<ItemToVisit,Result>(this IEnumerable<ItemToVisit> items, IProcessAndGenerate<ItemToVisit,Result> visitor)
    {
      items.visit_using(visitor);
      return visitor.get_result();
    }
  }
}