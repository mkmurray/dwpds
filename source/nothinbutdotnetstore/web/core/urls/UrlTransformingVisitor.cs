using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core.urls
{
  public class UrlTransformingVisitor : ITransformStoreTokensToANiceUrl
  {
    public StringBuilder url_builder = new StringBuilder();
    int number_of_items_visited;
    List<PairProcessor> processors;

    public UrlTransformingVisitor()
    {
      processors = new List<PairProcessor>();
      processors.Add(new PairProcessor(x => x == 1, x => string.Format("{0}.denver", ((Type) x.Value).Name)));
      processors.Add(new PairProcessor(x => x == 2, x => string.Format("?{0}={1}", x.Key, x.Value.ToString())));
      processors.Add(new PairProcessor(x => x > 2, x => string.Format("&{0}={1}", x.Key, x.Value.ToString())));
    }

    class PairProcessor
    {
      Predicate<int> condition;
      Func<KeyValuePair<string, object>, string> format;

      public PairProcessor(Predicate<int> condition, Func<KeyValuePair<string, object>, string> format)
      {
        this.condition = condition;
        this.format = format;
      }

      public bool matches(int value)
      {
        return condition(value);
      }

      public string process(KeyValuePair<string, object> pair)
      {
        return format(pair);
      }
    }

    public void visit(KeyValuePair<string, object> item)
    {
      number_of_items_visited++;
      url_builder.Append(processors.First(x => x.matches(number_of_items_visited)).process(item));
    }

    public string get_result()
    {
      return url_builder.ToString();
    }
  }
}