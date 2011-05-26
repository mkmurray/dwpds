using System.Web;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
  public delegate Payload PayloadFactory(HttpContext context);
}