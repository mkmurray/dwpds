using System;
using System.IO;
using System.Web;

namespace nothinbutdotnetstore.specs.utility
{
  public class ObjectFactory
  {
    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      public static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/folder/blah.aspx", "querystring=true");
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }
  }
}