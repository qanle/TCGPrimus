using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IActivityRepository : IRepositoryBase<Activity>
    {
        IEnumerable<Activity> GetAllActivities();
        Activity GetActivityById(int activityId);
    }
}
