using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using ProjetoEscolar.Crud;
using ProjetoEscolar.Models;

namespace ProjetoEscolar.Controllers
{
    public class AdministrativoController : Controller
    {
        modelProf modP = new modelProf();
        modelAluno modA = new modelAluno();
        crudProf crudP = new crudProf();
        crudAluno crudA = new crudAluno();
        
        // GET: Administrativo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadastrarAluno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarAluno(FormCollection form)
        {
            modA.nomeAluno = form["txtNmAluno"];
            modA.telAluno = form["txtTelAluno"];
            crudA.insert(modA);
            ViewBag.Messagem = "Cadastro Efetuado com sucesso";
            return View();
        }
        public ActionResult CadastrarProf()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarProf(FormCollection form)
        {
            modP.nomeProf = form["txtNmProf"];
            crudP.insert(modP);
            ViewBag.Messagem = "Cadastro Efetuado com sucesso";
            return View();
        }
        public ActionResult AtuAluno()
        {
            carregarTodosAlunos();
            return View();
        }
        [HttpPost]
        public ActionResult atuAluno(FormCollection form)
        {
            modA.codAluno = Request["aluno"];
            modA.nomeAluno = form["txtNmAluno"];
            modA.telAluno = form["txtTelAluno"];
            crudA.update(modA);
            ViewBag.Messagem = "Atualizado com sucesso Efetuado com sucesso";
            carregarTodosAlunos();
            return View();
        }

        public ActionResult AtuProf()
        {
            carregarTodosProfessor();
            return View();
        }
        [HttpPost]
        public ActionResult atuProf(FormCollection form)
        {
            modP.codProf = Request["professor"];
            modP.nomeProf = form["txtNmProf"];
            crudP.update(modP);
            ViewBag.Messagem = "Atualizado com sucesso Efetuado com sucesso";
            carregarTodosProfessor();
            return View();
        }

        public ActionResult ConsultarAluno()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = crudA.read(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }
        public ActionResult ConsultarProf()
        {
            GridView dgv = new GridView();
            dgv.DataSource = crudP.read();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw); 
            ViewBag.GridViewString = sw.ToString(); 
            return View();
        }
        public void carregarTodosProfessor()
        {
            List<SelectListItem> professor = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdEscola;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbProfessor", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    professor.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.professor = new SelectList(professor, "Value", "Text");
        }
        public void carregarTodosAlunos()
        {
            List<SelectListItem> aluno = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdEscola;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAluno", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    aluno.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.aluno = new SelectList(aluno, "Value", "Text");
        }
    }
}