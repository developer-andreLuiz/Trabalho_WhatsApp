using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_WhatsApp.Service
{
    class FolderService
    {
        public static string PathTabelasExportadas
        {
            get
            {
                return System.IO.Directory.GetCurrentDirectory() + @"\Tabelas Exportadas";
            }

        }
        public static void CreateFolderTabelas()
        {
            if (Directory.Exists(PathTabelasExportadas) == false)
            {
                Directory.CreateDirectory(PathTabelasExportadas);
            }
        }
    }
}
