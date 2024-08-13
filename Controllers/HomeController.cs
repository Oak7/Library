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
                return RedirectToAction("Books", "Home");
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
            IsAvailableForRental = true,
            ImageUrl = "codigo_limpo.jpg" 
            },

        new BookModel { Title = "Python para Análise de Dados",
            Category = "Data Science",
            Author = "Wes McKinney",
            ISBN = "9788575225462",
            PublicationYear = 2013,
            IsAvailableForRental = true,
            ImageUrl = "python.jpg"
            },




        };

            return View(books);
        }

        public ActionResult Detalhes(string id)
        {
            // Simulando a recuperação de um livro do banco de dados com base no ISBN
            var book = new BookModel
            {
                Title = "Código Limpo: Habilidades Práticas do Agile Software",
                Category = "Engenharia de Software",
                Author = "Robert C. Martin",
                ISBN = "9788576082675",
                PublicationYear = 2008,
                IsAvailableForRental = true,
                ImageUrl = "codigo_limpo.jpg"
            };

            // Em um cenário real, você buscaria o livro do banco de dados usando o ISBN
            // var book = dbContext.Books.FirstOrDefault(b => b.ISBN == id);

            if (book == null)
            {
                return HttpNotFound(); // Ou redirecionar para uma página de erro
            }

            return View(book);
        }

    }
}