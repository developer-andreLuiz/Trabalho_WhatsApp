using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_WhatsApp.View
{
    public partial class FrmBancoDeDados : Form
    {
        #region Variaveis
        private Form activeForm = null;
        #endregion
       
        #region Funções
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
        #endregion

        #region Eventos
        public FrmBancoDeDados()
        {
            InitializeComponent();
        }
        private void btnAparelho_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAparelho());
        }
        private void btnContato_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmContato());
        }
        private void btnContatoEmail_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmContatoEmail());
        }
        private void btnEstadoMunicipioBairro_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmEstadoMunicipioBairro());
        }
        #endregion


    }
}
