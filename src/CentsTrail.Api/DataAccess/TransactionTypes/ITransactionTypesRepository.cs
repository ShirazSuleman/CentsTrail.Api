using System.Collections.Generic;
using System.Threading.Tasks;
using CentsTrail.Api.Models.TransactionTypes;

namespace CentsTrail.Api.DataAccess.TransactionTypes
{
  public interface ITransactionTypesRepository
  {
    Task<IEnumerable<TransactionType>> GetTransactionTypes();

    Task<TransactionType> GetTransactionType(int transactionTypeId);
  }
}