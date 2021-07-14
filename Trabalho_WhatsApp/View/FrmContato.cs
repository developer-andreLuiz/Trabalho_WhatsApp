using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_WhatsApp.Model;
using Trabalho_WhatsApp.Service;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmContato : Form
    {
        #region Variaveis
        bool novo = false;
        List<Tb_contato_Model> ListaContato;
        private Form activeForm = null;
        #endregion

        #region Funções
        //Manager
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelCentral.Controls.Add(ChildForm);
            panelCentral.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        //Interface Layout
        void InterfaceLayoutInicioCancelarGravarDeletar()
        {
            txtTelefoneRegistro.Enabled = false;
            cbEstadoRegistro.Enabled = false;
            cbMunicipioRegistro.Enabled = false;
            cbBairroResgistro.Enabled = false;
            chkHabilitadoRegistro.Enabled = false;
            chkInteracaoRegistro.Enabled = false;
            InterfaceBotaoInicioCancelarGravarDeletar();
        }
        void InterfaceLayoutNovoAtualizar()
        {
            txtTelefoneRegistro.Enabled = true;
            cbEstadoRegistro.Enabled = true;
            cbMunicipioRegistro.Enabled = true;
            cbBairroResgistro.Enabled = true;
            chkHabilitadoRegistro.Enabled = true;
            chkInteracaoRegistro.Enabled = true;
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
            btnImportar.Enabled = false;
            btnExportar.Enabled = true;
        }
        void InterfaceBotaoNovoAtualizar()
        {
            btnNovo.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGravar.Enabled = true;
            btnDeletar.Enabled = true;
            btnDeletarTudo.Enabled = true;
            btnImportar.Enabled = true;
            btnExportar.Enabled = true;
        }
       
        //Grid
        void CarregarGridEstado()
        {
            string estado = cbEstadoFiltro.SelectedValue.ToString();
            int habilitadoLocal = 0;
            int interacaoLocal = 0;
            if (chkHabilitadoFiltro.Checked)
            {
                habilitadoLocal = 1;
            }
            if (chkInteracaoFiltro.Checked)
            {
                interacaoLocal = 1;
            }
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();

            foreach (Tb_contato_Model tb_Contatos_Model in ListaContato)
            {
                if (tb_Contatos_Model.codigo_estado.Equals(estado) && tb_Contatos_Model.habilitado == habilitadoLocal && tb_Contatos_Model.interacao == interacaoLocal)
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }

            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }

            lblRegistros.Text = ltTb_Contatos_ModelFiltro.Count.ToString();
        }
        void CarregarGridMunicipio()
        {
            string estado = cbEstadoFiltro.SelectedValue.ToString();
            string municipio = cbMunicipioFiltro.SelectedValue.ToString();
            int habilitadoLocal = 0;
            int interacaoLocal = 0;
            if (chkHabilitadoFiltro.Checked)
            {
                habilitadoLocal = 1;
            }
            if (chkInteracaoFiltro.Checked)
            {
                interacaoLocal = 1;
            }
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();

            foreach (Tb_contato_Model tb_Contatos_Model in ListaContato)
            {
                if (tb_Contatos_Model.codigo_estado.Equals(estado) && tb_Contatos_Model.codigo_municipio.Equals(municipio) && tb_Contatos_Model.habilitado == habilitadoLocal && tb_Contatos_Model.interacao == interacaoLocal)
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }

            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }

            lblRegistros.Text = ltTb_Contatos_ModelFiltro.Count.ToString();
        }
        void CarregarGridBairro()
        {
            string estado = cbEstadoFiltro.SelectedValue.ToString();
            string municipio = cbMunicipioFiltro.SelectedValue.ToString();
            string bairro = cbBairroFiltro.SelectedValue.ToString();
            int habilitadoLocal = 0;
            int interacaoLocal = 0;
            if (chkHabilitadoFiltro.Checked)
            {
                habilitadoLocal = 1;
            }
            if (chkInteracaoFiltro.Checked)
            {
                interacaoLocal = 1;
            }
            dataGridView.DataSource = null;
            List<Tb_contato_Model> ltTb_Contatos_ModelFiltro = new List<Tb_contato_Model>();

            foreach (Tb_contato_Model tb_Contatos_Model in ListaContato)
            {
                if (tb_Contatos_Model.codigo_estado.Equals(estado) && tb_Contatos_Model.codigo_municipio.Equals(municipio) && tb_Contatos_Model.codigo_bairro.Equals(bairro) && tb_Contatos_Model.habilitado == habilitadoLocal && tb_Contatos_Model.interacao == interacaoLocal)
                {
                    ltTb_Contatos_ModelFiltro.Add(tb_Contatos_Model);
                }
            }

            if (ltTb_Contatos_ModelFiltro.Count > 0)
            {
                dataGridView.DataSource = ltTb_Contatos_ModelFiltro;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }
            else
            {
                dataGridView.DataSource = new List<Tb_contato_Model>();
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].HeaderText = "Telefone";
                dataGridView.Columns[2].Width = 295;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
            }

            lblRegistros.Text = ltTb_Contatos_ModelFiltro.Count.ToString();
        }
        void AtualizarGrid()
        {
            if (string.IsNullOrEmpty(cbBairroFiltro.Text) == false)
            {
                CarregarGridBairro();
            }
            else
            {
                if (string.IsNullOrEmpty(cbMunicipioFiltro.Text) == false)
                {
                    CarregarGridMunicipio();
                }
                else
                {
                    if (string.IsNullOrEmpty(cbEstadoFiltro.Text) == false)
                    {
                        CarregarGridEstado();
                    }
                }
            }
        }

        //Objetos
        void Exibir(Tb_contato_Model objLocal)
        {
            txtTelefoneRegistro.Text = objLocal.telefone;
            
            CarregarComboBox(cbEstadoRegistro);
            cbEstadoRegistro.SelectedValue = objLocal.codigo_estado;

            CarregarComboBox(cbMunicipioRegistro,cbEstadoRegistro.SelectedValue.ToString());
            cbMunicipioRegistro.SelectedValue = objLocal.codigo_municipio;

            CarregarComboBox(cbBairroResgistro, cbEstadoRegistro.SelectedValue.ToString(), cbMunicipioRegistro.SelectedValue.ToString());
            cbBairroResgistro.SelectedValue = objLocal.codigo_bairro;

            txtIdRegistro.Text = objLocal.id.ToString();

            if (objLocal.habilitado==1)
            {
                chkHabilitadoRegistro.Checked = true;
            }
            else{ chkHabilitadoRegistro.Checked = false; }

            if (objLocal.interacao == 1)
            {
                chkInteracaoRegistro.Checked = true;
            }
            else { chkInteracaoRegistro.Checked = false; }

        }
        bool Capturar(Tb_contato_Model objLocal)
        {
            bool retorno = true;

            if (txtIdRegistro.Text.Length > 0)
            {
                objLocal.id = int.Parse(txtIdRegistro.Text);
            }
            else { retorno = false; }

            if (txtTelefoneRegistro.Text.Trim().Length == 11)
            {
                objLocal.telefone = txtTelefoneRegistro.Text;
            }
            else { retorno = false; }

            if (cbEstadoRegistro.Text.Length > 0)
            {
                objLocal.codigo_estado = cbEstadoRegistro.SelectedValue.ToString();
            }
            else { retorno = false; }

            if (cbMunicipioRegistro.Text.Length > 0)
            {
                objLocal.codigo_municipio = cbMunicipioRegistro.SelectedValue.ToString();
            }
            else { retorno = false; }

            if (cbBairroResgistro.Text.Length > 0)
            {
                objLocal.codigo_bairro = cbBairroResgistro.SelectedValue.ToString();
            }
            else { retorno = false; }

            if (chkHabilitadoRegistro.Checked == true)
            {
                objLocal.habilitado = 1;
            }
            else { objLocal.habilitado = 0; }

            if (chkInteracaoRegistro.Checked == true)
            {
                objLocal.interacao = 1;
            }
            else { objLocal.interacao = 0; }



            return retorno;
        }
        void Buscar(string t)
        {
            Tb_contato_Model c = new Tb_contato_Model();

            try
            {
                c = ListaContato.Find(x => x.telefone.Equals(t));

            }
            catch { }

            if (c != null)
            {
                Exibir(c);
            }
            else
            {
                Limpar();
                MessageBox.Show("Registro não Encontrado!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Importar()
        {
            Tb_contato_Model tb = new Tb_contato_Model();
            tb.codigo_estado = Convert.ToString(cbEstadoRegistro.SelectedValue);
            tb.codigo_municipio = Convert.ToString(cbMunicipioRegistro.SelectedValue);
            tb.codigo_bairro = Convert.ToString(cbBairroResgistro.SelectedValue);
            tb.habilitado = 1;
            tb.interacao = 0;

            List<string> ltContatosLocal = new List<string>();
          
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                openFileDialog.Dispose();
                string[] conteudo = File.ReadAllLines(path);
                foreach (string numero in conteudo)
                {
                    if (numero.Length == 11)
                    {
                        ltContatosLocal.Add(numero);
                    }
                }
            }

            if (ltContatosLocal.Count > 0)
            {
                foreach (string c in ltContatosLocal)
                {
                    if (Banco.Tb_contato.Retorno(c).id == 0)
                    {
                        tb.telefone = c;
                        Banco.Tb_contato.Inserir(tb);
                    }
                }
               
                ListaContato = Banco.Tb_contato.RetornoCompleto();
            }
        }
        void Limpar()
        {
            txtTelefoneRegistro.Text = string.Empty;

            cbEstadoRegistro.DataSource = null;
            cbEstadoRegistro.Text = string.Empty;
            cbEstadoRegistro.DataSource = new List<string>();

            cbMunicipioRegistro.DataSource = null;
            cbMunicipioRegistro.Text = string.Empty;
            cbMunicipioRegistro.DataSource = new List<string>();

            cbBairroResgistro.DataSource = null;
            cbBairroResgistro.Text = string.Empty;
            cbBairroResgistro.DataSource = new List<string>();

            chkHabilitadoRegistro.Checked = true;
           
            chkInteracaoRegistro.Checked = false;

            txtIdRegistro.Text = "0";
        }
        void CarregarComboBox(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "codigo";
            List<Tb_estado_Model> ltEstadoCompletoLocal = new List<Tb_estado_Model>();
            foreach (Tb_estado_Model temp in Global.ListaEstado)
            {
                ltEstadoCompletoLocal.Add(temp);
            }
            cb.DataSource = ltEstadoCompletoLocal;
        }
        void CarregarComboBox(ComboBox cb, string estado)
        {
            List<Tb_municipio_Model> ltMunicipioFiltro = new List<Tb_municipio_Model>();
            foreach (Tb_municipio_Model tb_Municipio_Model in Global.ListaMunicipio)
            {
                if (tb_Municipio_Model.codigo_estado.ToUpper().Equals(estado.ToUpper()))
                {
                    ltMunicipioFiltro.Add(tb_Municipio_Model);
                }
            }
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "codigo";
            cb.DataSource = ltMunicipioFiltro;
        }
        void CarregarComboBox(ComboBox cb, string estado, string municipio)
        {
            List<Tb_bairro_Model> ltBairroFiltro = new List<Tb_bairro_Model>();

            foreach (Tb_bairro_Model tb_Bairro_Model in Global.ListaBairro)
            {
                if (tb_Bairro_Model.codigo_estado.ToUpper().Equals(estado.ToUpper()) && tb_Bairro_Model.codigo_municipio.ToUpper().Equals(municipio.ToUpper()))
                {
                    ltBairroFiltro.Add(tb_Bairro_Model);
                }
            }
            cb.DataSource = null;
            cb.DisplayMember = "nome";
            cb.ValueMember = "codigo";
            cb.DataSource = ltBairroFiltro;
        }
        void SelecionarComboBoacu(ComboBox estado, ComboBox municipio, ComboBox bairro)
        {
            estado.SelectedValue = "33";
            municipio.SelectedValue = "3304904";
            bairro.SelectedValue = "3304904003";
        }

        //Atualizar Listas
        void BaixarListas()
        {
            if (Global.ListaEstado.Count==0)
            {
                Global.ListaEstado = Banco.Tb_estado.RetornoCompleto();
            }
            if (Global.ListaMunicipio.Count == 0)
            {
                Global.ListaMunicipio = Banco.Tb_municipio.RetornoCompleto();
            }
            if (Global.ListaBairro.Count == 0)
            {
                Global.ListaBairro = Banco.Tb_bairro.RetornoCompleto();
            }
            ListaContato = Banco.Tb_contato.RetornoCompleto();
        }

        #endregion

        #region Eventos
        
        //Load Form
        public FrmContato()
        {
            InitializeComponent();
            BaixarListas();
            Limpar();
            InterfaceLayoutInicioCancelarGravarDeletar();
            CarregarComboBox(cbEstadoFiltro);
            SelecionarComboBoacu(cbEstadoFiltro,cbMunicipioFiltro,cbBairroFiltro);
            lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();
        }
        public FrmContato(string telefoneLocal)
        {
            InitializeComponent();
            BaixarListas();
            Limpar();
            InterfaceLayoutInicioCancelarGravarDeletar();
            CarregarComboBox(cbEstadoFiltro);
            SelecionarComboBoacu(cbEstadoFiltro, cbMunicipioFiltro, cbBairroFiltro);
            txtTelefoneFiltro.Text = telefoneLocal;
            Buscar(telefoneLocal);
            lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();
        }

        //Filtro
        private void cbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstadoFiltro.Text) == false)
            {
                CarregarGridEstado();
                CarregarComboBox(cbMunicipioFiltro, Convert.ToString(cbEstadoFiltro.SelectedValue));
            }
        }
        private void btnEstadoBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstadoFiltro.Text) == false)
            {
                CarregarGridEstado();
            }
        }
        private void cbMunicipioFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMunicipioFiltro.Text) == false)
            {
                CarregarGridMunicipio();
                CarregarComboBox(cbBairroFiltro, Convert.ToString(cbEstadoFiltro.SelectedValue), Convert.ToString(cbMunicipioFiltro.SelectedValue));
            }
        }
        private void btnMunicipioBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMunicipioFiltro.Text) == false)
            {
                CarregarGridMunicipio();
            }
        }
        private void cbBairroFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBairroFiltro.Text) == false)
            {
                CarregarGridBairro();
            }
        }
        private void btnBairroBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBairroFiltro.Text) == false)
            {
                CarregarGridBairro();
            }
        }
        private void chkHabilitadoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
        private void chkInteracaoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        //Registro
        private void btnNovo_Click(object sender, EventArgs e)
        {
            InterfaceLayoutNovoAtualizar();
            novo = true;
            Limpar();
            CarregarComboBox(cbEstadoRegistro);
            SelecionarComboBoacu(cbEstadoRegistro,cbMunicipioRegistro,cbBairroResgistro);
            txtTelefoneRegistro.Focus();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Tb_contato_Model objLocal = new Tb_contato_Model();
            if (Capturar(objLocal) == true)
            {
                InterfaceLayoutNovoAtualizar();
                novo = false;
                txtTelefoneRegistro.Focus();
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Tb_contato_Model objLocal = new Tb_contato_Model();

            if (Capturar(objLocal)==true)
            {
                if (novo == true)
                {
                    if (Banco.Tb_contato.Retorno(objLocal.telefone).id == 0)
                    {
                        Banco.Tb_contato.Inserir(objLocal);
                        ListaContato = Banco.Tb_contato.RetornoCompleto();
                        Exibir(ListaContato[ListaContato.Count - 1]);
                    }
                }
                else
                {

                    Banco.Tb_contato.Atualizar(objLocal);
                    ListaContato = Banco.Tb_contato.RetornoCompleto();
                    Exibir(ListaContato.Find(x => x.id == objLocal.id));
                }
                InterfaceLayoutInicioCancelarGravarDeletar();
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Verifique as Informações", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            InterfaceLayoutInicioCancelarGravarDeletar();
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                Importar();
            }
            catch { }
            InterfaceLayoutInicioCancelarGravarDeletar();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Tb_contato_Model objLocal = new Tb_contato_Model();
            if (Capturar(objLocal) == true && objLocal.id > 0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Apagar Registro Selecionado ?", "Apagar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Banco.Tb_contato.Deletar(objLocal);
                    ListaContato = Banco.Tb_contato.RetornoCompleto();
                    Limpar();
                    AtualizarGrid();
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
            DialogResult dialog = MessageBox.Show("Deseja Apagar Todos os Contatos ?", "Apagar todos os registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                dialog = MessageBox.Show("TEM CERTEZA? TODOS OS DADOS SERÃO APAGADOS", "APAGAR TODOS OS REGISTROS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Banco.Tb_contato.Truncate();
                    ListaContato = Banco.Tb_contato.RetornoCompleto();
                    Limpar();
                    AtualizarGrid();
                    InterfaceLayoutInicioCancelarGravarDeletar();
                }
            }
        }
        private void cbEstadoRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstadoRegistro.Text) == false)
            {
                CarregarComboBox(cbMunicipioRegistro, Convert.ToString(cbEstadoRegistro.SelectedValue));
            }
        }
        private void cbMunicipioRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMunicipioRegistro.Text) == false)
            {
                CarregarComboBox(cbBairroResgistro, Convert.ToString(cbEstadoRegistro.SelectedValue), Convert.ToString(cbMunicipioRegistro.SelectedValue));
            }
        }

        //Buscar
        private void btnBuscarTelefone_Click(object sender, EventArgs e)
        {
            if (txtTelefoneFiltro.Text.Trim().Length==11)
            {
                Buscar(txtTelefoneFiltro.Text.Trim());
            }
            else
            {
                MessageBox.Show("Número digitado Incorreto!","Formato Incorreto",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string contato = string.Empty;
            try
            {
                contato = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch { }
            if (contato.Length == 11)
            {
                txtTelefoneFiltro.Text = contato;
                btnBuscarTelefone.PerformClick();
            }
        }

        //Seleção de Grid
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
        private void btnSelecionarLinhas_Click(object sender, EventArgs e)
        {
            int totalLinhas = dataGridView.Rows.Count;
            int contador = 0;
            int inicio = int.Parse(nUpDownInicio.Value.ToString());
            int quantidade = int.Parse(nUpDownQuantidade.Value.ToString());
            if (inicio > 0 && quantidade > 0 && inicio <= totalLinhas && totalLinhas>0)
            {
                inicio--;
                AtualizarGrid();
                foreach (DataGridViewRow rows in dataGridView.Rows)
                {
                    if (contador >= inicio && quantidade > 0)
                    {
                        if (rows.Cells[2].Value != null)
                        {
                            rows.Cells[0].Value = true;
                        }
                        quantidade--;
                    }

                    contador++;
                }
            }
            else
            {
                MessageBox.Show($"Possiveis Erros {Environment.NewLine}* Valor de Inicio deve ser maior que 0 {Environment.NewLine}* Valor de quantidade deve ser maior que 0 {Environment.NewLine}* Valor de inicio deve ser menor que o número de Registros {Environment.NewLine}* A Tabela deve ter registros", "Valores Incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
        private void btnAddListaParaExportar_Click(object sender, EventArgs e)
        {
            List<string> telTemp = new List<string>();
            int valorAntes = Global.ListaContatoEmailExportar.Count;
            foreach (DataGridViewRow rows in dataGridView.Rows)
            {
                if (rows.Cells[2].Value != null)
                {
                    string check = string.Empty;
                    if (rows.Cells[0].Value == null)
                    {
                        check = "false";
                    }
                    else
                    {
                        check = rows.Cells[0].Value.ToString();
                    }
                    if (check.ToUpper().Equals("TRUE"))
                    {
                        telTemp.Add(rows.Cells[2].Value.ToString());
                    }
                }
            }
            if (telTemp.Count>0)
            {
                AtualizarGrid();
                foreach (string temp in telTemp)
                {
                    bool encontrado = false;

                    string buscaTelefone = string.Empty;

                    try
                    {
                        buscaTelefone = Global.ListaContatoEmailExportar[Global.ListaContatoEmailExportar.FindIndex(x => x.Equals(temp))];
                    }
                    catch { }

                    if (string.IsNullOrEmpty(buscaTelefone) == false)
                    {
                        encontrado = true;
                    }



                    if (encontrado == false)
                    {
                        Global.ListaContatoEmailExportar.Add(temp);
                    }
                }
                lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();

                if (Global.ListaContatoEmailExportar.Count>valorAntes)
                {
                    DialogResult dialog = MessageBox.Show("Números Adicionados, Deseja ir para Contatos Email ?", "Lista Para Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog==DialogResult.Yes)
                    {
                        openChildForm(new FrmContatoEmail());
                    }
                }
                else
                {
                    MessageBox.Show("Os Números Selecionados ja estavam na Lista", "Lista Para Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Nenhuma Linha Selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //Exportar
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (Global.ListaContatoEmailExportar.Count>0)
            {
                foreach (string item in Global.ListaContatoEmailExportar)
                {
                    Tb_contato_Model contato = ListaContato.Find(x => x.telefone.Equals(item));
                    if (contato.interacao==0)
                    {
                        contato.interacao = 1;
                        Banco.Tb_contato.Atualizar(contato);
                    }
                  
                }
                AtualizarGrid();
                if (ExcelService.CreateTableContatos(Global.ListaContatoEmailExportar) == true)
                {
                    Global.ListaContatoEmailExportar = new List<string>();
                    lblListaParaExportar.Text = Global.ListaContatoEmailExportar.Count.ToString();
                    DialogResult dialog = MessageBox.Show("Tabela Criada, Deseja Abrir Local  da Tabela? ", "Concluido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("Explorer.exe", string.Format("/select,\"{0}\"", ExcelService.Path(ExcelService.Contatos)));
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
