using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Singleton
{
    public class MonoState
    {
        private static string name;
        private static string position;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }
        

        public string Position
        {
            get => position;
            set => position = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Age)}: {Age}";
        }
    }
}