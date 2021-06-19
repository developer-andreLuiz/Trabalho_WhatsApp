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
    public partial class FrmContato : Form
    {
        public FrmContato()
        {
            InitializeComponent();
        }
        public FrmContato(string telefone)
        {
            InitializeComponent();
            lblTelefone.Text = telefone;
        }
    }
}
