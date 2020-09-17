using TCGPrimus.Entities.Models;

namespace TCGPrimus.Entities.Extensions
{
    public static class EntityExtensions
    {

        public static void Map(this WorkFlow dbWorkflow, WorkFlow workflow)
        {
            dbWorkflow.Name = workflow.Name;
            dbWorkflow.FolderId = workflow.FolderId;
            dbWorkflow.ContentId = workflow.ContentId;
            dbWorkflow.ActivityId = workflow.ActivityId;
            dbWorkflow.ActivitySettings = workflow.ActivitySettings;
        }




















        public static void Map(this Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            dbOwner.DateOfBirth = owner.DateOfBirth;
        }
        public static void Map(this Account dbOwner, Account account)
        {
            dbOwner.AccountType = account.AccountType;
            dbOwner.OwnerId = account.OwnerId;
        }
    }
}
