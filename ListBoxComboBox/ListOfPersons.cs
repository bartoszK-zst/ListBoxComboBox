using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxComboBox
{
    internal class ListOfPersons
    {
        public ObservableCollection<Person> Persons;
        
        public ListOfPersons()
        {
            Persons = new ObservableCollection<Person>();
            LoadPersons("plik.txt");
        }

        public void AddPerson(Person person)
        {
            Persons.Add(person);
        }
        public void RemovePerson(Person person)
        {
            Persons.Remove(person);
        }
        public void EditPerson(int index, Person person)
        {
            Persons[index] = person;
        }
        public void RemovePersonAt(int index)
        {
            if(index >= 0 && index < Persons.Count)
            Persons.RemoveAt(index);
        }
        public void LoadPersons(string file)
        {
            //TODO pobieranie z pliku
            Persons.Clear();
            Persons.Add(new Person("Adam", "Kowalski", EducationLevel.średnie));
            Persons.Add(new Person("Monika", "Dudek", EducationLevel.podstawowe));
            Persons.Add(new Person("Jan", "Sobieski", EducationLevel.wyższe));
            Persons.Add(new Person("Marta", "Nowak", EducationLevel.średnie));
        }
        public void SavePersons(string file)
        {
            //TODO zapisywanie do pliku
        }
    }
}
