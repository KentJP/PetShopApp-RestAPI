using Microsoft.EntityFrameworkCore;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetShopRepository
    {

            readonly PetShopContext _ctx;

            public PetRepository(PetShopContext ctx)
            {
                _ctx = ctx;
            }


        public Pet CreateNewPetRepo(Pet newPet)
        {
            _ctx.Attach(newPet).State = EntityState.Added;
            _ctx.SaveChanges();
            return newPet;
        }

        public Pet DeletePetRepo(int inputId)
        {
            var petRemove = _ctx.Remove(new Pet() { id = inputId }).Entity;
            _ctx.SaveChanges();
            return petRemove;
        }

        public IEnumerable<Pet> GetAllPetsRepo(Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    return _ctx.Pets;
                }
                else
                {
                    return _ctx.Pets.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
                }
                    
            
              
                

            }
            catch (Exception)
            {

                throw new Exception("Could not retrieve the list of pets");
            }
        }

        public Pet RetrievePetByIdRepo(int input)
        {

            if(_ctx.Pets.Any(p => p.id == input))
            {
                return _ctx.Pets.Include(p => p.previousOwner).FirstOrDefault(p => p.id == input);

            }
            else
            {
                throw new Exception("Could not find ant pets with the given Id = " + input);
            }

        }

        public Pet UpdatePetInfoRepo(Pet petUpdate)
        {
            _ctx.Attach(petUpdate).State = EntityState.Modified;
            _ctx.Entry(petUpdate).Reference(o => o.previousOwner).IsModified = true;
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}
