using System.Linq;
using System.Collections.Generic;
using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class ActivityExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ActivityFieldExtended> ActivityFields { get; set; }

        public ActivityExtended()
        {
        }

        public ActivityExtended(Activity activity)
        {
            Id = activity.Id;
            Name = activity.Name;
            ActivityFields = activity.ActivityFields.Select(f => new ActivityFieldExtended
            {
                DataType = f.DataType,
                Id = f.Id,
                Label = f.Label,
                MaxLength = f.MaxLength,
                MinLength = f.MinLength,
                Name = f.Name,
                Required = f.Required

            }).ToList();
        }
    }
}
