using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace SOLID
{
    //every class needs to have one reason to change
    //class has to be about one thing, one responsibility
   public class Journal
    {
        private readonly List<string> journals = new List<string>();
        private static int index = 0;
        public void CreateJournal(string text)
        {
            var journal = $"{++index}: {text}";
            journals.Add(journal);
        }

        // other methods

        //but if we want to do persistance, we better create a class for persistance to deal with database stuff and persisting all sorts of files including a journal


    }


   public class Persist
   {
       public void SaveToFile(object j, string fileName, bool overwrite = false)
       {
           if (overwrite || !File.Exists(fileName))
           {
               //logic to persist
           }
       }
   }
}
