using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturas.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _rolesManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _rolesManager = roleManager;
        }

        public ActionResult Index()
        {

            var role = _rolesManager.Roles.ToList();

            return View(role);
        }


        public IActionResult Create()
        {
            return View(new IdentityRole());
        }


        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            try
            {
                await _rolesManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

    }
}
