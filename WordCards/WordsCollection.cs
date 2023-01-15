using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCards
{
    internal class WordsCollection
    {
        private int CurrentIndex = 0;
        private List<WordObject> WordObjects = new List<WordObject>();
        private WordObject currentWord = null;
        public bool Empty = false;
        public int WordsRemain { get { return WordObjects.Count; } }

        public WordObject CurrentWord 
        { 
            get
            {
                AdjustIndex();
                return WordObjects[CurrentIndex];
            }
            set
            {
                currentWord = value;
            }
        }

        public WordsCollection(List<WordObject> wordObjects)
        {
            WordObjects = wordObjects;
        }

        public void NextWord()
        {
            CurrentIndex++;
            AdjustIndex();
        }

        public void DeleteCurrentWord()
        {
            WordObjects.Remove(CurrentWord);

            if (WordObjects.Count == 0)
                Empty = true;
        }

        private void AdjustIndex()
        {
            if (CurrentIndex >= WordObjects.Count)
                CurrentIndex = 0;
        }
    }
}
