using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Model
{
    class Tb_contato_Model
    {
        public int id { get; set; }
        public string telefone { get; set; }
        public string codigo_estado { get; set; }
        public string codigo_municipio { get; set; }
        public string codigo_bairro { get; set; }
        public int interacao { get; set; }
        public int habilitado { get; set; }
       
        public Tb_contato_Model()
        {
            id = 0;
            telefone = string.Empty;
            codigo_estado = string.Empty;
            codigo_municipio = string.Empty;
            codigo_bairro = string.Empty;
            interacao = 0;
            habilitado = 0;
        }
    }
}
