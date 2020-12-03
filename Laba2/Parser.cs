using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ExcelDataReader;

namespace Laba2
{
    public sealed class Parser : IParser
    {
        private XmlSerializer formatter = new XmlSerializer(typeof(List<Threat>));
        private List<object> a = new List<object>();
        public static List<Threat> threat = new List<Threat>();
       


        public Parser()
        {
        }


        public void ParserWork(List<Threat> threats)
        {
            
                FileStream stream = File.Open(Environment.CurrentDirectory + @"\thrlist.xlsx", FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader;

                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet();
                DataTable dt = result.Tables[0];
                foreach (var item in dt.Rows)
                {
                    a.Add(item);
                }
                for (int i = 2; i < a.Count(); i++)
                {
                    string ubi = null;
                    if (i < 11) { ubi = "УБИ.00"; }
                    else if (i > 9 && i < 101) { ubi = "УБИ.0"; }
                    else { ubi = "УБИ."; }
                    threats.Add(new Threat() { Thrat = ubi + dt.Rows[i][0].ToString(), Info = dt.Rows[i][1].ToString(), Source = dt.Rows[i][2].ToString(), Description = dt.Rows[i][3].ToString(), ObjectOfImpact = dt.Rows[i][4].ToString(), Confidentiality = dt.Rows[i][5].ToString(), Integrity = dt.Rows[i][6].ToString(), Availabilities = dt.Rows[i][7].ToString() });
                }
                stream.Close();           
                      
        }

        public void ReadXmlBd()
        {
            try
            {
                using (FileStream fs = new FileStream("threat.xml", FileMode.OpenOrCreate))
                {
                    List<Threat> newpeople = (List<Threat>)formatter.Deserialize(fs);
                    foreach (var item in newpeople)
                    {
                        threat.Add(item);
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Ой ой Что-то с файлом не то....\n" + e);
                
            }
            

        }

        public void WriteXmlBd()
        {
            using (FileStream fs = new FileStream("threat.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, threat);
            }
        }

       
    }
}
