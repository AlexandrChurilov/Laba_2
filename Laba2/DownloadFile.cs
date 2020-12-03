using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba2
{
    class DownloadFile
    {
        
        
        public static void Download()
        {
            try
            {
                new WebClient().DownloadFile(@"https://bdu.fstec.ru/files/documents/thrlist.xlsx", "thrlist.xlsx");
            }
            catch (Exception e)
            {

                MessageBox.Show("Ошибка!\n" + e);
            }
            
        }
    
    
    } 
}
