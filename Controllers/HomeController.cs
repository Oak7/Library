using LibraryMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC5.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Verifica as credenciais do usuário
            if (username == "gabriela.carvalho" && password == "7777")
            {
                // Redireciona para a página de livros após o login bem-sucedido
                return RedirectToAction("Books", "Books");
            }

            // Se as credenciais estiverem incorretas, retorna para a página de login com uma mensagem de erro
            ViewBag.ErrorMessage = "Usuário ou senha incorretos.";
            return View();
        }

        public ActionResult Books()
        {
            var books = new List<BookModel>
            {
        new BookModel { Title = "Código Limpo: Habilidades Práticas do Agile Software",
            Category = "Engenharia de Software",
            Author = "Robert C. Martin",
            ISBN = "9788576082675",
            PublicationYear = 2008,
            IsAvailableForRental = true
            },

        new BookModel { Title = "Python para Análise de Dados: Tratamento de Dados com Pandas, NumPy e IPython",
            Category = "Data Science",
            Author = "Wes McKinney",
            ISBN = "9788575225462",
            PublicationYear = 2013,
            IsAvailableForRental = false
            },




        };

            return View(books);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}