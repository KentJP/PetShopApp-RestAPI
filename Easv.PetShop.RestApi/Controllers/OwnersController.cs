using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService.IService;
using PetShopApp.Core.Entity;

namespace Easv.PetShop.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }


        // GET: api/Owner
      //  [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_ownerService.GetFilteredOwners(filter));
                //return _ownerService.ReadAllOwners();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/Owner/5
       // [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return _ownerService.ReadOwnerById(id);


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
}

        // POST: api/Owner
      //  [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if(string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("Please enter a firstname for the owner");
            }
            if(string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("Please enter a lastname for the owner");
            }
            if(string.IsNullOrEmpty(owner.Email) && string.IsNullOrEmpty(owner.PhoneNumber))
            {
                return BadRequest("Please enter either a phonenumber or email for contact purposes");
            }
            if(string.IsNullOrEmpty(owner.Address))
            {
                return BadRequest("Please enter an address for contact  purposes");
            }
            else
            {
                return _ownerService.CreateOwner(owner);
            }        
        }

        // PUT: api/Owner/5
     //   [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            try
            {
                owner.Id = id;
                return _ownerService.UpdateOwner(owner);
            }
            catch (Exception)
            {

                return BadRequest("Could create owner with a name containing \"");
                
            }
     
        }

        // DELETE: api/ApiWithActions/5
      //  [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                return _ownerService.DeleteOwner(id);
                

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
