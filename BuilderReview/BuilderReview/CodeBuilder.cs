using System.Collections.Generic;
using System.Text;

namespace BuilderReview
{
 
    public class CodeBuilder 
    {
        private Dictionary<string, string> properties = new Dictionary<string, string>();
        private string className;
        private readonly string indent = new string(' ', 4);


        StringBuilder sb = new StringBuilder();

        public CodeBuilder ( string className )
        {
            this.className = className;
        }

        public override string ToString()
        {
            sb.AppendLine($"public class {className}");
            sb.AppendLine("{");
            foreach (KeyValuePair<string, string> property in properties)
            {
                sb.AppendLine($"{indent}public {property.Value} {property.Key};");
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
        public CodeBuilder AddField ( string fieldName, string typeName )
        {
            if (!properties.ContainsKey(fieldName))
            {
                properties.Add(fieldName, typeName);
            }

            return this;
        }
    }



}
