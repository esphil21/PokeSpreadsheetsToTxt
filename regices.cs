using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PokeSpreadsheetsToTxt
{
    public class regices
    {
        public Regex Letter = new Regex(@"[a-zA-Z]");
        public Regex Number = new Regex(@"\d");
        public Regex Spaces = new Regex(@"\s");
        public Regex Special = new Regex(@"([^a-zA-Z_0-9_\-\'\:\s|\s$])");
        public Regex ExceptedSpecials = new Regex(@"[-|:|'|_|%]");
        public Regex DexNum = new Regex(@"\[\d+\]");
        //public Regex ValidWord = new Regex(@"\'.\'|\'\\n\'|\d+|\-\d+|\w+|.BYT|.INT|\w|\;.*");    //\'\S\'|\w+|\.\w+|<|=|>|\$|_|-\w+|-|\+|@|\'.\'|;.*|\'\\n\'|,|\s$
    }
}
