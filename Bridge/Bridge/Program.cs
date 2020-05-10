using System;

namespace Bridge
{

    public interface IRenderer
    {
        void RenderCircle(float radius);
    }


    public class VectorRenderer:IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of {radius}");
        }
    }

    public class RasterRenderer:IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels from circle with radius {radius}");
        }
    }
    
    //bridging happens here
    public abstract class Shape
    {
        protected IRenderer _renderer;

        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }


    public class Circle:Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public Circle(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            _renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new RasterRenderer(); // In reality we would use DI
            var circle = new Circle(renderer,5);
            circle.Draw();
            circle.Resize(5);
            circle.Draw();
        }
    }
}