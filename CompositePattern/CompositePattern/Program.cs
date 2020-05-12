using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    class Program
    {
        public class GraphicObjects
        {
            public virtual string Name { get; set; } = "Group";
            public string Color { get; set; }

            private Lazy<List<GraphicObjects>> children = new Lazy<List<GraphicObjects>>();
            public List<GraphicObjects> Children => children.Value;

            private void Print(StringBuilder stb, int depth)
            {
                stb.Append(new string('*', depth))
                    .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color}")
                    .AppendLine(Name);
                foreach (GraphicObjects child in Children)
                {
                    child.Print(stb,depth+1);
                }

            }
            public override string ToString()
            {
                var sb = new StringBuilder();
                Print(sb,0);
                return sb.ToString();
            }
        }

        public class Circle:GraphicObjects
        {
            public override string Name => "circle";
        }

        public class Square:GraphicObjects
        {
            public override string Name => "square";
        }
        static void Main ( string[] args )
        {
            //var drawing = new GraphicObjects();
            //drawing.Name = "My Drawing";

            ////single addition
            //drawing.Children.Add(new Square{Color = "Red"});
            //drawing.Children.Add(new Circle{Color = "Blue"});

            ////collection addition
            //var group = new GraphicObjects();
            //group.Children.Add(new Circle{Color = "Green"});
            //group.Children.Add(new Square{Color = "Yelllow"});

            //drawing.Children.Add(group);

            //Console.WriteLine(drawing);

            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}
