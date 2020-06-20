using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.StrategyPattern
{
    public enum OutputFormat
    {
        Markdown,
        Html
    }

    
    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }


    public class HtmlListStrategy:IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" <li>{item}</li>");
        }
    }


    public class MarkdownListStrategy:IListStrategy
    {
        public void Start(StringBuilder sb)
        {
          
        }

        public void End(StringBuilder sb)
        {
            
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    listStrategy = new HtmlListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }   
         }



        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb,item);
            }
            listStrategy.End(sb);
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }



    //equality and comparison
    public class StrategyPerson : IComparable<StrategyPerson>, IEquatable<StrategyPerson>
    {
        private sealed class IdNameAgeRelationalComparer : IComparer<StrategyPerson>
        {
            public int Compare(StrategyPerson x, StrategyPerson y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                var idComparison = x.Id.CompareTo(y.Id);
                if (idComparison != 0) return idComparison;
                var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                if (nameComparison != 0) return nameComparison;
                return x.Age.CompareTo(y.Age);
            }
        }

        public static IComparer<StrategyPerson> IdNameAgeComparer { get; } = new IdNameAgeRelationalComparer();

        public bool Equals(StrategyPerson other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Name == other.Name && Age == other.Age;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StrategyPerson) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Age;
                return hashCode;
            }
        }

        public static bool operator ==(StrategyPerson left, StrategyPerson right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(StrategyPerson left, StrategyPerson right)
        {
            return !Equals(left, right);
        }

        public int CompareTo(StrategyPerson other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var idComparison = Id.CompareTo(other.Id);
            if (idComparison != 0) return idComparison;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return Age.CompareTo(other.Age);
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
