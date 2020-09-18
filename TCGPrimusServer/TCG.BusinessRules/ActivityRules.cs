using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;

namespace TCG.BusinessRules
{
    public class ActivityRules : RulesBase
    {
        public IEnumerable<ActivityExtended> GetAll()
        {
            var activities = _dbContext.Activities;
            return activities.Select(c => new ActivityExtended(c));
        }

        public ActivityExtended GetById(int id)
        {
            return new ActivityExtended(_dbContext.Activities.Find(id));
        }

    }
}
