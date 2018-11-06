using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService.IService;
using PetShopApp.Core.Entity;

namespace Easv.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetShopService _petShopService;

        public PetsController(IPetShopService petService)
        {
            _petShopService = petService;
        }

        // GET api/values
        //[Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petShopService.GetFilteredPets(filter));
                //return _petShopService.GetAllPetsServ();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                return Ok(_petShopService.RetrievePetById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        // POST api/values
       // [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
             try
             {
                return _petShopService.CreateNewPetServ(pet);

             }
             catch (Exception ex)
             {

                return BadRequest(ex.Message);
             }     
        }

        // PUT api/values/5
       // [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                pet.id = id;
                return _petShopService.UpdatePetInfoServ(pet);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

      
            
        }

        // DELETE api/values/5
      //  [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
               return _petShopService.DeletePetServ(id);
                
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
                


        }
    }
}
