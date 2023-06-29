using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WardrobeOrganizer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Administrator")]
    public class BaseController : Controller
    {
       
    }
}
