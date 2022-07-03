using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {
            try{
                DatabaseService dbs = new DatabaseService();
                dbs.CadastraInteresse(cad);
                //ViewData["Mensagem"] = "Cadastro realizado com sucesso!";

                return Json( new { status="OK" } );

            }catch(Exception e){
                _logger.LogError("Erro ao gravar no banco" + e.Message);
                //ViewData["Mensagem"] = "Erro ao cadastrar. Tente mais tarde.";
                return Json( new { status="ERROR", mensagem="Falha ao Cadastrar!" } );
            }
            
            //return View("Index",cad);
        }

    }
}
