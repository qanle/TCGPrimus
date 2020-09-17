using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IActivityFieldRepository : IRepositoryBase<ActivityField>
    {
        IEnumerable<ActivityField> GetActivityFieldsByActivityId(int activityId);
    }
}
