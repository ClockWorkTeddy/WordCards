using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCards
{
    internal class MainWindowVm : ViewModelBase
    {
        private bool state = false;
        private bool mode = false;
        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        private string? word;
        public string? Word
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
                OnPropertyChanged(nameof(Word));
            }
        }

        private string? translate;
        public string? Translate
        {
            get
            {
                return translate;
            }
            set
            {
                translate = value;
                OnPropertyChanged(nameof(Translate));
            }
        }

        private string? transcription;
        public string? Transcription
        {
            get
            {
                return transcription;
            }
            set
            {
                transcription = value;
                OnPropertyChanged(nameof(Transcription));
            }
        }

        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private WordsCollection Words = null;

        public AutoCommand ShowCommand =>
            new AutoCommand(obj => { ShowCommandExecute(); }, obj => ShowCommandCanExecute());

        public AutoCommand NextCommand =>
            new AutoCommand(obj => { NextCommandExecute(); }, obj => NextCommandCanExecute());

        public AutoCommand SkipCommand =>
            new AutoCommand(obj => { SkipCommandExecute(); }, obj => SkipCommandCanExecute());

        public MainWindowVm()
        {
            Initialize();
        }

        public void Initialize()
        {
            mode = !mode;
            Words = new WordsCollection(new DbReader().GetWordsFromFile(mode));
            SetData();
            State = false;
        }

        public void ShowCommandExecute()
        {
            if (Words.Empty)
                Initialize();
            else
                State = true;
        }

        public bool ShowCommandCanExecute()
        {
            return !State;
        }

        public void NextCommandExecute()
        {
            if (!Words.Empty)
            {
                Words.DeleteCurrentWord();

                if (Words.Empty)
                    Word = "КОНЕЦ";
                else
                    SetData();
            }
            
            State = false;
        }

        public bool NextCommandCanExecute()
        {
            return State;
        }

        public void SkipCommandExecute()
        {
            State = false;
            Words.NextWord();
            SetData();
        }

        public bool SkipCommandCanExecute()
        {
            return State;
        }
        public void SetData()
        {
            Word = Words.CurrentWord.Word;
            Translate = Words.CurrentWord.Translate;
            Transcription = Words.CurrentWord.Transcription;
            Count = Words.WordsRemain;
        }
    }
}
