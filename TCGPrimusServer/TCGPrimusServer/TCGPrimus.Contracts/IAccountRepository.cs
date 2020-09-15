using System;
using System.Collections.Generic;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}
