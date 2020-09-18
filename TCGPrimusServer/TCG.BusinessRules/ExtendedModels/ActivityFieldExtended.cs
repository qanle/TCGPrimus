using TCG.Models;

namespace TCG.BusinessRules.ExtendedModels
{
    public class ActivityFieldExtended
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string DataType { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
        public bool? Required { get; set; }
        public ActivityExtended Activity { get; set; }

        public ActivityFieldExtended()
        {
        }

        public ActivityFieldExtended(ActivityField activityField)
        {
            Id = activityField.Id;
            Name = activityField.Name;
            Label = activityField.Label;
            DataType = activityField.DataType;
            MaxLength = activityField.MaxLength;
            MinLength = activityField.MinLength;
            Required = activityField.Required;
            Activity = new ActivityExtended
            {
                Id = activityField.Activity.Id,
                Name = activityField.Activity.Name
            };
        }
    }
}
