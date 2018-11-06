using PetShopApp.Core.ApplicationService.IService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Service
{
    public class OwnerService : IOwnerService
    {

        readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner CreateOwner(Owner owner)
        {
           return _ownerRepo.CreateOwner(owner);
        }

        public List<Owner> ReadAllOwners()
        {
            return _ownerRepo.ReadAllOwners().ToList();
        }

        public Owner ReadOwnerById(int id)
        {
      
                return _ownerRepo.ReadOwnerById(id);
            
        }

        public Owner UpdateOwner(Owner updatedOwner)
        {
           return _ownerRepo.UpdateOwner(updatedOwner);
        }

        public Owner DeleteOwner(int id)
        {
           return _ownerRepo.DeleteOwner(id);
        }

        public List<Owner> GetFilteredOwners(Filter filter)
        {
            return _ownerRepo.ReadAllOwners(filter).ToList();
        }
    }
 

}
