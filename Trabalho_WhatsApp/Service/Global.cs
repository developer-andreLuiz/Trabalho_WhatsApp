using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trabalho_WhatsApp.Model;

namespace Trabalho_WhatsApp.Service
{
    class Global
    {
        public static List<string> ListaContatoEmailExportar = new List<string>();
        public static List<Tb_estado_Model> ListaEstado = new List<Tb_estado_Model>();
        public static List<Tb_municipio_Model> ListaMunicipio = new List<Tb_municipio_Model>();
        public static List<Tb_bairro_Model> ListaBairro = new List<Tb_bairro_Model>();
        public static List<Thread> Lista_threads = new List<Thread>();

    }
}
