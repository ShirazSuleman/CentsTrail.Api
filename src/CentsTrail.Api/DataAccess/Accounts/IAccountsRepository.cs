using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Accounts;
using CentsTrail.Api.Models.Accounts.AddAccount;
using CentsTrail.Api.Models.Accounts.UpdateAccount;

namespace CentsTrail.Api.DataAccess.Accounts
{
  public interface IAccountsRepository
  {
    Task<long> AddAccount(string userId, AddAccountRequest request);

    Task<bool> DeleteAccount(string userId, long accountId);

    Task<IEnumerable<Account>> GetAccounts(string userId);

    Task<Account> GetAccount(string userId, long accountId);

    Task<bool> UpdateAccount(string userId, long accountId, UpdateAccountRequest request);
  }
}
