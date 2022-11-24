using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }

        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.GetById(id);
            return View(user);
        }

        public IActionResult ConfirmRemove(int id)
        {
            UserModel user = _userRepository.GetById(id);
            return View(user);
        }

        public IActionResult Remove(int id)
        {
            try
            {
                bool removed = _userRepository.Remove(id);

                if (removed)
                    TempData["SuccessMessage"] = "User removed successfully";
                else
                    TempData["ErrorMessage"] = "Error when trying to remove user";

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error when trying to remove contact. More details: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Insert(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Insert(user);
                    TempData["SuccessMessage"] = "User successfully registered";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error registering user. More details: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Update(user);
                    TempData["SuccessMessage"] = "User successfully updated";
                    return RedirectToAction("Index");
                }
                return View("Edit", user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Error updating user. More details: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
