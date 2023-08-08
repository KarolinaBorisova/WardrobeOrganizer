using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Search;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;
        private readonly UserManager<User> userManager;

        public SearchController(ISearchService _searchService,
            UserManager<User> _userManager)
        {
            this.searchService = _searchService;
            this.userManager = _userManager;
                
        }
        public async Task<IActionResult> Index()
        {

            var model = new SearchIndexViewModel
            {
                //size
                //color
              Colors = await searchService.GetAllColors(),
             // Categories = searchService.GetAllCategories(),
             //ShoeSizesEu = await searchService.GetAllShoeSizes(),
             //SizeByAges = await searchService.GetAllSizesByAges(),
             //ClothesSizes = await searchService.GetAllClothesSizes(),
            };


            return View(model);
        }

        public async Task<IActionResult> AllItemsFromType(string itemType)
        {

            var viewModel = new ItemsListViewModel()
            {
                //Accessories
                //Clothes = await searchService.GetAllFilteredItems(model)  
                //Shoes
                //Outerwear
                Items = await searchService.AllItems(itemType, User.Id()),
                ShoeSizesEu = await searchService.GetAllShoeSizes(),
                SizeByAges = await searchService.GetAllSizesByAges(),
                ClothesSizes = await searchService.GetAllClothesSizes(),
            };
            return View(viewModel);
            
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchListViewModel model)
        {
            
            var viewModel = new ItemsListViewModel()
            {
                //Accessories
                //Clothes = await searchService.GetAllFilteredItems(model)
                //Shoes
                //Outerwear
               // Items = await searchService.GetAllFilteredItems(model, User.Id())
        };
            return View(viewModel); 
        } 
    }
}
