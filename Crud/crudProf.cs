using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoEscolar.Banco;
using ProjetoEscolar.Models;
using System.Data;

namespace ProjetoEscolar.Crud
{
    public class crudProf
    {
        conexao con = new conexao();
        public void insert(modelProf cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbProfessor (nomeProf) values (@nomeProf)", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@nomeProf", MySqlDbType.VarChar).Value = cm.nomeProf;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void update(modelProf cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbProfessor set nomeProf=@nomeProf where codProf=@codProf", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codProf", MySqlDbType.VarChar).Value = cm.codProf;
            cmd.Parameters.Add("@nomeProf", MySqlDbType.VarChar).Value = cm.nomeProf;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbProfessor", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Prof = new DataTable();
            da.Fill(Prof);
            con.MyDesConectarBD();
            return Prof;
        }

    }
}