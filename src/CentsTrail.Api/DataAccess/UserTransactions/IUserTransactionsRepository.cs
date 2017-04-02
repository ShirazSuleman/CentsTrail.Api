using CentsTrail.Api.Models.UserTransactions;
using CentsTrail.Api.Models.UserTransactions.AddUserTransaction;
using CentsTrail.Api.Models.UserTransactions.GetUserTransactionSummary;
using CentsTrail.Api.Models.UserTransactions.SearchUserTransactions;
using CentsTrail.Api.Models.UserTransactions.UpdateUserTransaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentsTrail.Api.DataAccess.UserTransactions
{
  public interface IUserTransactionsRepository
  {
    Task<long> AddUserTransaction(string userId, AddUserTransactionRequest request);

    Task<bool> DeleteUserTransaction(string userId, long userTransactionId);

    Task<IEnumerable<UserTransaction>> SearchUserTransactions(string userId, SearchUserTransactionsRequest request);

    Task<IEnumerable<UserTransactionSummary>> GetUserTransactionSummary(string userId, GetUserTransactionSummaryRequest request);

    Task<UserTransaction> GetUserTransaction(string userId, long userTransactionId);

    Task<bool> UpdateUserTransaction(string userId, long userTransactionId, UpdateUserTransactionRequest request);
  }
}
