using PetShopApp.Core.ApplicationService.IService;
using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Service
{
    public class PetShopService : IPetShopService
    {
        readonly IPetShopRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;
        

        public PetShopService(IPetShopRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        public Pet CreateNewPetServ(Pet newPet)
        {
            DateTime dateReference = new DateTime();

            if (string.IsNullOrEmpty(newPet.name))
            {
                throw new Exception("Please enter a name for the pet");
            }
            if (string.IsNullOrEmpty(newPet.type))
            {
                throw new Exception("Please assign the type of pet");
            }
            if (newPet.birthdate != dateReference && newPet.soldDate != dateReference)
            { 
                if(DateTime.Compare(newPet.soldDate, newPet.birthdate) < 0)
                {
                    throw new Exception("Can not create a pet whose sold date is before its birthdate");
                }
            }
            return _petRepo.CreateNewPetRepo(newPet);
             
        }

        public Pet DeletePetServ(int id)
        {  
            return _petRepo.DeletePetRepo(id);
        }

        public List<Pet> GetAllPetsServ()
        {
            return _petRepo.GetAllPetsRepo().ToList();

        }
        public List<Pet> GetAllPetsLprice()
        {
            return _petRepo.GetAllPetsRepo().OrderBy(pet => pet.price).ToList();
        }
        
        public List<Pet> GetAllPetsHprice()
        {
            return _petRepo.GetAllPetsRepo().OrderByDescending(pet => pet.price).ToList();

        }

        public List<Pet> GetFiveCheapesPets()
        {
            var list = _petRepo.GetAllPetsRepo();
            var filteredList = list.OrderBy(p => p.price).Take(5).ToList();
            return filteredList;
        }

        public List<Pet> RetrieveFilteredList(string searchInput)
        {
            var list = _petRepo.GetAllPetsRepo();
            var filteredList = list.Where(pet => pet.type.Equals(searchInput, StringComparison.OrdinalIgnoreCase));
            filteredList.OrderBy(pet => pet.id);

            return filteredList.ToList();
        }

        public Pet RetrievePetById(int input)
        {
            var pet = _petRepo.RetrievePetByIdRepo(input);
            return pet;
        }

        public Pet UpdatePetInfoServ(Pet petUpdate)
        {
            
            return _petRepo.UpdatePetInfoRepo(petUpdate);
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            return _petRepo.GetAllPetsRepo(filter).ToList();
        }
    }
}
