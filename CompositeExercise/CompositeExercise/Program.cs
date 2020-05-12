﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompositeExercise
{
    public interface IValueContainer:IEnumerable<int>
    {

    }

    public class SingleValue : IValueContainer
    {
        public int Value;
        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ManyValues : List<int>, IValueContainer
    {

    }

    public static class ExtensionMethods
    {
        public static int Sum ( this List<IValueContainer> containers )
        {
            int result = 0;
            foreach (var c in containers)
            foreach (var i in c)
                result += i;
            return result;
        }
    }

    class Program
    {
        static void Main ( string[] args )
        {
            List<int> numbersList = new List<int>{1,4,5,6,3,4};
            var val = new SingleValue();

            val.Value = 5;

            var singleValue = val.Sum();

            Console.WriteLine($"Single value is {singleValue}");

            var many = new ManyValues();
            many.AddRange(numbersList);
            var manyValues =  many.Sum();

            Console.WriteLine($"Sum of many values is {manyValues}");
        }
    }
}
