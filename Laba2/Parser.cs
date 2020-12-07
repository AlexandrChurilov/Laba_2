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
        public static List<Threat> threat = new List<Threat>();
        public List<Threat> old_information = new List<Threat>();
        public  List<Threat> obnova = new List<Threat>();
        public  List<Threat> changers = new List<Threat>();


        public Parser()
        {
        }


        public void ParserWork(List<Threat> threats)
        {

            FileStream stream = File.Open(Environment.CurrentDirectory + @"\thrlist.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;

            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet result = excelReader.AsDataSet();
            DataRowCollection dt = result.Tables[0].Rows;

            for (int i = 2; i < dt.Count; i++)
            {
                string ubi = null;
                if (i < 11) { ubi = "УБИ.00"; }
                else if (i > 9 && i < 101) { ubi = "УБИ.0"; }
                else { ubi = "УБИ."; }
                threats.Add(new Threat() { Thrat = ubi + dt[i].ItemArray[0].ToString(), Info = dt[i].ItemArray[1].ToString(), Source = dt[i].ItemArray[2].ToString(), Description = dt[i].ItemArray[3].ToString(), ObjectOfImpact = dt[i].ItemArray[4].ToString(), Confidentiality = dt[i].ItemArray[5].ToString(), Integrity = dt[i].ItemArray[6].ToString(), Availabilities = dt[i].ItemArray[7].ToString() });
            }
            stream.Close();

        }




    }
}
