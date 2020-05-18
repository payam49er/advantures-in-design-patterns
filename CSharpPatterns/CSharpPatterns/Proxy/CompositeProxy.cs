using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPatterns.Proxy
{
    public class GameCreature
    {
        public byte Age;
        public int X, Y;
    }


    public class GameCreatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public GameCreatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct GameCreatureProxy
        {
            private readonly GameCreatures creatures;
            private readonly int index;
            public GameCreatureProxy(GameCreatures creatures,int index)
            {
                this.creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index]; // this allows us that when the API is used, we indirectly work with the index
            public ref int X => ref creatures.x[index];
            public ref int Y => ref creatures.y[index];
        }

        public IEnumerator<GameCreatureProxy> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return new GameCreatureProxy(this,i);
            }
        }

    }


    //Array backed Properties
    //A situation where I want to check or uncheck a group of settings
    //The commented code is an approach that is not sustainable. Specially the
    //getter is very fragile. A better approach is to use array back properties from composite pattern. 
    public class MasonrySettings
    {
        //public bool? All
        //{
        //    get
        //    {
        //        if (Pillars == Walls && Walls == Floors) return Pillars;
        //        return null;
        //    }
        //    set
        //    {
        //        if(!value.HasValue) return;
        //        Pillars = value.Value;
        //        Walls = value.Value;
        //        Floors = value.Value;
        //    }
        //}
        //public bool Pillars, Walls, Floors;

        public bool? All
        {
            get
            {
                if (flags.Skip(1).All(f => f == flags[0])) return flags[0];
                return null;
            }
            set
            {
                if (!value.HasValue) return;
                for (int i = 0; i < flags.Length; i++)
                {
                    flags[i] = value.Value;
                }
            }
        }



        private readonly bool[] flags = new bool[3];

        public bool Pillars
        {
            get => flags[0];
            set => flags[0] = value;
        }

        public bool Walls
        {
            get => flags[1];
            set => flags[1] = value;
        }

        public bool Floors
        {
            get => flags[2];
            set => flags[2] = value;
        }
    }
    
}
