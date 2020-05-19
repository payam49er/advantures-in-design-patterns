using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpPatterns.Annotations;

namespace CSharpPatterns.Proxy
{
    public class PersonVM
    {
        public string Name, LastName;
    }

    public class Notification:INotifyPropertyChanged
    {
        private readonly PersonVM _person;
        public Notification(PersonVM personVm)
        {
            this._person = personVm;
        }

        public string FirstName
        {
            get => _person.Name;
            set
            {
                if(_person.Name == value) return;
                _person.Name = value;
                OnPropertyChanged("FirstName");
            }

        }

        public string LastName
        {
            get => _person.LastName;
            set
            {
                if (_person.LastName == value) return;
                _person.LastName = value;
                OnPropertyChanged("LastName");
            }

        }




        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    class ViewModel
    {
    }
}
