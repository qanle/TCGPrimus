using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Models;
using System;
using System.Collections.Generic;

namespace TCGPrimus.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId));
        }
    }
}
