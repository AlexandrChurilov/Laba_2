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
        [NonSerialized]
        
        private string _integ ;
        private string _confidentiality ;
        private string _availabilities;

        public string Thrat { get; set; }
        public string Info { get; set; }
        public string Source { get; set; }

        public string Description { get; set; }
        public string ObjectOfImpact { get; set; }
        public string Confidentiality 
        { 
            get { return _confidentiality; } 
            set { if (value == "1"||value=="ДА") { _confidentiality = "ДА"; } else { _confidentiality = "НЕТ"; } } 
        }
        public string Integrity
        { 
            set
            {
                if (value == "1"||value=="ДА")
                {
                    _integ = "ДА";
                }
                else
                {
                    _integ = "НЕТ";
                }
            }
            get
            {
                return _integ;
            }
        }
        public string Availabilities
        {
            get { return _availabilities; }
            set { if (value == "1"||value=="ДА") { _availabilities = "ДА"; } else { _availabilities = "НЕТ"; } }
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
