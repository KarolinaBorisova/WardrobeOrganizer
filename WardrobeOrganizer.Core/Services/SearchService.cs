using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Infrastructure.Data.Common;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IRepository repo;

        public SearchService(IRepository _repo)
        {
                repo = _repo;
        }

        public IEnumerable<string> GetAllCategories()
        {
            var list = new List<string>();

            foreach (string item in Enum.GetNames(typeof(CategoryClothes)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryOuterwear)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryShoes)))
            {
                list.Add(item);
            }
            foreach (string item in Enum.GetNames(typeof(CategoryAccessories)))
            {
                list.Add(item);
            }
            return list;          
        }

        public IEnumerable<string> GetAllClothesSizes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllColors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAllShoeSizes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAllShoeSizesinCm()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAllSizesByAges()
        {
            throw new NotImplementedException();
        }
    }
}
