using System;

namespace TCGPrimus.Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }
    }
}
