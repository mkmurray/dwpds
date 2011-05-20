using System;
using System.Linq;
using System.Linq.Expressions;

namespace nothinbutdotnetstore.web.core.urls
{
  public class MapPropertyAccessorExpressionToModelDotMember : IMapAnPropertyExpressionToAMeaningfulUrlTokenKey
  {
    public string map(Expression input)
    {
      var lambda = (LambdaExpression)input;
      var objName = lambda.Parameters.First().Type.Name.ToLower();
      var body = (MemberExpression)lambda.Body;
      var memberName = body.Member.Name.ToLower();
      return objName + "." + memberName;
    }
  }
}