using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IMemberService
    { 
        Task<bool> ExistsById(string userId);

        Task Create(string userId);
    }
}
