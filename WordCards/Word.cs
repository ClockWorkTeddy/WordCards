using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCards
{
    internal class WordObject
    {
        public string Word { get; set; }
        public string Translate { get; set; }
        public string Transcription { get; set; }

        private WordObject(string word, string translate, string transcription) 
        { 
            Word = word;
            Translate = translate;
            Transcription = transcription;
        }

        public static WordObject GetWordObject(string wordString, bool mode)
        {
            string[] parts = wordString.Split(',');
            string word = mode ? parts[0] : parts[1];
            string translate = mode ? parts[1] : parts[0];
            string transcription = parts[2].TrimEnd();

            return new WordObject(word, translate, transcription);
        }

        public override string ToString()
        {
            if (Word != null)
                return Word.ToString();
            else
                return base.ToString();
        }
    }
}
