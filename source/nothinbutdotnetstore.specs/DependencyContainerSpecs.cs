using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
    }

    [Subject(typeof(DependencyContainer))]
    public class when_asked_to_resolve_a_dependency_and_it_has_the_factory_for_that_dependency : concern
    {
      Establish c = () =>
      {
        the_created_item = new OurContract();
        factory = fake.an<IManageTheCreationOfOneSpecificType>();
        factories = new Dictionary<Type,IManageTheCreationOfOneSpecificType>();
        factories.Add(typeof(OurContract),factory);

        depends.on(factories);

        factory.setup(x => x.create()).Return(the_created_item);
      };

      Because b = () =>
        result = sut.an<OurContract>();

      It should_return_the_dependency_created_by_the_factory_for_the_type = () =>
        result.ShouldEqual(the_created_item);

      static ILookupTypesByContract type_registry;
      static OurContract result;
      static OurContract the_created_item;
      static IDictionary<Type, IManageTheCreationOfOneSpecificType> factories;
      static IManageTheCreationOfOneSpecificType factory;
    }

    public class when_resolving_a_dependency_at_runtime : concern
    {
      Establish c = () =>
      {
        the_created_item = new OurContract();
        factory = fake.an<IManageTheCreationOfOneSpecificType>();
        factories = new Dictionary<Type,IManageTheCreationOfOneSpecificType>();
        factories.Add(typeof(OurContract),factory);

        depends.on(factories);

        factory.setup(x => x.create()).Return(the_created_item);
      };

      Because b = () =>
        result = sut.an(typeof(OurContract));

      It should_return_the_dependency_created_by_the_factory_for_the_type = () =>
        result.ShouldEqual(the_created_item);

      static ILookupTypesByContract type_registry;
      static object result;
      static OurContract the_created_item;
      static IDictionary<Type, IManageTheCreationOfOneSpecificType> factories;
      static IManageTheCreationOfOneSpecificType factory;
    }

    public class when_asked_to_resolve_a_dependency_and_it_does_not_have_the_factory_for_that_dependency : concern
    {
      Establish c = () =>
      {
        factories = new Dictionary<Type,IManageTheCreationOfOneSpecificType>();
        depends.on(factories);
      };

      Because b = () =>
        spec.catch_exception(() => sut.an<OurContract>());

      It should_throw_a_dependency_factory_not_registered_exception_for_the_specified_type = () =>
        spec.exception_thrown.ShouldBeAn<DependencyFactoryNotRegisteredException>()
          .type_that_has_no_factory.ShouldEqual(typeof(OurContract));

      static IDictionary<Type, IManageTheCreationOfOneSpecificType> factories;
    }

    public class when_the_factory_for_a_dependency_throws_an_exception_during_create : concern
    {
      Establish c = () =>
      {
        the_original_exception = new Exception();
        misbehaving_factory = fake.an<IManageTheCreationOfOneSpecificType>();
        factories = new Dictionary<Type,IManageTheCreationOfOneSpecificType>();

        factories.Add(typeof(OurContract),misbehaving_factory);

        depends.on(factories);

        misbehaving_factory.setup(x => x.create()).Throw(the_original_exception);
      };

      Because b = () =>
        spec.catch_exception(() => sut.an<OurContract>());

      It should_throw_a_dependency_creation_exception_with_the_correct_details = () =>
      {
        var exception = spec.exception_thrown.ShouldBeAn<DependencyCreationException>();
        exception.type_that_could_not_be_created.ShouldEqual(typeof(OurContract));
        exception.InnerException.ShouldEqual(the_original_exception);
      };

      static IDictionary<Type, IManageTheCreationOfOneSpecificType> factories;
      static Exception the_original_exception;
      static IManageTheCreationOfOneSpecificType misbehaving_factory;
    }
  }

  public class OurContract
  {
  }
}