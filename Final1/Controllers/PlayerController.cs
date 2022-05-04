using Final1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerRepository _playerRepo;

        public PlayerController(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public IActionResult Index()
        {
            return View(_playerRepo.ReadAll());
        }

        public IActionResult Details(string id)
        {
            var player = _playerRepo.Read(id);
            if (player == null)
            {
                return RedirectToAction("Index");
            }
            return View(player);
        }
    }
}
