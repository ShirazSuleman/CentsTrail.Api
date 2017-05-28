using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.AccountTypes;

namespace CentsTrail.Api.DataAccess.AccountTypes
{
  public interface IAccountTypesRepository
  {
    Task<IEnumerable<AccountType>> GetAccountTypes();

    Task<AccountType> GetAccountType(int accountTypeId);
  }
}
