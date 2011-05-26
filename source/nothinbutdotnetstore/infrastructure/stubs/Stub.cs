namespace nothinbutdotnetstore.infrastructure.stubs
{
    public class Stub
    {
       static public ItemToStub with<ItemToStub>() where ItemToStub: new()
        {
            return new ItemToStub();
        }
    }
}