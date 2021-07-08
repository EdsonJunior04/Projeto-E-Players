using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipemodel = new Equipe();
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.Equipes = equipemodel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            // novaEquipe.Imagem = form["Imagem"];
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }else
            {
                novaEquipe.Imagem = "padrao.png";
            }

            equipemodel.Criar(novaEquipe);
            ViewBag.Equipes = equipemodel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            equipemodel.Deletar(id);
            ViewBag.Equipes = equipemodel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }   
    }
}