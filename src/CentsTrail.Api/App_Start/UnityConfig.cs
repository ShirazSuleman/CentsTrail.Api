using CentsTrail.Api.Controllers;
using CentsTrail.Api.DataAccess.Currencies;
using CentsTrail.Api.Helpers;
using Microsoft.Practices.Unity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using CentsTrail.Api.DataAccess.Accounts;
using CentsTrail.Api.DataAccess.AccountTypes;
using CentsTrail.Api.DataAccess.Categories;
using CentsTrail.Api.DataAccess.CategoryTypes;
using CentsTrail.Api.DataAccess.Periods;
using CentsTrail.Api.DataAccess.Transactions;
using Unity.WebApi;

namespace CentsTrail.Api
{
  public static class UnityConfig
  {
    public static void Register(HttpConfiguration config)
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();

      container.RegisterType<IDbConnection, SqlConnection>(new HierarchicalLifetimeManager(), new InjectionConstructor(SqlUtilities.DefaultConnectionString));

      container.RegisterType<ICategoryTypesRepository, CategoryTypesRepository>();
      container.RegisterType<ICurrenciesRepository, CurrenciesRepository>();
      container.RegisterType<ICategoriesRepository, CategoriesRepository>();
      container.RegisterType<ITransactionsRepository, TransactionsRepository>();
      container.RegisterType<IAccountsRepository, AccountsRepository>();
      container.RegisterType<IPeriodsRepository, PeriodsRepository>();
      container.RegisterType<IAccountTypesRepository, AccountTypesRepository>();
      container.RegisterType<UserAccountsController>(new InjectionConstructor());

      config.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}