﻿using CentsTrail.Api.TransactionTypes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentsTrail.Api.DataAccess.TransactionTypes
{
  public interface ITransactionTypesRepository
  {
    Task<IEnumerable<TransactionType>> GetTransactionTypes();

    Task<TransactionType> GetTransactionType(int transactionTypeId);
  }
}