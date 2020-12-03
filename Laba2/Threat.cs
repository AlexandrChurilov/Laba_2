using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    [Serializable]
    public class Threat
    {
        private string integ ;
        private string confidentiality ;
        private string availabilities;

        public string Thrat { get; set; }
        public string Info { get; set; }
        public string Source { get; set; }

        public string Description { get; set; }
        public string ObjectOfImpact { get; set; }
        public string Confidentiality 
        { 
            get { return confidentiality; } 
            set { if (value == "1"||value=="ДА") { confidentiality = "ДА"; } else { confidentiality = "НЕТ"; } } 
        }
        public string Integrity
        { 
            set
            {
                if (value == "1"||value=="ДА")
                {
                    integ = "ДА";
                }
                else
                {
                    integ = "НЕТ";
                }
            }
            get
            {
                return integ;
            }
        }
        public string Availabilities
        {
            get { return availabilities; }
            set { if (value == "1"||value=="ДА") { availabilities = "ДА"; } else { availabilities = "НЕТ"; } }
        }

        public Threat()
        {

        }
        public override string ToString()
        {
       

            return $"{Thrat} \n {Info} \n {Source} \n {Description} \n {ObjectOfImpact} \n {Confidentiality} \n {Integrity} \n {Availabilities}".Replace("\r", "");
        }
    }
}
