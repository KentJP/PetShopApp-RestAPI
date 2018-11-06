using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);
        IEnumerable<Owner> ReadAllOwners(Filter filter = null);
        Owner ReadOwnerById(int id);
        Owner UpdateOwner(Owner updatedOwner);
        Owner DeleteOwner(int id);

    }
}
