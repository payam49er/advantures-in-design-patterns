using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Threading;

namespace CSharpPatterns.VisitorPattern
{
    public abstract class Expression
    {
        public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        public double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }
        public override void Print(StringBuilder sb)
        {
            sb.Append(value);
        }
    }

    public class AdditionExpression:Expression
    {
        public Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            left.Print(sb);
            sb.Append("+");
            right.Print(sb);
            sb.Append(")");
        }
    }


    //doing it with dynamic
    //issues:
    //dynamic impacts performance big time. 
    //If you are missing something, such a print overload,at runtime you will have exception
    public class ExpressionPrinter
    {
        public void Print(AdditionExpression ae,StringBuilder sb)
        {
            sb.Append("(");
            Print((dynamic)ae.left,sb);
            sb.Append("+");
            Print((dynamic)ae.right,sb);
            sb.Append(")");
        }

        public void Print(DoubleExpression de,StringBuilder sb)
        {
            sb.Append(de.value);
        }
    }



    //Acyclyc approach

    public interface IVisitor<Tvisitable>
    {
        void Visit(Tvisitable obj);
    }

    //marker interface, doesn't do anything from a functional perspective
    public interface IVisitor {}


    public abstract class VExpression
    {
        public virtual void Accept(IVisitor visitor)
        {
            if(visitor is IVisitor<VExpression> typed)
                typed.Visit(this);
        }

        public class VDoubleExpression:VExpression
        {
            public double value;

            public VDoubleExpression(double value)
            {
                this.value = value;
            }

            public override void Accept(IVisitor visitor)
            {
                if(visitor is IVisitor<VDoubleExpression> typed)
                    typed.Visit(this);
            }
        }

        public class VAdditionExpression : VExpression
        {
            public VExpression Left, Right;

            public VAdditionExpression(VExpression left, VExpression right)
            {
                Left = left;
                Right = right;
            }

            public override void Accept(IVisitor visitor)
            {
                if (visitor is IVisitor<VAdditionExpression> typed)
                    typed.Visit(this);
            }
        }


        public class VExpressionPrinter:IVisitor,IVisitor<VExpression>,IVisitor<VDoubleExpression>,IVisitor<VAdditionExpression>
        {
            private StringBuilder sb = new StringBuilder();
            public void Visit(VExpression obj)
            {
                //better leave it to the concrete type to take care of this
            }

            public void Visit(VDoubleExpression obj)
            {
                sb.Append(obj.value);
            }

            public void Visit(VAdditionExpression obj)
            {
                sb.Append("(");
                obj.Left.Accept(this);
                sb.Append("+");
                obj.Right.Accept(this);
                sb.Append(")");
            }


            public override string ToString() => sb.ToString();
        }
    }

}
