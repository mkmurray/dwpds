using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.aspnet
{
  public class RouteGateway
  {
    static IList<RouteBindings> route_list = new List<RouteBindings>
    {
      new RouteBindings { report_model = typeof(ViewMainDepartmentsInTheStore), route_url = typeof(ViewMainDepartmentsInTheStore).Name },
      new RouteBindings { report_model = typeof(ViewTheDepartmentsInADepartment), route_url = typeof(ViewMainDepartmentsInTheStore).Name },
      new RouteBindings { report_model = typeof(ViewProductsInADepartment), route_url = typeof(ViewProductsInADepartment).Name}
    };

    public static string GetRoute(object report_model)
    {
      var report_model_type = report_model.GetType();
      return route_list.FirstOrDefault(x => x.report_model == report_model_type).route_url;
    }

    public static Type GetRoute(string url)
    {
      return route_list.FirstOrDefault(x => x.route_url == url).report_model;
    }

    private class RouteBindings
    {
      public Type report_model { get; set; }
      public string route_url { get; set; }
    }
  }
}