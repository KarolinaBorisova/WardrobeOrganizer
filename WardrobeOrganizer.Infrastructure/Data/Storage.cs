using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Clothing> Clothes { get; set; } = new List<Clothing>();

        public IList<Shoes> Shoes { get; set; } = new List<Shoes>();

        public IList<Outerwear> Outerwear { get; set; } = new List<Outerwear>();

    }
}
