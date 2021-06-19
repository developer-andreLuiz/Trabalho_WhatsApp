using SharpAdbClient;
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

namespace Trabalho_WhatsApp.View
{
    public partial class FrmAparelho : Form
    {
        #region Variaveis
        bool novo = false;
        List<Tb_aparelho_Model> ListaAparelho;
        #endregion
        #region Funções
        //Interface Layout
        void InterfaceLayoutInicioCancelarGravarDeletar()
        {
            txtWhatsApp.Enabled = false;
            txtBusiness.Enabled = false;
            chkHabilitado.Enabled = false;
            txtEmail.Enabled = false;
            cbUdid.Enabled = false;
            InterfaceBotaoInicioCancelarGravarDeletar();
        }
        void InterfaceLayoutNovoAtualizar()
        {
            txtWhatsApp.Enabled = true;
            txtBusiness.Enabled = true;
            chkHabilitado.Enabled = true;
            txtEmail.Enabled = true;
            cbUdid.Enabled = true;
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
        }
        void InterfaceBotaoNovoAtualizar()
        {
            btnNovo.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGravar.Enabled = true;
            btnDeletar.Enabled = true;
        }
        //Grid
        void CarregarGrid()
        {
            dataGridView.DataSource = null;
            if (ListaAparelho.Count>0)
            {
                dataGridView.DataSource = ListaAparelho;
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 110;
                dataGridView.Columns[2].Width = 110;
                dataGridView.Columns[3].Width = 230;
                dataGridView.Columns[4].Width = 150;
                dataGridView.Columns[5].Width = 59;
                int linha = dataGridView.Rows.Count;
                lblLinhas.Text = linha.ToString();
            }
          
        }
        //Objetos
        void Exibir(Tb_aparelho_Model objLocal)
        {
            txtId.Text = objLocal.id.ToString();
            txtWhatsApp.Text = objLocal.whatsapp.ToString();
            txtBusiness.Text = objLocal.business.ToString();
            txtEmail.Text = objLocal.email.ToString();
            cbUdid.DataSource = null;
            List<string> lst = new List<string>();
            lst.Add(objLocal.udid);
            cbUdid.DataSource = lst;
           
            if (objLocal.habilitado == 1)
            {
                chkHabilitado.Checked = true;
            }
            else
            {
                chkHabilitado.Checked = false;
            }
        }
        void Capturar(Tb_aparelho_Model objLocal)
        {

        }


        #endregion
        #region Eventos
        public FrmAparelho()
        {
            InitializeComponent();
            InterfaceLayoutInicioCancelarGravarDeletar();
            ListaAparelho = Banco.Tb_aparelho.RetornoCompleto();
            CarregarGrid();

        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            InterfaceLayoutNovoAtualizar();
            novo = true;
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            InterfaceLayoutNovoAtualizar();
            novo = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InterfaceLayoutInicioCancelarGravarDeletar();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            InterfaceLayoutInicioCancelarGravarDeletar();
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            InterfaceLayoutInicioCancelarGravarDeletar();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Tb_aparelho_Model objLocal = new Tb_aparelho_Model();
            objLocal.id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            objLocal.whatsapp = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            objLocal.business = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[2].Value);
            objLocal.email = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[3].Value);
            objLocal.udid = Convert.ToString(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            objLocal.habilitado = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[5].Value);
            Exibir(objLocal);
        }


        #endregion

        private void cbUdid_Click(object sender, EventArgs e)
        {

            try
            {
                AdbClient adbClient = new AdbClient();
                List<DeviceData> listDevices = adbClient.GetDevices();
                List<string> lst = new List<string>();
                cbUdid.Text = string.Empty;
                cbUdid.DataSource = null;
                foreach (DeviceData devices in listDevices)
                {
                    lst.Add(devices.Serial);
                }
                cbUdid.DataSource = lst;
            }
            catch { }
        }
    }
}
