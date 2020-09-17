using System;
using System.Collections.Generic;
using System.Linq;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Extensions;
using TCGPrimus.Entities.Models;

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


        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll()
                .OrderBy(ow => ow.AccountType);
        }

        public Account GetAccountById(Guid accountId)
        {
            return FindByCondition(Account => Account.Id.Equals(accountId))
                .DefaultIfEmpty(new Account())
                .FirstOrDefault();
        }

        
        public void CreateAccount(Account account)
        {
            account.Id = Guid.NewGuid();
            Create(account);
            Save();
        }

        public void UpdateAccount(Account dbAccount, Account account)
        {            
            dbAccount.Map(account);
            Update(dbAccount);
            Save();
        }

        public void DeleteAccount(Account Account)
        {
            Delete(Account);
            Save();
        }
    }
}
