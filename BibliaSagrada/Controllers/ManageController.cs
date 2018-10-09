using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliaSagrada.Models;
using BibliaSagrada.Models.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliaSagrada.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ManageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ManageController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ValidateCookie()
        {
            var _user = await _userManager.GetUserAsync(HttpContext.User);
            var bibleUserDetail = await _context.BibleUsers.FirstOrDefaultAsync(_ => _.ApplicationUserId == _user.Id);

            var result = new
            {
                email = _user.Email,
                checkInline = bibleUserDetail.Inline,
                rangeValue = bibleUserDetail.NumbersVercicle
            };
            return Ok(result);
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
            var _numberVercicles = _context.BibleUsers.Where(_ => _.ApplicationUserId == userId.Id);
            var userLogins = await _userManager.GetLoginsAsync(userId);
            var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var otherLogins = schemes.Where(auth => userLogins.All(ul => auth.Name != ul.LoginProvider)).ToList();
            return Ok(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins,
                NumbersVercicle = _numberVercicles.FirstOrDefault().NumbersVercicle,
                InlineVercicle = _numberVercicles.FirstOrDefault().Inline
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