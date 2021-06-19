using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_WhatsApp.Model;
using System.Data;

namespace Trabalho_WhatsApp
{
    class Banco
    {
        #region Variavel Conexão
        protected static MySqlConnection conexao { get; } = new MySqlConnection("Server= 108.179.252.18; Database=merca467_db_whatsapp;Uid=merca467_sistema;Pwd=sistemavalendo; Connect Timeout = 30;");
        #endregion
        public class Tb_aparelho
        {
            public static List<Tb_aparelho_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_aparelho_Model> listaFinal = new List<Tb_aparelho_Model>();
                string strgComando = "select * from tb_aparelho order by id asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_aparelho_Model newTb_aparelho_Model = new Tb_aparelho_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        whatsapp = dataRow["whatsapp"].ToString(),
                        business = dataRow["business"].ToString(),
                        email = dataRow["email"].ToString(),
                        udid = dataRow["udid"].ToString(),
                        habilitado = int.Parse(dataRow["habilitado"].ToString())

                    };
                    listaFinal.Add(newTb_aparelho_Model);
                }
                return listaFinal;
            }
            
            public static void Inserir(Tb_aparelho_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_aparelho (whatsapp, business, email, udid, habilitado) values (@whatsapp, @business, @email, @udid, @habilitado);";
                comando.Parameters.AddWithValue("whatsapp", objLocal.whatsapp);
                comando.Parameters.AddWithValue("business", objLocal.business);
                comando.Parameters.AddWithValue("email", objLocal.email);
                comando.Parameters.AddWithValue("udid", objLocal.udid);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);
                comando.ExecuteNonQuery();
            }

            public static void Atualizar(Tb_aparelho_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_aparelho set whatsapp = @whatsapp, business = @business, email = @email, udid = @udid, habilitado = @habilitado where id = @id;";
                comando.Parameters.AddWithValue("id", objLocal.id);
                comando.Parameters.AddWithValue("whatsapp", objLocal.whatsapp);
                comando.Parameters.AddWithValue("business", objLocal.business);
                comando.Parameters.AddWithValue("email", objLocal.email);
                comando.Parameters.AddWithValue("udid", objLocal.udid);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);
                comando.ExecuteNonQuery();
            }

            public static void Deletar(Tb_aparelho_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_aparelho where id = @id;";
                comando.Parameters.AddWithValue("id", objLocal.id);
                comando.ExecuteNonQuery();
            }

            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_aparelho;";
                comando.ExecuteNonQuery();
            }

        }
        public class Tb_contato
        {

        }
        public class Tb_contato_email
        {

        }
        public class Tb_estado
        {

        }
        public class Tb_municipio
        {

        }
        public class Tb_bairro
        {

        }
    }
}

















