using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.container;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(MappingGateway))]
  public class MappingGatewaySpecs
  {
    public abstract class concern : Observes<IMapFromOneTypeToAnother,
                                      MappingGateway>
    {
    }

    public class when_mapping_one_specific_mapping_pair : concern
    {
      Establish c = () =>
      {
        container = depends.on<IFetchDependencies>();

        the_mapped_item = new AnotherMappedItem();
        discrete_mapper = depends.on<IMapADiscretePair<int, AnotherMappedItem>>();
        container.setup(x => x.an<IMapADiscretePair<int, AnotherMappedItem>>()).Return(discrete_mapper);

        discrete_mapper.setup(x => x.map(number)).Return(the_mapped_item);
      };

      Because b = () =>
        result = sut.map<int, AnotherMappedItem>(number);

      It should_return_the_item_mapped_using_the_specific_mapper_for_that_pair = () =>
        result.ShouldEqual(the_mapped_item);

      static AnotherMappedItem result;
      static AnotherMappedItem the_mapped_item;
      static IFetchDependencies container;
      static IMapADiscretePair<int, AnotherMappedItem> discrete_mapper;
      static int number = 2;
    }

    public class AnotherMappedItem
    {
    }
  }
}