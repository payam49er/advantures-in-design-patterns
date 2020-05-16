using System.Collections.Generic;
using System.Text;

namespace FlyweightPattern
{
    public class FlyweightPractice
    {
        public class Sentence
        {
            private readonly string[] _splitSentence;
            private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();
            public Sentence ( string plainText )
            {
                this._splitSentence = plainText.Split(' ');
                
            }

            public WordToken this[int index]
            {
                get
                {
                    var token = new WordToken();
                    tokens.Add(index,token);
                    return tokens[index];
                }
            }

            public override string ToString ()
            {
                // output formatted text here
                var sb = new StringBuilder();
               
                for (int i = 0; i < _splitSentence.Length; i++)
                {
                    if (tokens.ContainsKey(i) && tokens[i].Capitalize)
                        sb.Append($"{_splitSentence[i].ToUpper()} ");
                    else
                    {
                        sb.Append($"{_splitSentence[i]} ");
                    }
                }
                

                return sb.ToString().TrimEnd();
            }

            public class WordToken
            {
                public bool Capitalize;
            }
        }
    }
}
