using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Search;

namespace WardrobeOrganizer.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService _searchService)
        {
            this.searchService = _searchService;
                
        }
        public async Task<IActionResult> Index()
        {
            var model = new SearchIndexViewModel
            {
                //size
                //color
               Colors = await searchService.GetAllColors(),
               Categories = searchService.GetAllCategories(),
               ShoeSizesEu = await searchService.GetAllShoeSizes(),
               SizeByAges = await searchService.GetAllSizesByAges(),
               ClothesSizes = await searchService.GetAllClothesSizes(),
            };


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List(SearchListViewModel model)
        {
            var clothes = await searchService.GetAllFilteredItems(model);

            var viewModel = new ItemsListViewModel()
            {
                //Accessories
                //Clothes = await searchService.GetAllFilteredItems(model)
                //Shoes
                //Outerwear
                Items = clothes,
            };
            return View(viewModel); 
        } 
    }
}
