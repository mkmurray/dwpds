using System;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.infrastructure
{
  public static class CommandUrl
  {
    public static string to_run<T>() where T : IProvideAUrlToRunACommand, new()
    {
      return new T().get_url();
    }
  }
}