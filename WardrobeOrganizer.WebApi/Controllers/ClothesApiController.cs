using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;


namespace WardrobeOrganizer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesApiController : ControllerBase
    {
        private readonly IClothesService clothesService;
        private readonly IFamilyService familyService;

        public ClothesApiController(IClothesService _clothesService,
        IFamilyService _familyService)
        {
            this.clothesService = _clothesService;
            this.familyService = _familyService;
        }
        /// <summary>
        /// Gets all clothes in exact storage
        /// </summary>
        /// <returns>All clothes</returns>

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(AllClothesViewModel))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> All()
        {
            //find strageId
            var model = await clothesService.AllClothes(1040);

            return Ok(model);
        }

        
    }
}
