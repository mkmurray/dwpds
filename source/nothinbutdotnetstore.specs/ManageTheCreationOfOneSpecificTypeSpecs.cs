using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{
            [Subject(typeof (ManageTheCreationOfOneSpecificType))]
    public class ManageTheCreationOfOneSpecificTypeSpecs
    {
        public abstract class concern : Observes<IManageTheCreationOfOneSpecificType, ManageTheCreationOfOneSpecificType>
        {}


        public class when_creating_one_specific_type : concern
        {
            private Establish e = () =>
                                      {
                                          depends.on(typeof (MyTestClass));
                                      };
            private Because b = () =>
                                result = sut.create();
            private It shoould_return_one_specifics_type = () =>
                                                           result.ShouldEqual(typeof (MyTestClass));

             static object result;
                           
        }
    }

     class MyTestClass
    {
    }
}
