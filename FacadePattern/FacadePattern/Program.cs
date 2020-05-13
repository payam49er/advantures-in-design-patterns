using System;
using System.Collections.Generic;
using System.Linq;

namespace FacadePattern
{
    public class Generator
    {
        private static readonly Random random = new Random();

        public List<int> Generate ( int count )
        {
            return Enumerable.Range(0, count)
                .Select(_ => random.Next(1, 6))
                .ToList();
        }
    }

    public class Splitter
    {
        public List<List<int>> Split ( List<List<int>> array )
        {
            var result = new List<List<int>>();

            var rowCount = array.Count;
            var colCount = array[0].Count;

            // get the rows
            for (int r = 0; r < rowCount; ++r)
            {
                var theRow = new List<int>();
                for (int c = 0; c < colCount; ++c)
                    theRow.Add(array[r][c]);
                result.Add(theRow);
            }

            // get the columns
            for (int c = 0; c < colCount; ++c)
            {
                var theCol = new List<int>();
                for (int r = 0; r < rowCount; ++r)
                    theCol.Add(array[r][c]);
                result.Add(theCol);
            }

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            for (int c = 0; c < colCount; ++c)
            {
                for (int r = 0; r < rowCount; ++r)
                {
                    if (c == r)
                        diag1.Add(array[r][c]);
                    var r2 = rowCount - r - 1;
                    if (c == r2)
                        diag2.Add(array[r][c]);
                }
            }

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }
    }

    public class Verifier
    {
        public bool Verify ( List<List<int>> array )
        {
            if (!array.Any()) return false;

            var expected = array.First().Sum();

            return array.All(t => t.Sum() == expected);
        }
    }

    public class MagicSquareGenerator
    {
        private readonly Splitter splitter;
        private readonly Verifier verifier;
        private readonly Generator generator;

        public MagicSquareGenerator ()
        {
            this.splitter = new Splitter();
            this.verifier = new Verifier();
            this.generator = new Generator();
        }


        public List<List<int>> Generate ( int size )
        {
            List<List<int>> matrixList = null;
            bool keepGenerating = true;

            while (keepGenerating)
            {
                matrixList = new List<List<int>>();
                for (int i = 0; i < size; i++)
                {
                    List<int> generatedRandomNumbers = generator.Generate(size);

                    matrixList.Add(generatedRandomNumbers);
                }
                var splitted = splitter.Split(matrixList);
                if (verifier.Verify(splitted))
                    keepGenerating = false;
            }
            return matrixList;
        }
    }


    class Program
    {
        static void Main ( string[] args )
        {
            //works best with 3
            //for 4, it take a minute or two 
            //for 5 and above you have to wait for a long time
            MagicSquareGenerator magicSquareGenerator = new MagicSquareGenerator();
            var magic = magicSquareGenerator.Generate(3);
            foreach (var row in magic)
            {
                foreach (int i in row)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine();
            }
        }
    }
}
