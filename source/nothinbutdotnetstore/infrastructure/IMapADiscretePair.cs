namespace nothinbutdotnetstore.infrastructure
{
  public interface IMapADiscretePair<Input,Output>
  {
    Output map(Input input);
  }
}