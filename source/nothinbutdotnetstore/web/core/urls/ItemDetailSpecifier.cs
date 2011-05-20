using System;
using System.Linq.Expressions;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.web.core.urls
{
    public class ItemDetailSpecifier<InputModel> : ISpecifyItemDetails<InputModel>
    {
        public void item<PropertyType>(Expression<PropertyAccessor<InputModel, PropertyType>> accessor)
        {
            throw new NotImplementedException();
        }
    }
}