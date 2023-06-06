using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.Design;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseApiController : Controller
    {

        private readonly IHouseService houseService;
        private readonly IFamilyService familyService;
        private readonly IStorageService storageService;
        


        public HouseApiController(IHouseService _houseService,
            IFamilyService _familyService,
            IStorageService _storageService)
        {
            this.houseService = _houseService;
            this.familyService = _familyService;
            this.storageService = _storageService;
         
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(AllHousesViewModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> All()
        {
           // int familiId = await familyService.GetFamilyId(User.Id());
            var model = await houseService.AllHouses(1);

            return Ok(model);
        }

    }
}
