using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliaSagrada.Models;
using BibliaSagrada.Models.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BibliaSagrada.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ManageController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ValidateCookie()
        {
            var userEmail = (await _userManager.GetUserAsync(HttpContext.User))?.Email;
            return Ok(userEmail);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = await _userManager.GetUserAsync(HttpContext.User);
            IdentityResult result = await _userManager.ChangePasswordAsync(userId, model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                AddErrors(result);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ManageLogins()
        {
            var userId = await _userManager.GetUserAsync(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await _userManager.GetLoginsAsync(userId);
            var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var otherLogins = schemes.Where(auth => userLogins.All(ul => auth.Name != ul.LoginProvider)).ToList();
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}