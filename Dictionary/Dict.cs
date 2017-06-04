using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dictionary
{
    class DictEntry
    {
        public string Source { get; set; }
        public string Phonetic { get; set; }
        public string Meaning { get; set; }
    }

    class Dict
    {
        private Dictionary<string, DictEntry> _dict = new Dictionary<string, DictEntry>();
        public void Load(string file)
        {
            var text = File.ReadAllText(file);

            Regex regex = new Regex(@"(@(.+)(\/.+\/)\r?\n)(\* .+\r?\n)((\-?.+\r?\n)*)", RegexOptions.Compiled);

            var matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                _dict.Add(item.Groups[2].Value.Trim(), new DictEntry { Source = item.Groups[2].Value.Trim(), Phonetic = item.Groups[3].Value, Meaning = item.Groups[4].Value + "\r\n" + item.Groups[5].Value});
            }
        }

        public DictEntry Lookup(string word)
        {
            word = word.ToLower().Trim();
            if (!_dict.ContainsKey(word))
                return new DictEntry { Source = word, Meaning = "not found", Phonetic = "" };
            return _dict[word];
        }
    }
}
