using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.dotMemoryUnit;
using NUnit.Framework;

namespace FlyweightPattern
{
    public class User
    {
        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }



    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;
        public User2(string fullName)
        {
            int getOrAdd(string s) // inner function C# 8
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(' ', names.Select(i => strings[i]));
    }

    [TestFixture]
    public class Demo2
    {

        [Test]
        public void TestUser2 () //7212481 vs 6951085
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User2>();

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User2($"{firstName} {lastName}"));
                }
            }

            ForceGc();

            dotMemory.Check(m =>
            {
                Console.WriteLine(m.SizeInBytes);
            });
        }

        private void ForceGc ()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString ()
        {
            Random rand = new Random();
            return new string(Enumerable.Range(0, 10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        }
    }



    [TestFixture]
    public class Demo
    {
     
        [Test]
        public void TestUser() // 6951085
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User>();

            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User($"{firstName} {lastName}"));
                }
            }

            ForceGc();

            dotMemory.Check(m =>
            {
                Console.WriteLine(m.SizeInBytes);
            });
        }

        private void ForceGc()
        {
           GC.Collect();
           GC.WaitForPendingFinalizers();
           GC.Collect();
        }

        private string RandomString()
        {
            Random rand = new Random();
            return new string( Enumerable.Range(0,10).Select(i => (char)('a' + rand.Next(26))).ToArray());
        }
    }

    public class FormattedText
    {
        private readonly string plainText;
        private bool[] capitalize;

        public FormattedText (string plainText)
        {
            this.plainText = plainText;
            capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                capitalize[i] = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < plainText.Length; index++)
            {
                var c = plainText[index];
                sb.Append(capitalize[index] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }

    [TestFixture]
    public class TextFormattingDemo
    {
        [Test]
        public void TestFormatting()
        {
            
            var ft = new FormattedText("this is a brave new world");
            ft.Capitalize(10,15);

            Console.WriteLine(ft);
        }
    }


    //better formatted text

    public class BetterFormattedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();
        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText;
        }

        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange {Start = start, End = end};
            formatting.Add(range);
            return range;
        }
        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (TextRange range in formatting)
                {
                    if (range.Covers(i) && range.Capitalize)
                        c = char.ToUpper(c);
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }

    [TestFixture]
    public class BetterFormattingDemo
    {
        [Test]
        public void BetterFormattingTest()
        {
            var ft = new BetterFormattedText("this is a brave new world");
            ft.GetRange(10, 15).Capitalize = true;

            Console.WriteLine(ft);
        }
    }



    [TestFixture]
    public class TestSentence
    {
        [Test]
        public void MyTest()
        {
            var sentence = new FlyweightPractice.Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
        }

    }


}
