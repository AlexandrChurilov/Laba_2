using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    interface IParser
    {
        void ParserWork(List<Threat> threats);

        void WriteXmlBd();
        void ReadXmlBd();
    }
}
