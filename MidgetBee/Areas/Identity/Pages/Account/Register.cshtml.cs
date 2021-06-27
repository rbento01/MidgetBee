using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

using MidgetBee.Data;
using MidgetBee.Models;

namespace MidgetBee.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class RegisterModel : PageModel {
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        /// <summary>
        /// Possui a referência à BD do nosso sistema
        /// </summary>
        private readonly AnimeDB _context;


        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="logger"></param>
        /// <param name="emailSender"></param>
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            //SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            //IEmailSender emailSender,
            AnimeDB context) {
            _userManager = userManager;
            //_signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
            _context = context;
        }

        /// <summary>
        /// Model usado para transportar os dados para a interface de 'Registar'
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// serve para redirecionar o utilizador para o 'local' de origem
        /// </summary>
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Classe usada para transportar/recolher os dados da Página para dentro do código
        /// </summary>
        public class InputModel {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// Ao anexar um objeto deste tipo ao 'InpuModel' estamos a 
            /// permitir a recolha dos dados do Utilizador
            /// </summary>
            //public Utilizadores Utilizador { get; set; }
        }



        public void OnGet(string returnUrl = null) {
            ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        /// <summary>
        /// este método é acedido se a página devolver o controlo em HTTP POST é este método que cria o novo utilizador
        /// </summary>
        /// <param name="returnUrl">'link' para reposicionar o utilizador para a página que desejava ir</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
            // não preciso de especificar uma variável de adição de dados da 'view'
            // a este método, pq essa variável já está previamente definida no
            // atributo 'Input'
            //   public InputModel Input { get; set; }

            // se o 'returnUrl' for null, é-lhe atribuído um URL
            // se não for Null, nada é feito
            returnUrl ??= Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid) {
                var user = new IdentityUser {
                    UserName = Input.Email,  //username
                    Email = Input.Email, // email do utilizador
                    EmailConfirmed = false, // o email não está confirmado
                    LockoutEnabled = true // o utilizador pode ser bloqueado
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded) {
                    _logger.LogInformation("User created a new account with password.");

                    /************************************************************************
                     Dá agora ao inicio da operação de guardar os dados do Criador
                     ***********************************************************************
                     Preparar os dados do Criador para serem adicionados à BD 
                     **********************************************************************/

                    Utilizadores utilizador = new Utilizadores {
                        Email = user.Email,
                        UserNameID = user.Id
                    };

                    if (Input.Email == "admin@admin.pt") {
                        // atribuir ao user o role "Admin"
                        await _userManager.AddToRoleAsync(user, "Admin");

                    } else {
                        // atribuir ao user o role "Cliente"
                        await _userManager.AddToRoleAsync(user, "Cliente");

                    }

                    // Tentativa de colocar os dados na BD
                    try {

                        // guardar os dados na BD
                        await _context.AddAsync(utilizador);

                        // consolidar a operação de guardar
                        await _context.SaveChangesAsync();

                        // já não há nada a fazer,
                        // redirecionar para a página de confirmação de criação de conta
                        return RedirectToPage("Login");
                    } catch (Exception) {
                        // houve um erro na criação de um Criador
                        // Apresenta uma mensagem de erro
                        ModelState.AddModelError("", "Something wrong happened...");
                        //  Apaga o user que foi previamente criado
                        await _userManager.DeleteAsync(user);

                        // devolver os dados à página
                        return Page();
                    }

                    /*var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }*/
                }

                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
