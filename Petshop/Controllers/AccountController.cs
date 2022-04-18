//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using ProductShop.Models;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProductShop.Controllers
//{
//    [Produces("application/json")]
//    public class AccountController : Controller
//    {
//        private readonly UserManager<User> _userManager;
//        private readonly SignInManager<User> _signInManager;

//        public AccountController(UserManager<User> userManager,
//        SignInManager<User> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }
//        [HttpPost]
//        [Route("api/Account/Register")]
//        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                User user = new User
//                {
//                    Email = model.Email,
//                    UserName = model.Email
//                };
//                // Добавление нового пользователя
//                var result = await _userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    // установка куки

//                    await _signInManager.SignInAsync(user, false);
//                    await _userManager.AddToRoleAsync(user, "user");

//                    var msg = new
//                    {
//                        message = "Добавлен новый пользователь: " + user.Email
//                    };
//                    return Ok(msg);
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError(string.Empty,
//                        error.Description);
//                    }
//                    var errorMsg = new
//                    {
//                        message = "Пользователь не добавлен.",
//                        error = ModelState.Values.SelectMany(e =>
//                        e.Errors.Select(er => er.ErrorMessage))
//                    };
//                    return Ok(errorMsg);
//                }
//            }
//            else
//            {
//                var errorMsg = new
//                {
//                    message = "Неверные входные данные.",
//                    error = ModelState.Values.SelectMany(e =>
//                    e.Errors.Select(er => er.ErrorMessage))
//                };

//                return Ok(errorMsg);
//            }
//        }
//        [HttpPost]
//        [Route("api/Account/Login")]
//        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
//                if (result.Succeeded)
//                {
//                    var user = await _userManager.FindByEmailAsync(model.Email);
//                    string role = "user";
//                    if (await _userManager.IsInRoleAsync(user, "admin"))
//                    {
//                        role = "admin";
//                    }
//                    var msg = new
//                    {
//                        messange = "Выполнен вход пользователем: " + model.Email,
//                        role = role
//                    };
//                    return Ok(msg);
//                }
//                else
//                {
//                    return StatusCode(403, "Неправильный логин и (или) пароль");
//                }
//            }
//            else
//            {
//                return StatusCode(403, "Вход не выполнен.");
//            }
//        }
//        [HttpPost]
//        [Route("api/Account/LogOff")]
//        public async Task<IActionResult> LogOff()
//        {
//            // Удаление куки
//            await _signInManager.SignOutAsync();
//            var msg = new
//            {
//                message = "Выполнен выход."
//            };
//            return Ok(msg);
//        }
//        [HttpPost]
//        [Route("api/Account/isAuthenticated")]
//        public async Task<IActionResult> LogisAuthenticatedOff()
//        {
//            User user = await GetCurrentUserAsync();
//            var message = user == null ? "" : user.Email;
//            var msg = new
//            {
//                message
//            };
//            return Ok(msg);
//        }

//        [HttpGet]
//        [Route("api/Account/checkRole/")]
//        public async Task<IActionResult> CheckRole([FromBody] string role)
//        {
//            User user = await GetCurrentUserAsync();
//            if (user == null)
//            {
//                return StatusCode(401);
//            }
//            if (await _userManager.IsInRoleAsync(user, role))
//            {
//                return Ok();
//            }
//            else
//            {
//                return StatusCode(404);
//            }
//        }
//        private Task<User> GetCurrentUserAsync() =>
//        _userManager.GetUserAsync(HttpContext.User);
//    }
//}
