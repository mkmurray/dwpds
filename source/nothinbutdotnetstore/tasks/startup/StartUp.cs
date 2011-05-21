using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.container;
using nothinbutdotnetstore.infrastructure.container.stubs;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.catalogbrowsing.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.routing;

namespace nothinbutdotnetstore.tasks.startup
{
  public class StartUp
  {
    static Dictionary<Type, IManageTheCreationOfOneSpecificType> dependencies;
    static IFetchDependencies container;

    public static void run()
    {
      dependencies = new Dictionary<Type, IManageTheCreationOfOneSpecificType>();
      configure_core_services();
      configure_front_controller();
      configure_service_layer();

      configure_application_components();
      configure_application_behaviours();
      configure_routes();
    }

    static void configure_application_components()
    {
      register_container_item<IMapADiscretePair<Payload,DepartmentItem>>(Stub.with<StubDepartmentMapper>());
    }

    static void configure_service_layer()
    {
      register_container_item<ICanFindDetailsInTheStore>(Stub.with<StubStoreCatalog>());
    }

    static void configure_front_controller()
    {
      register_container_item<IProcessIncomingRequests, FrontController>();
      register_container_item<ICreateRequests, RequestFactory>();
      register_container_item<IFindCommands, CommandRegistry>();
      register_container_item<ICreateRequestSpecifications, RequestSpecificationFactory>();

      var route_table = new RouteTable(container, container.an<ICreateRequestSpecifications>());

      register_container_item<IEnumerable<IProcessRequestInformation>>(route_table);
      register_container_item<IStoreRoutes>(route_table);

      register_container_item<PageFactory>(BuildManager.CreateInstanceFromVirtualPath);
      register_container_item<CurrentContextResolver>(() => HttpContext.Current);
      register_container_item<ICanRenderInformation, WebFormDisplayEngine>();
      register_container_item<ICreateAnAspxTemplateForAReportModel, WebFormFactory>();
      register_container_item<PayloadFactory>(x => Stub.with<StubPayload>());

      var path_registry = new PathRegistry();
      path_registry.Add(typeof(IEnumerable<DepartmentItem>), "~/views/DepartmentBrowser.aspx");
      path_registry.Add(typeof(IEnumerable<ProductItem>), "~/views/ProductBrowser.aspx");

      register_container_item<IFindAspxPagesForReportModels>(path_registry);
      register_container_item<MissingCommandFactory>(() =>
      {
        throw new NotImplementedException("There is no command for you!!!");
      });
    }

    static void configure_application_behaviours()
    {
      register_container_item<ViewMainDepartmentsInTheStore>();

      register_container_item<ViewTheDepartmentsInADepartment>();
      register_container_item<ViewProductsInADepartment>();
    }

    static void configure_routes()
    {
      Routes.register<ViewMainDepartmentsInTheStore>();
      Routes.register<ViewTheDepartmentsInADepartment>();
      Routes.register<ViewProductsInADepartment>();
    }

    static void configure_core_services()
    {
      container = new DependencyContainer(dependencies);
      ContainerGatewayResolver resolver = () => container;
      Container.gateway_resolver = resolver;

      register_container_item(container);
      register_container_item<IMapFromOneTypeToAnother,MappingGateway>();
    }

    static void register_container_item<Contract>(Contract instance)
    {
      dependencies.Add(typeof(Contract),
                       new SimpleDependencyFactory(() => instance));
    }

    static void register_container_item<Instance>()
    {
      dependencies.Add(typeof(Instance),
                       new AutomaticDependencyFactory(typeof(Instance),
                                                      container, new GreedyConstructorSelectorStrategy().find_on));
    }

    static void register_container_item<Contract, Instance>()
    {
      dependencies.Add(typeof(Contract),
                       new AutomaticDependencyFactory(typeof(Instance),
                                                      container, new GreedyConstructorSelectorStrategy().find_on));
    }
  }
}