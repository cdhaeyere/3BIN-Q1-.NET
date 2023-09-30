using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    [Serializable]
    internal class Person
    {
        private static readonly long _serialVersionUID = 1L;

        private readonly string _name;
	    private readonly string _firstname;
	    private readonly DateTime _birthDate;
	
	    public virtual string Name
        {
            get { return _name; }
        }

        public string Firstname
        {
            get { return _firstname; }
        }

        public string getBirthDate()
        {
            string formattedDate = _birthDate.ToString("dd-MM-yyyy");
            return formattedDate;
        }


        public Person(string name, string firstname, DateTime birthDate)
        {
            this._name = name;
            this._firstname = firstname;
            this._birthDate = birthDate;
        }

        public override string ToString()
        {
            return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate =  " + getBirthDate() + "]";
        }
    }
}
