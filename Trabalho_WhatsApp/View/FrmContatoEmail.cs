using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp.Model;
using Trabalho_WhatsApp.Service;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmContatoEmail : Form
    {
        #region Variaveis
        bool novo = false;
        List<Tb_contato_email_Model> ListaContatoEmail;
        #endregion

        #region Funções
        //Interface Layout
        void InterfaceLayoutInicioCancelarGravarDeletar()
        {
            txtTelefone.Enabled = false;
            chkEnviado.Enabled = false;
            chkHabilitado.Enabled = false;
           
            InterfaceBotaoInicioCancelarGravarDeletar();
        }
        void InterfaceLayoutNovoAtualizar()
        {
            txtTelefone.Enabled = true;
            chkEnviado.Enabled = true;
            chkHabilitado.Enabled = true;
          
            InterfaceBotaoNovoAtualizar();
        }
        //Interface Btns
        void InterfaceBotaoInicioCancelarGravarDeletar()
        {
            btnNovo.Enabled = true;
            btnAtualizar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGravar.Enabled = false;
            btnDeletar.Enabled = true;
            btnDeletarTudo.Enabled = true;
        }
        void InterfaceBotaoNovoAtualizar()
        {
            btnNovo.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGravar.Enabled = true;
            btnDeletar.Enabled = true;
            btnDeletarTudo.Enabled = true;
        }
        //Grid
        void CarregarGrid()
        {
            dataGridView.DataSource = null;
            if (ListaContatoEmail.Count > 0)
            {
                dataGridView.DataSource = ListaContatoEmail;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 440;
                dataGridView.Columns[2].Width = 100;
                dataGridView.Columns[3].Width = 100;
                int linha = dataGridView.Rows.Count;
                lblLinhas.Text = linha.ToString();
            }

        }
        //Objetos
        void Exibir(Tb_contato_email_Model objLocal)
        {
            txtId.Text = objLocal.id.ToString();
        
            txtTelefone.Text = objLocal.telefone.ToString();

            if (objLocal.enviado == 1)
            {
                chkEnviado.Checked = true;
            }
            else
            {
                chkEnviado.Checked = false;
            }

            if (objLocal.habilitado == 1)
            {
                chkHabilitado.Checked = true;
            }
            else
            {
                chkHabilitado.Checked = false;
            }
        }
        bool Capturar(Tb_contato_email_Model objLocal)
        {
            bool retorno = true;

            if (txtId.Text.Length > 0)
            {
                objLocal.id = int.Parse(txtId.Text);
            }
            else { retorno = false; }

            if (txtTelefone.Text.Length == 11)
            {
                objLocal.telefone = txtTelefone.Text;
            }
            else { retorno = false; }
            
            if (chkHabilitado.Checked == true)
            {
                objLocal.habilitado = 1;
            }
            else { objLocal.habilitado = 0; }

            if (chkEnviado.Checked == true)
            {
                objLocal.enviado = 1;
            }
            else { objLocal.enviado = 0; }


            return retorno;
        }
        void Limpar()
        {
            txtId.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            chkEnviado.Checked = false;
            chkHabilitado.Checked = false;
        }
        #endregion

        #region Eventos
        public FrmContatoEmail()
        {
            InitializeComponent();
            InterfaceLayoutInicioCancelarGravarDeletar();
            ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
            lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();
            CarregarGrid();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            InterfaceLayoutNovoAtualizar();
            novo = true;
            Limpar();
            txtId.Text = "0";
            txtTelefone.Focus();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Tb_contato_email_Model objLocal = new Tb_contato_email_Model();
            if (Capturar(objLocal) == true)
            {
                InterfaceLayoutNovoAtualizar();
                novo = false;
                txtTelefone.Focus();
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Tb_contato_email_Model objLocal = new Tb_contato_email_Model();
            if (Capturar(objLocal) == true)
            {
                if (novo == true)
                {
                    Banco.Tb_contato_email.Inserir(objLocal);
                    ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
                    Exibir(ListaContatoEmail[ListaContatoEmail.Count - 1]);
                }
                else
                {
                    Banco.Tb_contato_email.Atualizar(objLocal);
                    ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
                    Exibir(ListaContatoEmail.Find(x => x.id == objLocal.id));
                }
                InterfaceLayoutInicioCancelarGravarDeletar();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Verifique as Informações", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InterfaceLayoutInicioCancelarGravarDeletar();
            Limpar();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Tb_contato_email_Model objLocal = new Tb_contato_email_Model();
            if (Capturar(objLocal) == true && objLocal.id > 0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Apagar Registro Selecionado ?", "Apagar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Banco.Tb_contato_email.Deletar(objLocal);
                    ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
                    Limpar();
                    CarregarGrid();
                    InterfaceLayoutInicioCancelarGravarDeletar();
                }
            }
            else
            {
                MessageBox.Show("Registro não Encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeletarTudo_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja Apagar Todos os Contatos do Email ?", "Apagar todos os registros", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                dialog = MessageBox.Show("TEM CERTEZA? TODOS OS CONTATOS DO EMAIL SERÃO APAGADOS", "APAGAR TODOS OS REGISTROS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    Banco.Tb_contato_email.Truncate();
                    ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
                    Limpar();
                    CarregarGrid();
                    InterfaceLayoutInicioCancelarGravarDeletar();
                }
            }
        }
        private void btnLimparListaParaExportar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja Limpar Lista Para Exportar ?", "Limpar Lista", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Global.ListaContatoEmailExportar = new List<string>();
                lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();
            }
        }
        private void btnGrid_Click(object sender, EventArgs e)
        {
            ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
            CarregarGrid();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Global.ListaContatoEmailExportar.Count > 0)
            {
                int valorAntes = ListaContatoEmail.Count;

                foreach (string telefone in Global.ListaContatoEmailExportar)
                {
                    if (Banco.Tb_contato_email.Retorno(telefone).id == 0)
                    {
                        Tb_contato_email_Model novo_contato_email = new Tb_contato_email_Model(telefone);
                        Banco.Tb_contato_email.Inserir(novo_contato_email);
                    }
                }
                ListaContatoEmail = Banco.Tb_contato_email.RetornoCompleto();
                CarregarGrid();

                if (ListaContatoEmail.Count > valorAntes)
                {
                    MessageBox.Show("Números Adicionados", "Tabela Contatos Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Estes Números já estavam na Lista", "Tabela Contatos Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Nenhum Contato Selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tb_contato_email_Model objLocal = new Tb_contato_email_Model();
            objLocal.id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            objLocal.telefone = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            objLocal.enviado = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value);
            objLocal.habilitado = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value);
            Exibir(objLocal);
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (ListaContatoEmail.Count > 0)
            {

                List<string> list = new List<string>();
                foreach (var item in ListaContatoEmail)
                {
                    list.Add(item.telefone);
                }

                if (ExcelService.CreateTableContatosEmail(list) == true)
                {
                    DialogResult dialog = MessageBox.Show("Tabela Criada, Deseja Abrir Local  da Tabela? ", "Concluido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("Explorer.exe", string.Format("/select,\"{0}\"", ExcelService.Path(ExcelService.Contatos_Email)));
                    }

                }
                else
                {
                    MessageBox.Show("Erro ao Criar Tabela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Lista Vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
