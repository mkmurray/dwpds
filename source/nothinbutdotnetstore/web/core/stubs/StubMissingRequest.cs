using System;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core.urls;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubItemSpecifierFactory : ICreateItemDetailSpecifiers
  {
    public ISpecifyItemDetails<InputModel> create_specifier_for<InputModel>(InputModel the_model, IStoreTokens token_store)
    {
      return new ItemDetailSpecifier<InputModel>(token_store,
                                                 new MapPropertyAccessorExpressionToModelDotMember(),
                                                 the_model);
    }
  }
  public class StubMissingRequest
  {
    public IProcessRequestInformation create()
    {
      throw new NotImplementedException();
    }
  }
}