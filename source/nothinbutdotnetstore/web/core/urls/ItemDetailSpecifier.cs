using System.Linq.Expressions;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public class ItemDetailSpecifier<InputModel> : ISpecifyItemDetails<InputModel>
  {
    IStoreTokens token_store;
    InputModel model;
    IMapAnPropertyExpressionToAMeaningfulUrlTokenKey url_token_expression_mapper;

    public ItemDetailSpecifier(IStoreTokens token_store,
                               IMapAnPropertyExpressionToAMeaningfulUrlTokenKey url_token_expression_mapper,
                               InputModel model)
    {
      this.token_store = token_store;
      this.model = model;
      this.url_token_expression_mapper = url_token_expression_mapper;
    }

    public void item<PropertyType>(Expression<PropertyAccessor<InputModel, PropertyType>> accessor)
    {
      token_store.store_token(url_token_expression_mapper.map(accessor),
                              accessor.Compile().Invoke(model));
    }
  }
}