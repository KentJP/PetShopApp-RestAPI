using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp.Core.ApplicationService.IService
{
    public interface IPetShopService
    {
        List<Pet> GetAllPetsServ();
        List<Pet> GetAllPetsLprice();
        List<Pet> GetAllPetsHprice();
        Pet CreateNewPetServ(Pet newPet);
        List<Pet> RetrieveFilteredList(string searchInput);
        Pet DeletePetServ(int id);
        Pet RetrievePetById(int input);
        Pet UpdatePetInfoServ(Pet petUpdate);
        List<Pet> GetFiveCheapesPets();
        List<Pet> GetFilteredPets(Filter filter);
    }
}
