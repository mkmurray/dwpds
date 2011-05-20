using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core.urls
{
  public class UrlTransformingVisitor : ITransformStoreTokensToANiceUrl
  {
    public StringBuilder url_builder = new StringBuilder();
    int number_of_items_visited;

    public void visit(KeyValuePair<string, object> item)
    {
      number_of_items_visited++;
      if (number_of_items_visited ==1)
      {
        url_builder.AppendFormat("{0}.denver", ((Type)item.Value).Name);
        return;
      }
      if (number_of_items_visited == 2)
      {
        url_builder.AppendFormat("?{0}={1}", item.Key, item.Value.ToString());
      }
      else
      {
        url_builder.AppendFormat("&{0}={1}", item.Key, item.Value.ToString());
      }

    }

    public string get_result()
    {
      throw new NotImplementedException();
    }
  }
}