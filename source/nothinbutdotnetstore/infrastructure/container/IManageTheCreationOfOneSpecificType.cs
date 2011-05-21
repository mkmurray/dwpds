using System;

namespace nothinbutdotnetstore.infrastructure.container
{
  public interface IManageTheCreationOfOneSpecificType
  {
    object create();
  }

    public  class ManageTheCreationOfOneSpecificType :IManageTheCreationOfOneSpecificType
    {
        private readonly Type type;

        public ManageTheCreationOfOneSpecificType( Type type)
        {
            this.type = type;
        }

        public object create()
        {
            return Activator.CreateInstance(type);
        }
    }

    public class OneSpecificType
    {}

}