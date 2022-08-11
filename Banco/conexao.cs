using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Banco
{
    public class conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; DataBase=bdEscola; User=root;pwd=12345678");
        public static string msg;

        public MySqlConnection MyConectarBD() //Método: MyConectarBD()
        {
            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
        public MySqlConnection MyDesConectarBD()  //Método: MyDesConectarBD()
        {

            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}