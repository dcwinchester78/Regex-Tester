using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RegexTesterUI.Model;

namespace RegexTesterUI.Data
{
    /// <summary>
    /// Gets a few objects "newed up" for the code behind.
    /// </summary>
    public static class Factory
    {
        public static IData GetData(CancellationToken token, string uri)
        {
            return new Web(token, uri);      
        }

        public static IData GetData()
        {
            return new FileWorx();
        }

        public static IRegexMaster GetRegex()
        {
            return new RegexMaster();
        }
  
    }
}
