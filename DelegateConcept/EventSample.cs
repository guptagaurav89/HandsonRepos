using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateConcept
{
    public class EventSample
    {
        //public static void Main(string[] args)
        //{
        //    Room room = new Room();
        //    room.Alert += OnAlert;

        //    room.temperature = 65;
            
        //    Console.ReadKey();

        //}
        
        //static void OnAlert(object o)
        //{
        //    Room room = (Room)o;
        //    Console.WriteLine("Shutting Down. Room temp is {0}", room.temperature);
        //}

        static void OnAlert(object o, EventArgs e)
        {
            Room room = (Room)o;
            Console.WriteLine("Shutting Down. Room temp is {0}", room.temperature);
        }
    }

    //class Room
    //{
    //    public event Action<object> Alert;

    //    private int _temperature;
    //    public int temperature
    //    {
    //        get { return this._temperature; }
    //        set { this._temperature = value;
    //            if (temperature > 60)
    //            {
    //                if (Alert != null) { Alert(this); }
    //            }
    //        }
    //    }
    //}

    class Room
    {        
        public event EventHandler Alert;

        private int _temperature;
        public int temperature
        {
            get { return this._temperature; }
            set
            {
                this._temperature = value;
                if (temperature > 60)
                {
                    Alert?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
