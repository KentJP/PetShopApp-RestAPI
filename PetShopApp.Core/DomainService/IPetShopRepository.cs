using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.DomainService
{
    public interface IPetShopRepository
    {
        IEnumerable<Pet> GetAllPetsRepo(Filter filter = null);
        Pet CreateNewPetRepo(Pet newPet);
        Pet DeletePetRepo(int id);
        Pet RetrievePetByIdRepo(int input);
        Pet UpdatePetInfoRepo(Pet petUpdate);
    }
}
