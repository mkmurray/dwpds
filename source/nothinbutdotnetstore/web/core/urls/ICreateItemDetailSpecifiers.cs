using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface ICreateItemDetailSpecifiers
  {
    ISpecifyItemDetails<InputModel> create_specifier_for<InputModel>(InputModel the_model, IStoreTokens token_store);
  }
}