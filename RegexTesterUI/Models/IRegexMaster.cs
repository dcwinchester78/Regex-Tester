using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexTesterUI.Model
{
    public interface IRegexMaster
    {
        MatchCollection RegMatches(string pattern, string content);

        Match RegMatch(string pattern, string content);  
    }
}