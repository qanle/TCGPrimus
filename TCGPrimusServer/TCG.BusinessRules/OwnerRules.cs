using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCG.BusinessRules.ExtendedModels;
using TCG.Models;

namespace TCG.BusinessRules
{
    public class OwnerRules : RulesBase
    {
        public List<Owner> GetAll()
        {
            return _dbContext.Owners.ToList();
        }

        public Owner GetById(Guid id)
        {
            return _dbContext.Owners.Find(id);
        }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(GetById(ownerId))
            {
                Accounts = _dbContext.Accounts
                    .Where(a => a.OwnerId == ownerId)
            };
        }

        public void CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _dbContext.Owners.Add(owner);
            _dbContext.Entry(owner).State = EntityState.Added;
            _dbContext.SaveChanges();
        }


        public void UpdateOwner( Owner owner)
        {
            var dbOwner = GetById(owner.Id);
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            dbOwner.DateOfBirth = owner.DateOfBirth;

            if (_dbContext.Entry(dbOwner).State == EntityState.Detached)
                _dbContext.Owners.Attach(dbOwner);
            _dbContext.Entry(dbOwner).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void DeleteOwner(Owner owner)
        {
            var dbOwner = GetById(owner.Id);
            _dbContext.Owners.Remove(dbOwner);
            _dbContext.SaveChanges();
        }
    }
}
