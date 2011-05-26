using System;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace nothinbutdotnetstore.infrastructure.interception
{
  public interface IInterceptCallsToMethods
  {
    void intercept(ITriggerTheOriginalBehaviour target);
  }

  public interface ITriggerTheOriginalBehaviour
  {
    void continue_running();
  }

  public class SecurityPolicy : IInterceptCallsToMethods
  {
    Predicate<IPrincipal> specification;

    public SecurityPolicy(Predicate<IPrincipal> specification)
    {
      this.specification = specification;
    }

    public void intercept(ITriggerTheOriginalBehaviour target)
    {
      if (specification(Thread.CurrentPrincipal))
      {
        target.continue_running();
      }
      throw new SecurityException("");
    }
  }
}