using System;
using System.Collections.Generic;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(Guid accountId);       
        void CreateAccount(Account owner);
        void UpdateAccount(Account dbAccount, Account account);
        void DeleteAccount(Account account);
    }
}
