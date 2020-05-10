using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BindingFlags = System.Reflection.BindingFlags;

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
           Console.WriteLine("Openning a file"); 
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
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICommand, OpenCommand>()
                .AddTransient<ICommand, SaveCommand>()
                .AddTransient(typeof(Button))
                .AddTransient<ICommand,Button>(cmd=>new Button(cmd))
                .AddTransient(typeof(Editor))
                .BuildServiceProvider();
            
            var editorService = serviceProvider.GetService<Editor>();
            editorService.ClickAll();
        }
    }
}