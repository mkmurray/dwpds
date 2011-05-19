namespace nothinbutdotnetstore.infrastructure
{
  public interface IStoreTokens
  {
    void store_token(string key, object value);
  }
}