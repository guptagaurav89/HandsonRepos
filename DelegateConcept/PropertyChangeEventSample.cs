using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConcept
{
    class PropertyChangeEventSample
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.PropertyChanged += OnPropertyChanged;

            person.PersonName = "Gaurav";

            Console.ReadKey();
        }

        static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Person person = (Person)sender;
            Console.WriteLine("Property {0} has a new value {1}", e.PropertyName, person.PersonName);
        }
    }

    class Person : INotifyPropertyChanged
    {
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        { }

        public Person(string value)
        { name = value; }

        public string PersonName {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("PersonName");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
