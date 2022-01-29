using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RegexTesterUI.Models
{
    public class HtmlParser
    {
        private HtmlDocument doc;

        public HtmlParser(HtmlDocument _doc)
        {
            this.doc = _doc;
        }

        public HtmlNode GetElementById(string id)
        {
            return doc.GetElementbyId(id);
        }

        public string InnerText()
        {
            return doc.DocumentNode.InnerText;
        }

        public string InnerText(HtmlNode node)
        {
            return node.InnerText;
        }

        public string InnerHtml()
        {
            return doc.DocumentNode.InnerHtml;
        }

        public string InnerHtml(HtmlNode node)
        {
            return node.InnerHtml;
        }    
    }
}
