using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.Transactions;
using CentsTrail.Api.Models.Transactions.AddTransaction;
using CentsTrail.Api.Models.Transactions.GetTransactionSummary;
using CentsTrail.Api.Models.Transactions.SearchTransactions;
using CentsTrail.Api.Models.Transactions.UpdateTransaction;

namespace CentsTrail.Api.DataAccess.Transactions
{
  public interface ITransactionsRepository
  {
    Task<long> AddTransaction(string userId, AddTransactionRequest request);

    Task<bool> DeleteTransaction(string userId, long transactionId);

    Task<IEnumerable<Transaction>> SearchTransactions(string userId, SearchTransactionsRequest request);

    Task<IEnumerable<TransactionSummary>> GetTransactionSummary(string userId,
      GetTransactionSummaryRequest request);

    Task<Transaction> GetTransaction(string userId, long transactionId);

    Task<bool> UpdateTransaction(string userId, long transactionId, UpdateTransactionRequest request);
  }
}