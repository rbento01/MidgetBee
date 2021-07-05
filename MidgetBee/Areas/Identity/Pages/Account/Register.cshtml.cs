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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        /// <summary>
        /// Possui a referência à base de dados
        /// </summary>
        private readonly AnimeDB _context;


        /// <summary>
        /// construtor da classe
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            ILogger<RegisterModel> logger,
            AnimeDB context) {
            _userManager = userManager;
            _logger = logger;
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

        /// <summary>
        /// Classe usada para transportar/recolher os dados da Página para dentro do código
        /// </summary>
        public class InputModel {
            /// <summary>
            /// email que o user inseriu
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            /// password que o user inseriu
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            /// confirmação e comparação com a password que o user inseriu
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }



        public void OnGet(string returnUrl = null) {
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// este método é acedido se a página devolver o controlo em HTTP POST e é este método que cria o novo utilizador
        /// </summary>
        /// <param name="returnUrl">'link' para reposicionar o utilizador para a página que deseja ir</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
            if (ModelState.IsValid) {
                var user = new IdentityUser {
                    UserName = Input.Email,  //username
                    Email = Input.Email, // email do utilizador
                    EmailConfirmed = false, // o email não está confirmado
                    LockoutEnabled = true // o utilizador pode ser bloqueado
                };

                // Cria o user
                var result = await _userManager.CreateAsync(user, Input.Password);

                // se conseguiu criar o user
                if (result.Succeeded) {
                    _logger.LogInformation("User created a new account with password.");

                    //Começo da preparação da inserção dos valores na base de dados

                    // Cria-se um objeto do tipo da classe Utilizadores que vai ter o email que o user inseriu e o ID que vai colocar na base de dados 
                    Utilizadores utilizador = new Utilizadores {
                        Email = user.Email,
                        UserNameID = user.Id,
                        contComment = false
                    };

                    // caso o email inserido tenho sido "admin@admin.pt" cria-se uma conta com um Role de admin
                    if (Input.Email == "admin@admin.pt") {
                        // atribuir ao user o role "Admin"
                        await _userManager.AddToRoleAsync(user, "Admin");

                        // caso tenha sido criado uma conta com outro email, cria-se esse user com o role de Cliente
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

                        // redireciona o user para a página de Login, para proceder a fazer o login da conta recentemente criada
                        return RedirectToPage("Login");

                        // caso tenha sido encontrado um erro na criação do utilizador
                    } catch (Exception) {
                        // apresenta uma mensagem de erro
                        ModelState.AddModelError("", "Something wrong happened...");

                        //  apaga o user que foi recentemente criado
                        await _userManager.DeleteAsync(user);

                        // devolver os dados à página
                        return Page();
                    }
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
