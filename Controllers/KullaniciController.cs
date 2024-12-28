using GuzellikMerkeziYonetimSistemi.Data;
using GuzellikMerkeziYonetimSistemi.Models;
using GuzellikMerkeziYonetimSistemi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Data;

namespace GuzellikMerkeziYonetimSistemi.Controllers
{
	[Authorize]

	public class KullaniciController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly ApplicationDbContext _context;

		public KullaniciController(ApplicationDbContext  context, UserManager<IdentityUser>  userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_context =  context;
		}
		public async Task<ActionResult> Index()
		{
			var users = await _context.Users.ToListAsync();
			return View(users);
		}
		[HttpGet]
		public async Task<ActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(KullaniciViewModel model)
		{
			IdentityUser user = new IdentityUser();
			user.UserName = model.KullaniciAdi;
			user.NormalizedUserName = model.Ad + " " + model.Soyad;
			user.Email = model.Email;
			user.NormalizedEmail = model.Email;
			user.EmailConfirmed = true;
			user.PhoneNumber = model.Telefon;
			user.PhoneNumberConfirmed = true;
			user.TwoFactorEnabled = false;
			user.LockoutEnabled = false;
			user.LockoutEnd = null;
			user.AccessFailedCount = 0;
			user.SecurityStamp = Guid.NewGuid().ToString();

			var result = await _userManager.CreateAsync(user, model.Password);
			return RedirectToAction("Index");
		}

		
	}
}
