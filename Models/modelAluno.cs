using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Models
{
    public class modelAluno
    {
        public string codAluno { get; set; }
        public string nomeAluno { get; set; }
        public string telAluno { get; set; }
    }
}