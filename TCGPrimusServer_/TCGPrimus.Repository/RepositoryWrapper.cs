using TCGPrimus.Contracts;
using TCGPrimus.Entities;

namespace TCGPrimus.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        private IActivityFieldRepository _activityField;
        private IActivityRepository _activity;
        private IContentRepository _content;
        private IWorkFlowRepository _workFlow;
        private IFolderRepository _folder;

        public IOwnerRepository Owner
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public IActivityFieldRepository ActivityField
        {
            get
            {
                if (_activityField == null)
                {
                    _activityField = new ActivityFieldRepository(_repoContext);
                }

                return _activityField;
            }
        }

        public IActivityRepository Activity
        {
            get
            {
                if (_activity == null)
                {
                    _activity = new ActivityRepository(_repoContext);
                }

                return _activity;
            }
        }

        public IContentRepository Content
        {
            get
            {
                if (_content == null)
                {
                    _content = new ContentRepository(_repoContext);
                }

                return _content;
            }
        }

        public IWorkFlowRepository WorkFlow
        {
            get
            {
                if (_workFlow == null)
                {
                    _workFlow = new WorkFlowRepository(_repoContext);
                }

                return _workFlow;
            }
        }

        public IFolderRepository Folder
        {
            get
            {
                if (_folder == null)
                {
                    _folder = new FolderRepository(_repoContext);
                }

                return _folder;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
