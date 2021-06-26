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
                        versao = dataRow["versao"].ToString(),
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
                comando.CommandText = "insert into tb_aparelho (versao, whatsapp, business, email, udid, habilitado) values (@versao, @whatsapp, @business, @email, @udid, @habilitado);";
                comando.Parameters.AddWithValue("versao", objLocal.versao);
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
                comando.CommandText = "update tb_aparelho set versao = @versao, whatsapp = @whatsapp, business = @business, email = @email, udid = @udid, habilitado = @habilitado where id = @id;";
                comando.Parameters.AddWithValue("id", objLocal.id);
                comando.Parameters.AddWithValue("versao", objLocal.versao);
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
            public static List<Tb_contato_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_contato_Model> listaFinal = new List<Tb_contato_Model>();
                string strgComando = "select * from tb_contato order by id asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_contato_Model contato = new Tb_contato_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        telefone = dataRow["telefone"].ToString(),
                        codigo_estado = dataRow["codigo_estado"].ToString(),
                        codigo_municipio = dataRow["codigo_municipio"].ToString(),
                        codigo_bairro = dataRow["codigo_bairro"].ToString(),
                        interacao = int.Parse(dataRow["interacao"].ToString()),
                        habilitado = int.Parse(dataRow["habilitado"].ToString())

                    };
                    listaFinal.Add(contato);
                }
                return listaFinal;
            }
            public static Tb_contato_Model Retorno(string telefoneLocal)
            {
                Tb_contato_Model tb_ContatosFinal = new Tb_contato_Model();

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                object a = tb_ContatosFinal;

                MySqlCommand cmd = new MySqlCommand("select * from tb_contato where telefone = @telefone", conexao);
                cmd.Parameters.AddWithValue("telefone", telefoneLocal);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToString(dr["telefone"]).Equals(telefoneLocal))
                    {
                        tb_ContatosFinal.id = Convert.ToInt32(dr["id"]);
                        tb_ContatosFinal.telefone = Convert.ToString(dr["telefone"]);
                        tb_ContatosFinal.codigo_estado = Convert.ToString(dr["codigo_estado"]);
                        tb_ContatosFinal.codigo_municipio = Convert.ToString(dr["codigo_municipio"]);
                        tb_ContatosFinal.codigo_bairro = Convert.ToString(dr["codigo_bairro"]);
                        tb_ContatosFinal.habilitado = Convert.ToInt32(dr["habilitado"]);
                        tb_ContatosFinal.interacao = Convert.ToInt32(dr["interacao"]);
                        break;
                    }
                }
                dr.Close();
                return tb_ContatosFinal;

            }
            public static void Inserir(Tb_contato_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_contato (telefone, codigo_estado, codigo_municipio, codigo_bairro, interacao, habilitado) values (@telefone, @codigo_estado, @codigo_municipio, @codigo_bairro, @interacao, @habilitado);";
                comando.Parameters.AddWithValue("telefone", objLocal.telefone);
                comando.Parameters.AddWithValue("codigo_estado", objLocal.codigo_estado);
                comando.Parameters.AddWithValue("codigo_municipio", objLocal.codigo_municipio);
                comando.Parameters.AddWithValue("codigo_bairro", objLocal.codigo_bairro);
                comando.Parameters.AddWithValue("interacao", objLocal.interacao);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);

                comando.ExecuteNonQuery();
            }
            public static void Atualizar(Tb_contato_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_contato set telefone = @telefone, codigo_estado = @codigo_estado, codigo_municipio = @codigo_municipio, codigo_bairro = @codigo_bairro, interacao = @interacao, habilitado = @habilitado where id = @id;";
                comando.Parameters.AddWithValue("id", objLocal.id);
                comando.Parameters.AddWithValue("telefone", objLocal.telefone);
                comando.Parameters.AddWithValue("codigo_estado", objLocal.codigo_estado);
                comando.Parameters.AddWithValue("codigo_municipio", objLocal.codigo_municipio);
                comando.Parameters.AddWithValue("codigo_bairro", objLocal.codigo_bairro);
                comando.Parameters.AddWithValue("interacao", objLocal.interacao);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);
                comando.ExecuteNonQuery();
            }
            public static void Deletar(Tb_contato_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_contato where id = @id;";
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
                comando.CommandText = "truncate table tb_contato;";
                comando.ExecuteNonQuery();
            }
        }
        public class Tb_contato_email
        {
            public static List<Tb_contato_email_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_contato_email_Model> listaFinal = new List<Tb_contato_email_Model>();
                string strgComando = "select * from tb_contato_email order by id asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_contato_email_Model contato_email = new Tb_contato_email_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        telefone = dataRow["telefone"].ToString(),
                        enviado = int.Parse(dataRow["enviado"].ToString()),
                        habilitado = int.Parse(dataRow["habilitado"].ToString())

                    };
                    listaFinal.Add(contato_email);
                }
                return listaFinal;
            }
            public static Tb_contato_email_Model Retorno(string telefoneLocal)
            {
                Tb_contato_email_Model tb_contatos_emailFinal = new Tb_contato_email_Model();

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                object a = tb_contatos_emailFinal;

                MySqlCommand cmd = new MySqlCommand("select * from tb_contato_email where telefone = @telefone", conexao);
                cmd.Parameters.AddWithValue("telefone", telefoneLocal);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToString(dr["telefone"]).Equals(telefoneLocal))
                    {
                        tb_contatos_emailFinal.id = Convert.ToInt32(dr["id"]);
                        tb_contatos_emailFinal.telefone = Convert.ToString(dr["telefone"]);
                        tb_contatos_emailFinal.enviado = Convert.ToInt32(dr["enviado"]);
                        tb_contatos_emailFinal.habilitado = Convert.ToInt32(dr["habilitado"]);
                        break;
                    }
                }
                dr.Close();
                return tb_contatos_emailFinal;

            }
            public static void Inserir(Tb_contato_email_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_contato_email (telefone, enviado, habilitado) values (@telefone, @enviado, @habilitado);";
                comando.Parameters.AddWithValue("telefone", objLocal.telefone);
                comando.Parameters.AddWithValue("enviado", objLocal.enviado);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);
                comando.ExecuteNonQuery();
            }
            public static void Atualizar(Tb_contato_email_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "update tb_contato_email set telefone = @telefone, enviado = @enviado, habilitado = @habilitado where id = @id;";
                comando.Parameters.AddWithValue("id", objLocal.id);
                comando.Parameters.AddWithValue("telefone", objLocal.telefone);
                comando.Parameters.AddWithValue("enviado", objLocal.enviado);
                comando.Parameters.AddWithValue("habilitado", objLocal.habilitado);
                comando.ExecuteNonQuery();
            }
            public static void Deletar(Tb_contato_email_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "delete from tb_contato_email where id = @id;";
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
                comando.CommandText = "truncate table tb_contato_email;";
                comando.ExecuteNonQuery();
            }
        }
        public class Tb_estado
        {
            public static List<Tb_estado_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_estado_Model> listaFinal = new List<Tb_estado_Model>();
                string strgComando = "select * from tb_estado order by nome asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_estado_Model estado = new Tb_estado_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        codigo = dataRow["codigo"].ToString(),
                        nome = dataRow["nome"].ToString()
                    };
                    listaFinal.Add(estado);
                }
                return listaFinal;
            }
            public static void Inserir(Tb_estado_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_estado (codigo, nome) values (@codigo, @nome);";
                comando.Parameters.AddWithValue("codigo", objLocal.codigo);
                comando.Parameters.AddWithValue("nome", objLocal.nome);
                comando.ExecuteNonQuery();
            }
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_estado;";
                comando.ExecuteNonQuery();
            }
        }
        public class Tb_municipio
        {
            public static List<Tb_municipio_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_municipio_Model> listaFinal = new List<Tb_municipio_Model>();
                string strgComando = "select * from tb_municipio order by nome asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_municipio_Model municipio = new Tb_municipio_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        codigo = dataRow["codigo"].ToString(),
                        nome = dataRow["nome"].ToString(),
                        codigo_estado = dataRow["codigo_estado"].ToString()
                    };
                    listaFinal.Add(municipio);
                }
                return listaFinal;
            }
            public static void Inserir(Tb_municipio_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_municipio (codigo, nome, codigo_estado) values (@codigo, @nome, @codigo_estado);";
                comando.Parameters.AddWithValue("codigo", objLocal.codigo);
                comando.Parameters.AddWithValue("nome", objLocal.nome);
                comando.Parameters.AddWithValue("codigo_estado", objLocal.codigo_estado);
                comando.ExecuteNonQuery();
            }
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_municipio;";
                comando.ExecuteNonQuery();
            }
        }
        public class Tb_bairro
        {
            public static List<Tb_bairro_Model> RetornoCompleto()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                List<Tb_bairro_Model> listaFinal = new List<Tb_bairro_Model>();
                string strgComando = "select * from tb_bairro order by nome asc;";
                MySqlCommand comando = new MySqlCommand(strgComando, conexao);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(comando);
                DataTable dtLista = new DataTable();
                sqlDataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Tb_bairro_Model bairro = new Tb_bairro_Model()
                    {
                        id = int.Parse(dataRow["id"].ToString()),
                        codigo = dataRow["codigo"].ToString(),
                        nome = dataRow["nome"].ToString(),
                        codigo_estado = dataRow["codigo_estado"].ToString(),
                        codigo_municipio = dataRow["codigo_municipio"].ToString()
                    };
                    listaFinal.Add(bairro);
                }
                return listaFinal;
            }
            public static void Inserir(Tb_bairro_Model objLocal)
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "insert into tb_bairro (codigo, nome, codigo_estado, codigo_municipio) values (@codigo, @nome, @codigo_estado, @codigo_municipio);";
                comando.Parameters.AddWithValue("codigo", objLocal.codigo);
                comando.Parameters.AddWithValue("nome", objLocal.nome);
                comando.Parameters.AddWithValue("codigo_estado", objLocal.codigo_estado);
                comando.Parameters.AddWithValue("codigo_municipio", objLocal.codigo_municipio);
                comando.ExecuteNonQuery();
            }
            public static void Truncate()
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                MySqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "truncate table tb_bairro;";
                comando.ExecuteNonQuery();
            }
        }
    }
}

















