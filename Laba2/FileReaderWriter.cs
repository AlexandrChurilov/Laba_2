using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Laba2
{
    class FileReaderWriter
    {
        private XmlSerializer formatter = new XmlSerializer(typeof(List<Threat>));

        public void ReadXmlBd()
        {
            try
            {
                using (FileStream fs = new FileStream("threat.xml", FileMode.OpenOrCreate))
                {
                    List<Threat> newpeople = (List<Threat>)formatter.Deserialize(fs);
                    foreach (var item in newpeople)
                    {
                        Parser.threat.Add(item);
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
                formatter.Serialize(fs, Parser.threat);
            }
        }
    }
}
