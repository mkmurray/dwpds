using System.Linq.Expressions;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface ISpecifyItemDetails<InputModel>
  {
    void item<PropertyType>(Expression<PropertyAccessor<InputModel, PropertyType>> accessor);
  }
}