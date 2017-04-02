using CentsTrail.Api.DataAccess.Currencies;
using CentsTrail.Api.DataAccess.TransactionTypes;
using CentsTrail.Api.DataAccess.UserCategories;
using CentsTrail.Api.DataAccess.UserTransactions;
using CentsTrail.Api.Helpers;
using Microsoft.Practices.Unity;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
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

      container.RegisterType<ITransactionTypesRepository, TransactionTypesRepository>();
      container.RegisterType<ICurrenciesRepository, CurrenciesRepository>();
      container.RegisterType<IUserCategoriesRepository, UserCategoriesRepository>();
      container.RegisterType<IUserTransactionsRepository, UserTransactionsRepository>();

      config.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}