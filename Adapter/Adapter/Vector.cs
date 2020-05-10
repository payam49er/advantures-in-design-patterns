using System;

namespace Adapter
{
    /// <summary>
    /// Example for Generic Value Adapter, mapping a literal to a type or in another word creating an adapter
    /// that connect a literal to a type or vice versa
    /// </summary>
    public class Vector<T,D> where D:IInteger, new()
    {
        protected T[] data;

        public Vector()
        {  
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize,providedSize); i++)
            {
                data[i] = values[i];
            }
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public T X
        {
            get => data[0];
            set => data[0] = value;
        }
    }
    
    //crate an abstract class or an interface
    public interface IInteger
    {
        int Value { get; }
    }


    public static class Dimension
    {
        public class Two:IInteger
        {
            public int Value => 2;
        }

        public class Three:IInteger
        {
            public int Value => 3;
        }
    }
    
    
    //creating a type like this
    public class Vector2i :Vector<int,Dimension.Two>
    {
        
    }
}