using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers
{
    public class CursosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            return View(id);
        }
    }
}