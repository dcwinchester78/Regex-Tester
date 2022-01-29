using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Text.RegularExpressions;
using RegexTesterUI.Model;
using System.Windows;

namespace RegexTesterUI.ViewModels
{
    public class TesterViewModel : BindableBase
    {
        #region Properties

        private string _path;
        public string FilePath
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        private string fileData;
        public string FileData
        {
            get => fileData; 
            set
            {
                SetProperty(ref fileData, value);
                MatchesTextCount = "Matches: ";
                StringMatches = new List<string>();
            }
        }

        private string _multipleLineRegPattern;
        public string MultipleLineRegPattern
        {
            get => _multipleLineRegPattern; 
            set
            {
                SetProperty(ref _multipleLineRegPattern, value);
                MatchesTextCount = "Matches: ";
                StringMatches = new List<string>();
            }
        }

        private string _singleRegContent;
        public string SingleContentRegData
        {
            get => _singleRegContent;
            set
            {
                SetProperty(ref _singleRegContent, value);
                IsMatch = "";
            }
        }

        private string _singleMatchRegPattern;
        public string SingleMatchRegPattern 
        {
            get => _singleMatchRegPattern; 
            set
            {
                SetProperty(ref _singleMatchRegPattern, value);
                IsMatch = "";
            }
        }

        private string _isMatch;
        public string IsMatch
        {
            get => _isMatch; 
            set => SetProperty(ref _isMatch, value);
        }
 
        private List<string> _stringMatches;
        public List<string> StringMatches
        {
            get => _stringMatches;
            set => SetProperty(ref _stringMatches, value);
        }

        private string _matchesTextCount = "Matches:";
        public string MatchesTextCount
        {
            get => _matchesTextCount; 
            set => SetProperty(ref _matchesTextCount, value);
        }


        public DelegateCommand<string> UpdateCommand { get; private set; }

        IRegexMaster _iReg;

        #endregion

        #region Constructors

        public TesterViewModel(IRegexMaster _iReg)
        {
            this._iReg = _iReg;
            UpdateCommand = new DelegateCommand<string>(Execute, CanExecute)
                .ObservesProperty(() => FileData)
                .ObservesProperty(() => MultipleLineRegPattern)
                .ObservesProperty(() => SingleContentRegData)
                .ObservesProperty(() => SingleMatchRegPattern);
        }

        #endregion

        #region DelegateCommandMethods

        /// <summary>
        /// Command parameter from ui chooses which data to check
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CanExecute(string input)
        {          
            string lowPut = input.ToLower();
            if (lowPut == "regmatchescommand")
            {
                bool isCompliant = !String.IsNullOrWhiteSpace(FileData) && !String.IsNullOrWhiteSpace(MultipleLineRegPattern);
                if(!isCompliant)
                {
                    MatchesTextCount = "Matches: ";
                    StringMatches = new List<string>();
                }
                return isCompliant;
            }

            else if (lowPut == "regmatchcommand")
            {             
                bool isCompliant = !String.IsNullOrWhiteSpace(SingleMatchRegPattern) && !String.IsNullOrWhiteSpace(SingleContentRegData);
                if(!isCompliant)
                {
                    IsMatch = "";
                }

                return isCompliant;
            }

            else return false;
        }


        /// <summary>
        /// Execute regex either for a collection or a single match
        /// </summary>
        /// <param name="input"></param>
        private void Execute(string input)
        {           
            string lowPut = input.ToLower();

            if (lowPut == "regmatchescommand")
            {
                PopulateRegMatches();
            }

            else if(lowPut == "regmatchcommand")
            {
                IsRegMatch();
            }
        }

       /// <summary>
       /// Populate list of regex matches
       /// </summary>
        private void PopulateRegMatches()
        {
            MatchCollection matches = _iReg.RegMatches(MultipleLineRegPattern, FileData);

            //Add to a new string list, then assign srMat value to Property StringMatches
            List<string> srMat = new List<string>();

            if (matches != null)
            {
                foreach (Match m in matches)
                {
                    srMat.Add($"index {m.Index}: {m.ToString()}");
                }
            }
            StringMatches = srMat;

            //set the match count variable 
            MatchesTextCount = "Matches: " + String.Format("{0:n0}", StringMatches.Count);
        }

        /// <summary>
        /// Set IsMatch property on regular expression match
        /// </summary>
        private void IsRegMatch()
        {
            Match mat = _iReg.RegMatch(SingleMatchRegPattern, SingleContentRegData);
            if (mat != null)
            {
                if (mat.Success)
                {
                    IsMatch = "TRUE";
                }
                else
                {
                    IsMatch = "FALSE";
                }
            }
            else
            {
                IsMatch = "FALSE";
            }
        }

        #endregion

        //load filedata
        public void LoadData(string data, string path)
        {
            FileData = data;
            FilePath = path;           
        }

    }
}
