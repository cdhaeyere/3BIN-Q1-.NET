using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PersonList
    {
        private static PersonList instance;
        private IDictionary<String, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<String, Person>();
        }

        public static PersonList getInstance()
        {

            if (instance == null)
                instance = new PersonList();

            return instance;
        }

        public void addPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            personMap.Add(person.Name, person);
        }

        public IEnumerator<Person> personList()
        {
            return personMap.Values.GetEnumerator();
        }
    }
}
