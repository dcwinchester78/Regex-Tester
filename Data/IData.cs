using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegexTesterUI
{
    public interface IData
    {
        string Path { get; set; }
        string DataFromSource();
    }
}
