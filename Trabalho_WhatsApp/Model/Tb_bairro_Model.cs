using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Model
{
    class Tb_bairro_Model
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public string codigo_estado { get; set; }
        public string codigo_municipio { get; set; }
        
        public Tb_bairro_Model()
        {
            id = 0;
            codigo = string.Empty;
            nome = string.Empty;
            codigo_estado = string.Empty;
            codigo_municipio = string.Empty;
        }

    }
}
