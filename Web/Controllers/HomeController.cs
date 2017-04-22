using Microsoft.Practices.Unity;
using Repository;
using System.Linq;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        public IUnitOfWork UOW { get; set; }

        public HomeController()
        {
            UOW = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            var listDeUsuario = UOW.UsuarioRepository.ListAll();
            var msg = string.Join(", ",listDeUsuario.Select(x => x.Nome));
            ViewBag.Message = msg;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}