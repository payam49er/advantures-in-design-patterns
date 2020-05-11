using System;
using System.Threading.Tasks.Dataflow;

namespace BridgePractice
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }
    public abstract class Shape
    {
        private readonly IRenderer renderer;
        protected Shape ( IRenderer renderer )
        {
            this.renderer = renderer;
        }
        public string Name { get; set; }

        public virtual string ToString ()
        {
            return $"Drawing {Name} as {renderer.WhatToRenderAs}";
        }

    }

    public class Triangle : Shape
    {
        
        public Triangle(IRenderer renderer) : base(renderer)
        {
            this.Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square (IRenderer renderer):base(renderer)
        {
            this.Name = "Square";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "Pixels";
    }
    class Program
    {
        static void Main ( string[] args )
        {
            var res = new Triangle(new VectorRenderer()).ToString(); // returns "Drawing Triangle as pixels
           Console.WriteLine(res);
        }
    }
}
