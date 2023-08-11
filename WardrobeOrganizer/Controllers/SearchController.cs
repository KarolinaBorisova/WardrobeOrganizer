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

        public async Task<IActionResult> AllClothes()
        {

            var viewModel = new ClothesListViewModel()
            {
                Items = await searchService.AllItems("clothes", User.Id()),
                Colors = await searchService.GetAllColors(),
                ClothesSizes = await searchService.GetAllClothesSizes(),
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
             
            };
            return View(viewModel);
            
        }
        public async Task<IActionResult> AllAccessories()
        {

            var viewModel = new AccessoriesListViewModel()
            {

                Items = await searchService.AllItems("accessories", User.Id()),
                Colors = await searchService.GetAllColors(),
                SizeByAges = await searchService.GetAllSizesByAges(),
                model = new SearchBySizeAgeViewModel()
                {
                    SizeByAges = await searchService.GetAllSizesByAges()
                }
            };
            return View(viewModel);

        }

        public async Task<IActionResult> AllOuterwears()
        {

            var viewModel = new OuterwearListViewModel()
            {

                Items = await searchService.AllItems("outerwear", User.Id()),
                Colors = await searchService.GetAllColors(),
                ClothesSizes = await searchService.GetAllClothesSizes(),
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
            };
            return View(viewModel);

        }

        public async Task<IActionResult> AllShoes()
        {

            var viewModel = new ShoesListViewModel()
            {

                Items = await searchService.AllItems("shoes", User.Id()),
                Colors = await searchService.GetAllColors(),
                ShoeSizesEu = await searchService.GetAllShoeSizes(),
                model = new SearchByShoesSizeViewModel()
                {
                    ShoeSizesEu = await searchService.GetAllShoeSizes()
                }
            };
            return View(viewModel);

        }

        public async Task<IActionResult> AllClothesFromCategory(string category)
        {

            var viewModel = new ClothesListViewModel()
            {
                Items = await searchService.AllClothesByCategory(category, User.Id()),
                ClothesSizes = await searchService.GetAllClothesSizes(),
                Colors = await searchService.GetAllColors(),
                Category = category,
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
            };
            return View(viewModel);

        }
        public async Task<IActionResult> AllOuterwearFromCategory(string category)
        {

            var viewModel = new OuterwearListViewModel()
            {
                Items = await searchService.AllOuterwearByCategory(category, User.Id()),     
                ClothesSizes = await searchService.GetAllClothesSizes(),
                Colors= await searchService.GetAllColors(),
                Category=category,
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
            };
            return View(viewModel);

        }
        public async Task<IActionResult> AllShoesFromCategory(string category)
        {

            var viewModel = new ShoesListViewModel()
            {
                Items = await searchService.AllShoesByCategory(category, User.Id()),
                ShoeSizesEu = await searchService.GetAllShoeSizes(),
                Colors = await searchService.GetAllColors(),
                Category = category,
                model = new SearchByShoesSizeViewModel()
                {
                    ShoeSizesEu = await searchService.GetAllShoeSizes()
                }
            };
            return View(viewModel);

        }

        public async Task<IActionResult> AllAccessoriesFromCategory(string category)
        {

            var viewModel = new AccessoriesListViewModel()
            {
                Items = await searchService.AllAccessoriesByCategory(category, User.Id()),
                SizeByAges = await searchService.GetAllSizesByAges(),
                Colors = await searchService.GetAllColors(),
                Category=category,
                model = new SearchBySizeAgeViewModel()
                {
                    SizeByAges = await searchService.GetAllSizesByAges()
                }
            };
            return View(viewModel);

        }
     
        [HttpGet]
        public async Task<IActionResult> AllItemsFromColor(SearchByColorViewModel model)
        {
            
            var viewModel = new ItemsListViewModel()
            {
                Items = await searchService.GetAllItemsByColor(model, User.Id())
            };
            return View(viewModel); 
        }
        
        public async Task<IActionResult> AllClothesBySizeAndCategory(SearchByClothesSizeViewModel model)
        {
            var viewModel = new ClothesListViewModel()
            {
                Category = model.Category,
                Items = await searchService.GetClothesBySizeAndCategory(model, User.Id(),model.Category),
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AllOuterwearsBySize(SearchByClothesSizeViewModel model)
        {
            var viewModel = new OuterwearListViewModel()
            {
                Items = await searchService.GetOuterwearsBySize(model, User.Id()),
                model = new SearchByClothesSizeViewModel()
                {
                    ClothesSizes = await searchService.GetAllClothesSizes()
                }
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AllAccessoriesBySize(SearchBySizeAgeViewModel model)
        {
            var viewModel = new AccessoriesListViewModel()
            {
                Items = await searchService.GetAccessoriesBySize(model, User.Id()),
                model = new SearchBySizeAgeViewModel()
                {
                    SizeByAges = await searchService.GetAllSizesByAges()
                }
            };
            return View(viewModel);
        }

        public async Task<IActionResult> AllShoesBySize(SearchByShoesSizeViewModel model)
        {
            var viewModel = new ShoesListViewModel()
            {
                Items = await searchService.GetShoesBySize(model, User.Id()),
                model = new SearchByShoesSizeViewModel()
                {
                    ShoeSizesEu = await searchService.GetAllShoeSizes()
                }
            };
            return View(viewModel);
        }
    }
}
