using System.Data;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.specs.utility;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(AutomaticDependencyFactory))]
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<IManageTheCreationOfOneSpecificType,
                                      AutomaticDependencyFactory>
    {
    }

    public class when_creating_a_type_at_runtime : concern
    {
      Establish c = () =>
      {
        the_container = depends.on<IFetchDependencies>();
        depends.on<ConstructorSelectionStrategy>(
          x =>
          {
            x.ShouldEqual(typeof(OurItemWithDependencies));
            return ObjectFactory.expressions.get_the_constructor_pointed_at_by<OurItemWithDependencies>(
              () => new OurItemWithDependencies(null, null, null)) ;
          });

        the_connection = fake.an<IDbConnection>();
        the_command = fake.an<IDbCommand>();
        the_reader = fake.an<IDataReader>();

        the_container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
        the_container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
        the_container.setup(x => x.an(typeof(IDataReader))).Return(the_reader);

        depends.on(typeof(OurItemWithDependencies));
      };

      Because b = () =>
        result = sut.create();

      It should_create_the_type_with_all_its_dependencies_satisfied = () =>
      {
        var item = result.ShouldBeAn<OurItemWithDependencies>();
        item.connection.ShouldEqual(the_connection);
        item.command.ShouldEqual(the_command);
        item.reader.ShouldEqual(the_reader);
      };

      static object result;
      static IDataReader the_reader;
      static IDbCommand the_command;
      static IDbConnection the_connection;
      static IFetchDependencies the_container;
    }
  }

  public class OurItemWithDependencies
  {
    public IDbConnection connection;

    public OurItemWithDependencies(IDbConnection connection)
    {
      this.connection = connection;
    }

    public OurItemWithDependencies(IDbConnection connection, IDbCommand command)
    {
      this.connection = connection;
      this.command = command;
    }

    public IDbCommand command { get; set; }
    public IDataReader reader { get; set; }

    public OurItemWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
    {
      this.connection = connection;
      this.command = command;
      this.reader = reader;
    }
  }
}