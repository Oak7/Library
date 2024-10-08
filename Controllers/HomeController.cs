﻿using LibraryMVC5.Models;
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


        private List<BookModel> GetBooks()
        {
            return new List<BookModel>
        {
            new BookModel {
                Title = "Código Limpo: Habilidades Práticas do Agile Software",
                Category = "Engenharia de Software", Author = "Robert C. Martin",
                ISBN = "9788576082675",
                PublicationYear = 2008,
                IsAvailableForRental = true,
                ImageUrl = "codigo_limpo.jpg" },

            new BookModel {
                Title = "Python para Análise de Dados",
                Category = "Data Science",
                Author = "Wes McKinney",
                ISBN = "9788575225462",
                PublicationYear = 2013,
                IsAvailableForRental = true,
                ImageUrl = "python.jpg" },

            new BookModel {
                Title = "Use a Cabeça! Java",
                Category = "Java",
                Author = "Kathy Sierra, Bert Bates",
                ISBN = "9788576081739",
                PublicationYear = 2005,
                IsAvailableForRental = true,
                ImageUrl = "java.jpg" },

            new BookModel {
                Title = "Aprendendo Node.js",
                Category = "Desenvolvimento Web",
                Author = "Shelly Powers",
                ISBN = "9788575224533",
                PublicationYear = 2014,
                IsAvailableForRental = true,
                ImageUrl = "node.jpg" },

            new BookModel {
                Title = "Estruturas de Dados e Algoritmos com JavaScript",
                Category = "Algoritmos",
                Author = "Loiane Groner",
                ISBN = "9788575227183",
                PublicationYear = 2018,
                IsAvailableForRental = true,
                ImageUrl = "Ed.jpg" },

            new BookModel {
                Title = "Introdução à Programação com Python",
                Category = "Python",
                Author = "Nilo Ney Coutinho Menezes",
                ISBN = "9788575224144",
                PublicationYear = 2016,
                IsAvailableForRental = true,
                ImageUrl = "intPython.jpg" },

            new BookModel {
                Title = " Algoritmos: Teoria e Prática",
                Category = "Algoritmos",
                Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                ISBN = "9788535210989",
                PublicationYear = 2009,
                IsAvailableForRental = true,
                ImageUrl = "algoritmos.jpg" },
        };
        }

        //public ActionResult Books()
        //{
        //    var books = GetBooks();
        //    return View(books);
        //}
        public ActionResult Books(string searchTerm = null)
        {
            // Obtém a lista completa de livros
            var books = GetBooks();

            // Se o termo de pesquisa não estiver vazio, filtra a lista de livros
            if (!string.IsNullOrEmpty(searchTerm))
            {
                books = books
                    .Where(b => b.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            return View(books);
        }

        //public ActionResult Detalhes(string isbn)
        //{
        //    var books = GetBooks();
        //    var book = books.FirstOrDefault(b => b.ISBN == isbn);

        //    if (book == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(book);
        //}

        public ActionResult Detalhes(string isbn)
        {
            var books = GetBooks();
            var book = books.FirstOrDefault(b => b.ISBN == isbn);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }



}