using MySql.Data.MySqlClient;
using ProjetoEscolar.Banco;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Crud
{
    public class crudAluno
    {
        conexao con = new conexao();
        public void insert(modelAluno cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbAluno (nomeAluno,telAluno) values (@nomeAluno,@telAluno);", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@nomeAluno", MySqlDbType.VarChar).Value = cm.nomeAluno;
            cmd.Parameters.Add("@telAluno", MySqlDbType.VarChar).Value = cm.telAluno;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void update(modelAluno cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbAluno set nomeAluno=@nomeAluno, telAluno=@telAluno where codAluno=@codAluno;", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;
            cmd.Parameters.Add("@nomeAluno", MySqlDbType.VarChar).Value = cm.nomeAluno;
            cmd.Parameters.Add("@telAluno", MySqlDbType.VarChar).Value = cm.telAluno;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbAluno", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Aluno = new DataTable();
            da.Fill(Aluno);
            con.MyDesConectarBD();
            return Aluno;
        }

    }
}