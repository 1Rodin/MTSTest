using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindInFiles.Library
{

    public class Result
    {
        public string FileName { get; set; }
        public string Operation { get; set; }
        public object Value { get; set; }
        public override string ToString() => $"{Path.GetFileName(FileName)}-{Operation}-{Value}";
    }
   public class FindManager
    {
        public object DoCSS(string text)
        {
            var open = text.Count(a => a.Equals('{'));
            var close = text.Count(a => a.Equals('}'));
            return open == close;
        }

        public Result ParsCSS(string path)
        {
            var text = File.ReadAllText(path);
            var result = DoCSS(text);
            return new Result
            {
                FileName = path,
                Operation = "CSS",
                Value = result
            }; 
        }

        public object DoHTML(string text)
        {
             Regex div = new Regex(@"<\s*div[^>]*>(.*?)<\s*/\s*div>");
             var matches = div.Matches(text).Count;
            return matches;

        }

        public Result ParseHTML(string path)
        {
           
            var text = File.ReadAllText(path);

            var result = DoHTML(text);

            return new Result
            {
                FileName = path,
                Operation = "HTML",
                Value = result
            };
        }


        public Result ParseDef(string path)
        {
            var text = File.ReadAllText(path);
            
            var result = DoDef(text);

            return new Result
            {
                FileName = path,
                Operation = "TXT",
                Value = result
            };
        }

        public object DoDef(string text)
        {
             char[] _marks = { '.', ',', '!', '?', ';', ':', '"', '(', ')', '\'' };
            var cnt = text.Count(a => _marks.Contains(a));
            return cnt;
        }




    }
}
