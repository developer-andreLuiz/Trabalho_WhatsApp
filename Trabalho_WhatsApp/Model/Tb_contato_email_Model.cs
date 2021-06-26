using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Model
{
    class Tb_contato_email_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public int enviado { get; set; }
        public int habilitado { get; set; }
        
        public Tb_contato_email_Model()
        {
            id = 0;
            telefone = string.Empty;
            enviado = 0;
            habilitado = 0;
        }
        public Tb_contato_email_Model(string Telefone)
        {
            id = 0;
            telefone = Telefone;
            enviado = 0;
            habilitado = 1;
        }
    }
}
