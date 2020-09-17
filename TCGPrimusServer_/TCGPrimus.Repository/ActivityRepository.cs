using System.Collections.Generic;
using TCGPrimus.Contracts;
using TCGPrimus.Entities;
using TCGPrimus.Entities.Models;
using System.Linq;

namespace TCGPrimus.Repository
{
    internal class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {

        public ActivityRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Activity GetActivityById(int activityId)
        {
            return FindByCondition(a => a.Id.Equals(activityId))
                .DefaultIfEmpty(new Activity())
                .FirstOrDefault();
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return FindAll()
               .OrderBy(ow => ow.Name);
        }
    }
}