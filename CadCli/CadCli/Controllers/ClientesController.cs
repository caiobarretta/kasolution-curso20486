using CadCli.Data;
using CadCli.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Controllers
{
    public class ClientesController : Controller
    {
        private CadCliDataContext _ctx = new CadCliDataContext();

        public ViewResult Index()
        {
            //var clientes = new List<Cliente>()
            //{
            //    new Cliente() { Id = 1, Nome = "Fabiano", Idade = 39},
            //    new Cliente() { Id = 2, Nome = "Priscila", Idade = 40},
            //    new Cliente() { Id = 3, Nome = "Raphael", Idade = 19},
            //    new Cliente() { Id = 4, Nome = "Isabel", Idade = 61},
            //    new Cliente() { Id = 5, Nome = "Nair", Idade = 70}
            //};

            var clientes = _ctx.Clientes.ToList();
            return View(clientes);
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Cliente cli)
        {
            _ctx.Clientes.Add(cli);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
