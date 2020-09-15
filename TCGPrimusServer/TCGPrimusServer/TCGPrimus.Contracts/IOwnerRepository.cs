using System;
using System.Collections.Generic;
using TCGPrimus.Entities.ExtendedModels;
using TCGPrimus.Entities.Models;

namespace TCGPrimus.Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        OwnerExtended GetOwnerWithDetails(Guid ownerId);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner dbOwner, Owner owner);
        void DeleteOwner(Owner owner);
    }
}
