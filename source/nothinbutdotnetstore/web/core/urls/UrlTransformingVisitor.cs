using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core.urls
{
  public class UrlTransformingVisitor : ITransformStoreTokensToANiceUrl
  {
    private int itemsVisited = 0;
    private string command_name = string.Empty;
    private StringBuilder queryString = new StringBuilder();

    public void visit(KeyValuePair<string, object> item)
    {
      itemsVisited++;
      if (itemsVisited == 1)
      {
        command_name = ((Type) item.Value).Name;
      }
      else
      {
        queryString.Append(string.Format("{0}={1}", item.Key, item.Value.ToString()));
      }
    }

    public string get_result()
    {
      return string.Format("{0}.denver?{1}", command_name, queryString.ToString());
    }
  }
}