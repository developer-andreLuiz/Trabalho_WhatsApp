using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp.Model;
using Trabalho_WhatsApp.Service;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmResposta : Form
    {

        #region Variaveis
        List<Tb_aparelho_Model> ListaAparelho = new List<Tb_aparelho_Model>();
        List<string> ListaApagar = new List<string>();

        WhatsApp whatsapp = new WhatsApp();
        WhatsAppBusiness business = new WhatsAppBusiness();
        Contatos contatos = new Contatos();

        string mensagem_Sair = string.Empty;
        string mensagem_Informacao = string.Empty;

        int timeLoop = 0;

        bool processo = false;

        //variaveis de interface
        int aparelhos_habilitados = 0;
        int mensagens_recebidas = 0;
        int contatos_bloqueados = 0;

        int aparelhoId = 0;
        string evento = string.Empty;
        string telefone = string.Empty;
        string status = "Livre";
        
        #endregion


        #region Funções
        void Verificacao()
        {
            processo = true;
            status = "Em Verificação";
            foreach (var aparelho in ListaAparelho)
            {
                ListaApagar = new List<string>();


                if (whatsapp.Abrir_App(aparelho.udid, aparelho.versao) == true)
                {
                    whatsapp.Abrir_App(aparelho.udid, aparelho.versao);
                    whatsapp.ResolverBackupTermos();
                    while (whatsapp.Total_Conversas() > 0)
                    {
                        if (whatsapp.Entrar_Conversa_Pendente() == true)
                        {
                            mensagens_recebidas++;
                            aparelhoId = aparelho.id;
                            var conversas = whatsapp.Retornar_Conversas();
                            foreach (var frase in conversas)
                            {
                                if (frase.Contains("SOMOS O MERCADO TITTIO") == false)
                                {
                                    if (frase.Contains("SAIR") == true)
                                    {
                                        whatsapp.Digitar_Mensagem(mensagem_Sair);
                                        whatsapp.Clicar_Enviar();
                                        string nome_contato = whatsapp.Clicar_Perfil();
                                        AddLista(nome_contato, ListaApagar);
                                        whatsapp.Scroll(200, 500, 0, 0);
                                        string numero_contato = whatsapp.DescobrirNumero();
                                        evento = "Sair";
                                        telefone = numero_contato;
                                        Banco.Tb_contato.Desabilitar(numero_contato);
                                        whatsapp.Clicar_Voltar_Compartilhar_Perfil();
                                        whatsapp.Clicar_Voltar();
                                    }
                                    else
                                    {
                                        evento = "Informação";
                                        telefone = string.Empty;
                                        whatsapp.Digitar_Mensagem(mensagem_Informacao);
                                        whatsapp.Clicar_Enviar();
                                        whatsapp.Clicar_Voltar();
                                    }


                                    break;
                                }
                            }

                        }
                        else
                        {
                            whatsapp.Selecionar_Conversas();
                            whatsapp.Clicar_Apagar_Conversas_Lixeira();
                            whatsapp.Clicar_Confirmar_Apagar();
                        }
                    }
                    whatsapp.Fechar();
                }


                if (business.Abrir_App(aparelho.udid, aparelho.versao) == true)
                {
                    business.Abrir_App(aparelho.udid, aparelho.versao);
                    business.ResolverBackupTermos();
                    while (business.Total_Conversas() > 0)
                    {
                        if (business.Entrar_Conversa_Pendente() == true)
                        {
                            mensagens_recebidas++;
                            aparelhoId = aparelho.id;
                            var conversas = business.Retornar_Conversas();
                            foreach (var frase in conversas)
                            {
                                if (frase.Contains("SOMOS O MERCADO TITTIO") == false)
                                {
                                    if (frase.Contains("SAIR") == true)
                                    {
                                        business.Digitar_Mensagem(mensagem_Sair);
                                        business.Clicar_Enviar();
                                        string nome_contato = business.Clicar_Perfil();
                                        AddLista(nome_contato, ListaApagar);
                                        business.Scroll(200, 500, 0, 0);
                                        string numero_contato = business.DescobrirNumero();
                                        evento = "Sair";
                                        telefone = numero_contato;
                                        Banco.Tb_contato.Desabilitar(numero_contato);
                                        business.Clicar_Voltar_Compartilhar_Perfil();
                                        business.Clicar_Voltar();
                                    }
                                    else
                                    {
                                        evento = "Informação";
                                        telefone = string.Empty;
                                        business.Digitar_Mensagem(mensagem_Informacao);
                                        business.Clicar_Enviar();
                                        business.Clicar_Voltar();
                                    }


                                    break;
                                }
                            }

                        }
                        else
                        {
                            business.Selecionar_Conversas();
                            business.Clicar_Apagar_Conversas_Lixeira();
                            business.Clicar_Confirmar_Apagar();
                        }
                    }
                    business.Fechar();
                }


                if (ListaApagar.Count > 0)
                {
                    if (contatos.Abrir_App(aparelho.udid, aparelho.versao) == true)
                    {
                        contatos.Clicar_Pesquisar();

                        foreach (var item in ListaApagar)
                        {
                            contatos.Digitar_Nome(item);
                            contatos.Clicar_Contato_Encontrado();
                            contatos.Clicar_Opcoes();
                            contatos.Clicar_Opcoes_Excluir();
                            contatos.Clicar_Confirmar_Excluir();
                            contatos.Clicar_LimparPesquisa();
                        }
                        contatos.Fechar();
                    }
                    ListaApagar = new List<string>();
                }

            }
            status = "Livre";
            processo = false;
        }
        void AddLista(string nome,List<string>Lista)
        {
            bool continuar = true;
            if (nome.Substring(0,1).Equals("C")==false)
            {
                continuar = false;
            }
            if (continuar == true)
            {
                foreach (var item in Lista)
                {
                    if (item.Equals(nome))
                    {
                        continuar = false;
                        break;
                    }
                }
            }
            if (continuar == true)
            {
                contatos_bloqueados++;
                Lista.Add(nome);
            }


         
        }
        void EncerrarThread()
        {
            foreach (var item in Global.Lista_threads)
            {
                if (item.Name.Equals("Verificacao"))
                {   try
                    {
                        item.Abort();
                    }
                    catch { }
                    Global.Lista_threads.Remove(item);
                    processo = false;
                    break;
                }
            }
          
        }
        #endregion


        #region Eventos
        public FrmResposta()
        {
            InitializeComponent();
            ListaAparelho = Banco.Tb_aparelho.RetornoCompletoHabilitado();
            aparelhos_habilitados = ListaAparelho.Count();
            txtMensagemSair.Text = Banco.Tb_mensagem.GetSair();
            txtMensagemInformacao.Text = Banco.Tb_mensagem.GetInformacao();
            mensagem_Sair = txtMensagemSair.Text;
            mensagem_Informacao = txtMensagemInformacao.Text;
            timeLoop = int.Parse(nUD.Value.ToString());
            timerEvento.Interval = (timeLoop * 60) * 1000;
        }
        private void timerInterface_Tick(object sender, EventArgs e)
        {
            lblAparelhosHabilitados.Text = aparelhos_habilitados.ToString();
            lblMensagensRecebidas.Text = mensagens_recebidas.ToString();
            lblContatosBloqueados.Text = contatos_bloqueados.ToString();

            lblAparelhoId.Text = aparelhoId.ToString();
            lblEvento.Text = evento;
            lblTelefone.Text = telefone;
            lblStatus.Text = status;
            if (lblStatus.Text.Equals("Livre"))
            {
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
            }

            
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtMensagemSair.Text.Length > 0 && txtMensagemInformacao.Text.Length > 0)
            {
                Banco.Tb_mensagem.Atualizar(txtMensagemSair.Text,1);
                Banco.Tb_mensagem.Atualizar(txtMensagemInformacao.Text, 2);
                MessageBox.Show("Salvo", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Digite a mensagem de sair e de informação antes de salvar!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            mensagem_Sair = txtMensagemSair.Text;
            mensagem_Informacao = txtMensagemInformacao.Text;
        }
        private void btnIniciarRespostas_Click(object sender, EventArgs e)
        {

            if (processo == false && timerEvento.Enabled == false)
            {
                timeLoop = int.Parse(nUD.Value.ToString());
                timerEvento.Interval = (timeLoop * 60) * 1000;
                btnIniciarRespostas.Enabled = false;
                timerEvento.Enabled = true;
                Thread thread = new Thread(Verificacao);
                thread.Name = "Verificacao";
                thread.Start();
                Global.Lista_threads.Add(thread);
                MessageBox.Show("Verificação iniciada", "Verificação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEncerrarRespostas_Click(object sender, EventArgs e)
        {
            if (processo)
            {
                DialogResult d = MessageBox.Show("No momento esta em acontecendo o processo de verificação, mesmo assim deseja Encerrar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d==DialogResult.Yes)
                {
                    timerEvento.Enabled = false;
                    btnIniciarRespostas.Enabled = true;
                    status = "Livre";
                    processo = false;
                    EncerrarThread();
                    MessageBox.Show("Todo processo foi encerrado","Finalizado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                timerEvento.Enabled = false;
                btnIniciarRespostas.Enabled = true;
                status = "Livre";
                processo = false;
                EncerrarThread();
                MessageBox.Show("Todo processo foi encerrado", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            
        }
        private void FrmResposta_FormClosed(object sender, FormClosedEventArgs e)
        {
            EncerrarThread();
        }
        private void nUD_ValueChanged(object sender, EventArgs e)
        {
            timeLoop = int.Parse(nUD.Value.ToString());
            timerEvento.Interval = (timeLoop * 60) * 1000;
        }
        private void timerEvento_Tick(object sender, EventArgs e)
        {
            if (processo == false)
            {
                EncerrarThread();

                Thread thread = new Thread(Verificacao);
                thread.Name = "Verificacao";
                thread.Start();
                Global.Lista_threads.Add(thread);
            }
        }



        #endregion

      
    }
}
