using HospitalSystem.BLL.ModelVM.Account;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HospitalSystem.PLL.Controllers
{
    // role for (admin ,user)

  //  [Authorize (Roles ="Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<Patient> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<Patient> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var _users = await _userManager.Users.ToListAsync();
            return View(_users);
        }

        public async Task<IActionResult> addRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            var allRoles = await _roleManager.Roles.ToListAsync();
            if (allRoles != null)
            {
                var roleList = allRoles.Select(r => new RoleVM()
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRoles.Any(x => x == r.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = userId;
                return View(roleList);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId, string jsonRoles)
        {
            var user = await _userManager.FindByIdAsync(userId);

            List<RoleVM> myRoles =JsonConvert.DeserializeObject<List<RoleVM>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.roleName.Trim());
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _userManager.AddToRoleAsync(user, role.roleName.Trim());
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
