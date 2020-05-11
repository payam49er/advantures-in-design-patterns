using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AdapterWithDI
{
    public interface ICommand
    {
        void Execute();
    }


    public class SaveCommand:ICommand
    {
        public void Execute()
        {
           Console.WriteLine("Saving a file"); 
        }
    }


    public class OpenCommand:ICommand
    {
        public void Execute()
        {
           Console.WriteLine("Opening a file"); 
        }
    }

    public class Button
    {
        private readonly ICommand _command;
        
        public Button(ICommand command)
        {
            _command = command;
        }

        public void Click()
        {
            _command.Execute();
        }

    }

    public class Editor
    {
        private IEnumerable<Button> _buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            _buttons = buttons;
        }

        public void ClickAll()
        {
            foreach (Button button in _buttons)
            {
                button.Click();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //setting up the DI
            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>();
            b.RegisterType<OpenCommand>().As<ICommand>();
            //b.RegisterType<Button>();
            b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterType<Editor>();
            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                editor.ClickAll();
            }
        }
    }
}