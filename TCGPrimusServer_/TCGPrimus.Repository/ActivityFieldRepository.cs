using System.Collections.Generic;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Repository
{
    internal class ActivityFieldRepository : RepositoryBase<ActivityField>, IActivityFieldRepository
    {

        public ActivityFieldRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ActivityField> GetActivityFieldsByActivityId(int activityId)
        {
            return FindByCondition(a => a.ActivityId.Equals(activityId));
        }
    }
}