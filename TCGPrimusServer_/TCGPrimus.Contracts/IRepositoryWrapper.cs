using System;

namespace TCGPrimus.Contracts
{
    public interface IRepositoryWrapper
    {
        IOwnerRepository Owner { get; }
        IAccountRepository Account { get; }

        IActivityFieldRepository ActivityField { get; }
        IActivityRepository Activity { get; }
        IContentRepository Content { get; }
        IWorkFlowRepository WorkFlow { get; }
        IFolderRepository Folder { get; }
    }
}
