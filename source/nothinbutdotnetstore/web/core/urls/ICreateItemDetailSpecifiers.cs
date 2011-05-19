using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public interface ICreateItemDetailSpecifiers
  {
    ISpecifiyItemDetails<InputModel> create_specifier_for<InputModel>(InputModel the_model, IStoreTokens token_store);
  }
}