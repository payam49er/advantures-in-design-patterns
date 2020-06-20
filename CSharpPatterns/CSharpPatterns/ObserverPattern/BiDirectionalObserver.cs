using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
//using CSharpPatterns.Annotations;

namespace CSharpPatterns.ObserverPattern
{
    //We want to have the name of the product and ProductName to be the same whenever
    //the other one changes. How do we do this?
    public class Product:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                if (value == name)return;
                name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Product: {Name}";
        }
    }

    public class BiWindow:INotifyPropertyChanged
    {
        private string productName;

        public string ProductName
        {
            get => productName;
            set
            {
                if (value == productName) return;
                productName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $" Product Name : {ProductName}";
        }
    }



    //taking bidirectional binding to a separate class

    public sealed class BirectionalBinding:IDisposable
    {

        private bool disposed;

        //we need to bind two objects to each other
        //we also need to specify which properties need to bind to each other

        public BirectionalBinding(INotifyPropertyChanged first,Expression<Func<object>> firstProperty,
            INotifyPropertyChanged second,Expression<Func<object>> secondProperty)
        {
            if (firstProperty.Body is MemberExpression firstExpr && secondProperty.Body is MemberExpression secondExpr)
            {
                if (firstExpr.Member is PropertyInfo firstProp && secondExpr.Member is PropertyInfo secondProp)
                {
                    first.PropertyChanged += (s, e) =>
                    {
                        if (!disposed)
                        {
                            secondProp.SetValue(second, firstProp.GetValue(first));
                        }
                    };

                    second.PropertyChanged += (s, e) =>
                    {
                        if (!disposed)
                        {
                            firstProp.SetValue(first,secondProp.GetValue(second));
                        }
                    };
                }
            }
        }


        public void Dispose()
        {
            disposed = true;
        }
    }



}
