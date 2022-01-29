using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RegexTesterUI.Data;

namespace RegexTesterUI.Services
{
    public class DataLoading
    {
        CancellationToken token;

        public DataLoading(CancellationToken token)
        {
            this.token = token;
        }

        //public static async Task<string> GetData(string url, CancellationToken token)
        //{

        //}

        //public static async Task<string> GetData(CancellationToken token)
        //{

        //}

    }
}
