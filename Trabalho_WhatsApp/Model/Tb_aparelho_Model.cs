using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Model
{
    class Tb_aparelho_Model
    {
        public int id { get; set; }
        public string whatsapp { get; set; }
        public string business { get; set; }
        public string email { get; set; }
        public string udid { get; set; }
        public int habilitado { get; set; }
        
        public Tb_aparelho_Model()
        {
            id = 0;
            whatsapp = string.Empty;
            business = string.Empty;
            email = string.Empty;
            udid = string.Empty;
            habilitado = 0;
        }
    }
}
