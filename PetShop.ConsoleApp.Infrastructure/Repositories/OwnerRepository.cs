using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {

        readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public Owner CreateOwner(Owner owner)
        {
            var own = _ctx.Attach(owner).State = EntityState.Added;
            _ctx.Entry(owner).Collection(o => o.Pets).IsModified = true;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int inputId)
        {
            var ownerRemoved = _ctx.Remove( new Owner() { Id = inputId }).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }

        public IEnumerable<Owner> ReadAllOwners(Filter filter)
        {
            if(filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _ctx.Owners;
            }
            return _ctx.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);

        }

        public Owner ReadOwnerById(int id)
        {
            if (_ctx.Owners.Any(o => o.Id == id))
            {

                return _ctx.Owners.Include(o => o.Pets ).FirstOrDefault(o => o.Id == id);

            }
            else
            {
                throw new Exception("Could not find ant pets with the given Id = " + id);
            }

        }

        public Owner UpdateOwner(Owner updatedOwner)
        {
            var own = _ctx.Attach(updatedOwner).State = EntityState.Modified;
            _ctx.Entry(updatedOwner).Collection(o => o.Pets).IsModified = true;
            _ctx.SaveChanges();
            return updatedOwner;
        }
    }
}
