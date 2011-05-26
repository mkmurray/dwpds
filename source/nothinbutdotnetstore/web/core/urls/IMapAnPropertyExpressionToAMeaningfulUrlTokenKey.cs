using System.Linq.Expressions;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface IMapAnPropertyExpressionToAMeaningfulUrlTokenKey : IMapADiscretePair<Expression,string>
  {
  }
}