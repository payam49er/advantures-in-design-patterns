using System.Collections.Generic;
using System.Linq;

namespace CSharpPatterns.InterpreterPattern
{
    public class InterpreterChallenge
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate ( string expression )
        {
            // todo
            string updatedExpression = expression;
            if (Variables.Any())
            {
                foreach (KeyValuePair<char, int> variable in Variables)
                {
                   if (!HasValidVariable(expression))
                         return 0;

                   string number = Variables[variable.Key].ToString();
                   updatedExpression = expression.Replace(variable.Key,number[0]);
                }
            }
            var ops = Resolve(updatedExpression);

            return ops.Sum(x => x.Result);
        }

        private Queue<Operation> Resolve (string expression)
        {
            Queue<Operation> operations = new Queue<Operation>();

            var array =  expression.ToCharArray();
            var parted = array.Select((s, i) => array.Skip(i * 3).Take(3)).Where(x => x.Any());
            foreach (var c in parted)
            {
                var parsed = Parse(c.ToArray());
                Operation op = new Operation(parsed.op,parsed.ldigit,parsed.rdigit);
                operations.Enqueue(op);
            }

            return operations;
        }

        public class Operation
        {
            private readonly char _operator;
            private readonly int _leftDigit;
            private readonly int _rightDigit;
            public Operation(char @operator,int leftDigit, int rightDigit)
            {
                this._operator = @operator;
                this._leftDigit = leftDigit;
                this._rightDigit = rightDigit;
            }

            public int Result 
            {
                get
                {
                    if (_operator == '+')
                        return _leftDigit + _rightDigit;
                    return _leftDigit - _rightDigit;
                }   
            }
        }

        private (char op, int ldigit, int rdigit) Parse(char[] array)
        {
            List<int> digits = new List<int>();
            char op = '+';

            for (int i = 0; i < array.Length; i++)
            {
                if (char.IsDigit(array[i]))
                    digits.Add(int.Parse(array[i].ToString()));
                if (char.IsSymbol(array[i]))
                    op = array[i];
            }
            return digits.Count < 2 ? (op: op, ldigit: digits[0], rdigit: 0) : (op: op, ldigit: digits[0], rdigit: digits[1]);
        }

        private bool HasVariable(string expression)
        {
            return expression.Any(x => char.IsLetter((char)x));
        }

        private bool HasValidVariable(string expression)
        {
            if (HasVariable(expression))
            {
                string[] parsed = expression.Split(new[] {'-', '+'});

                foreach (var s in parsed)
                {
                    if (s.ToCharArray().Length != 1)
                        return false;
                }
            }

            return true;
        }

    }
}
