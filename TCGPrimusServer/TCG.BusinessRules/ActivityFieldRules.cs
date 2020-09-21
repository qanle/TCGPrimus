using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;

namespace TCG.BusinessRules
{
    public class ActivityFieldRules : RulesBase
    {
        public IEnumerable<ActivityFieldExtended> GetAll()
        {
            var fields = _dbContext.ActivityFields;
            return fields.Select(c => new ActivityFieldExtended(c));
        }

        public ActivityFieldExtended GetById(int id)
        {
            return new ActivityFieldExtended(_dbContext.ActivityFields.Find(id));
        }

        public IEnumerable<ActivityFieldExtended> GetByActivityId(int activityId)
        {
            var fields = _dbContext.ActivityFields.Where(a => a.Activity.Id == activityId);
            return fields.Select(c => new ActivityFieldExtended(c));
        }

        public void CreateActivityField(ActivityField activity)
        {
            
            _dbContext.ActivityFields.Add(activity);
            _dbContext.Entry(activity).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public void UpdateActivityField(ActivityField activityField)
        {
            var dbField = _dbContext.ActivityFields.Find(activityField.Id);
            dbField.Name = activityField.Name;
            dbField.Label = activityField.Label;
            dbField.DataType = activityField.DataType;
            dbField.MaxLength = activityField.MaxLength;
            dbField.MinLength = activityField.MinLength;
            dbField.Required = activityField.Required;

            if (_dbContext.Entry(dbField).State == EntityState.Detached)
                _dbContext.ActivityFields.Attach(dbField);
            _dbContext.Entry(dbField).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteActivityField(int id)
        {
            var activityField = _dbContext.ActivityFields.Find(id);
            _dbContext.ActivityFields.Remove(activityField);
            _dbContext.SaveChanges();
        }
    }
}
