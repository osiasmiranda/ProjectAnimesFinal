// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Infrastructure.Context;

namespace RedeSocial.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        //private readonly UserManager<IdentityUser> _userManager;//ProfileEntity
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<ProfileEntity> _userManager;
        private readonly SignInManager<ProfileEntity> _signInManager;
        private readonly IFileService _fileService;

        public IndexModel(
            UserManager<ProfileEntity> userManager,
            SignInManager<ProfileEntity> signInManager, IFileService fileService)
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileService = fileService;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Sobrenome")]
            public string LastName { get; set; }


            [Required]
            [Display(Name = "Data de Aniversário")]
            [DataType(DataType.Date)]
            public DateTime BirthOfDay { get; set; }

            [Phone]
            [Display(Name = "Telefone")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.Upload)]
            [Display(Name = "Foto do perfil")]
            public string ProfileUrlImage { get; set; }

        }

        //private async Task LoadAsync(IdentityUser user)
        private async Task LoadAsync(ProfileEntity user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;



            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthOfDay = (DateTime)user.BirthOfDay,
                ProfileUrlImage = user.ProfileUrlImage

            };

            if (user.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(user.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "O arquivo não pôde ser salvo!";
                }
                var imageName = fileResult.Item2;
                user.ProfileUrlImage = imageName;
            }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }


            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }

            if (Input.BirthOfDay != user.BirthOfDay)
            {
                user.BirthOfDay = Input.BirthOfDay;
            }

            if(Input.ProfileUrlImage != user.ProfileUrlImage)
            {
                user.ProfileUrlImage = Input.ProfileUrlImage;

            }


            await _userManager.UpdateAsync(user);


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seu perfil foi atualizado.";
            return RedirectToPage();
        }
    }
}
