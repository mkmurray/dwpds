using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.urls
{
  public class UrlBuilder : IBuildUrls, IAddExtraInformationForABehaviourTarget
  {
    public static readonly string command_key = "command";
    ICreateItemDetailSpecifiers item_detail_factory;
    IStoreTokens token_store;

    public UrlBuilder(IStoreTokens token_store, ICreateItemDetailSpecifiers item_detail_factory)
    {
      this.token_store = token_store;
      this.item_detail_factory = item_detail_factory;
    }

    public IAddExtraInformationForABehaviourTarget include<InputModel>(InputModel input,
                                                                       PayloadDetailConfiguration<InputModel> config)
    {
      var item_specifier = item_detail_factory.create_specifier_for(input, token_store);
      config(item_specifier);
      return new_instance();
    }

    UrlBuilder new_instance()
    {
      return new UrlBuilder(token_store, item_detail_factory);
    }

    public IAddExtraInformationForABehaviourTarget target<T>()
    {
      token_store.store_token(command_key, typeof(T));
      return new_instance();
    }
  }
}