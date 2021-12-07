using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexTesterUI.Model
{
    public class RegexMaster : IRegexMaster
    {
        /// <summary>
        /// Returns a match collection
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public MatchCollection RegMatches(string pattern, string content)
        {
            MatchCollection matches;

            if(!String.IsNullOrWhiteSpace(pattern) && !String.IsNullOrWhiteSpace(content))
            {
                try
                {
                    Regex reg = new Regex(pattern);
                    matches = reg.Matches(content);
                    return matches;
                }
                catch(ArgumentException regex1)
                {
                    return matches = null;
                }
                
            }
                      
            return matches = null;             
        }

        /// <summary>
        /// Returns a single match
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public Match RegMatch(string pattern, string content)
        {
            Match match;

            if (!String.IsNullOrWhiteSpace(pattern) && !String.IsNullOrWhiteSpace(content))
            {
                try
                {
                    Regex reg = new Regex(pattern);
                    match = reg.Match(content);
                    return match;
                }
                catch (ArgumentException regex1)
                {
                    return match = null;
                }
            }

            return match = null;
        }        
    }
}
