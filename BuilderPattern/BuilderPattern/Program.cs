using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> elements = new List<HtmlElement>();
        private const int indentsize = 2;

        public HtmlElement(string name, string text)
        {
            if (name != null) Name = name;
            if (text != null) Text = text;
        }

        public HtmlElement()
        {
            
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ',indentsize*indent);
            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentsize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var element in elements)
            {
                sb.Append(element.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder Addchild(string childName, string childText)
        {
            var e = new HtmlElement(childName,childText);
            root.elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }
        public void Clear ()
        {
            root = new HtmlElement { Name = rootName };
        }

    }
    class Program
    {
        static void Main ( string[] args )
        {
            //var hello = "hello";
            //var sb = new HtmlBuilder("ul");
            //sb.Addchild("li", "Hello").Addchild("li", "Payam");
            //Console.WriteLine(sb.ToString());

            Person person = new Person();
            person.Name = "Payam";
            person.LastName = "Shoghi";
            person.Position = "Software Engineer";

            var me = Person.New.Called("Payam").WorksAsA("Fortis").Build();
            Console.WriteLine(me);

            Console.WriteLine("functional approach");
            var fme = new FuncPersonBuilder();
            var builtMe = fme.Called("Payam").WorksAs("Developer").Build();
            Console.WriteLine($"{builtMe.Name} works as {builtMe.Position}");
    
            Console.WriteLine("Faceted Person Building");
            var fpb = new FPersonBuilder();
            var meFpb = fpb.works.At("Fortis")
                .AsA("Engineer")
                .EarningIntAmount(150000)
                .lives.At("946 BushWick Ave")
                .In("NY City").WithPostcode("11221");
            var pm = (FacetedPerson) meFpb;
            Console.WriteLine(pm.ToString());


        }
    }
}
