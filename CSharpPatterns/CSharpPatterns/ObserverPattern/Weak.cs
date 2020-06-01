using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CSharpPatterns.ObserverPattern
{
    public class Button
    {
        public event EventHandler clicked;

        public void Fire()
        {
            clicked?.Invoke(this,EventArgs.Empty);
        }

    }

    public class Window
    {
        public Window(Button btn)
        {
           btn.clicked += ButtonClicked;
           
           //Weak Event manager is not available in .Net Core 3.1 yet. Maybe in .Net 5!!however, this is 
           //how it would be used. 
          // WeakEventManager<Button, EventArgs>.AddHandler(btn, "clicked", ButtonClicked);
        }


        public void ButtonClicked(object sender,EventArgs e)
        {
            Console.WriteLine("Button clicked (window handler");
        }


        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }



    public class Weak
    {
    }
}
