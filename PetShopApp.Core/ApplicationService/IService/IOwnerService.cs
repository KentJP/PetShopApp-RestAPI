using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService.IService
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        List<Owner> ReadAllOwners();
        Owner ReadOwnerById(int id);
        Owner UpdateOwner(Owner updatedOwner);
        Owner DeleteOwner(int id);
        List<Owner> GetFilteredOwners(Filter filter);
    }
}
