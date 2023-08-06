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
        public IActionResult List(SearchListViewModel model)
        {
            var viewModel = new ItemsListViewModel()
            {
                //Accessories
                //Clothes
                //Shoes
                //Outerwear
            };
            return View(model); 
        } 
    }
}
