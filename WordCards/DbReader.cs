using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCards
{
    internal class DbReader
    {
        int Max = 30;

        public List<WordObject> GetWordsFromFile(bool mode)
        {
            var result = new List<WordObject>();
            var path = "Words.csv";
            var content = GetContent(path);

            var strings = content.Split('\n');
            Max = Math.Min(strings.Length, Max);
            var indexes = GetRandomIndexes(strings.Length);

            for (int i = 0; i < indexes.Count; i++)
                result.Add(WordObject.GetWordObject(strings[indexes[i]], mode));

            return result;
        }

        private string GetContent(string path)
        {
            string content = null;

            using (StreamReader reader = new StreamReader(path))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }

        private List<int> GetRandomIndexes(int count)
        {
            Random random = new Random();
            List<int> indexes = new List<int>();

            for (int i = 0; i < Max; i++)
            {
                int index = random.Next(count);

                while (indexes.Contains(index))
                    index = random.Next(count);

                indexes.Add(index);
            }

            return indexes;
        }
    }
}
