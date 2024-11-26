using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ListBoxComboBox
{
    internal class ListOfPersons
    {
        public ObservableCollection<Person> Persons;
        
        public ListOfPersons()
        {
            Persons = new ObservableCollection<Person>();
            LoadPersons("Persons.txt");
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
            Persons.Clear();
            StreamReader reader = File.OpenText(file);
            string lineOfData;
            while ((lineOfData = reader.ReadLine()) != null)
            {
                string[] serializedLineOfData = lineOfData.Split(';');
                EducationLevel educationLevel;
                switch (serializedLineOfData[2])
                {
                    case "podstawowe": educationLevel = EducationLevel.podstawowe; break;
                    case "średnie": educationLevel = EducationLevel.średnie; break;
                    case "wyższe": educationLevel = EducationLevel.wyższe; break;
                    default: educationLevel = EducationLevel.podstawowe;break;
                }
                Persons.Add(new Person(serializedLineOfData[0], serializedLineOfData[1], educationLevel));
            }
            reader.Close();
        }
        public void SavePersons(string file)
        {
            File.WriteAllText(file, string.Empty);
            StreamWriter writer;
            if (!File.Exists(file))
            {
                writer = File.CreateText(file);
            }
            else
            {
                writer = new StreamWriter(file);
            }
            foreach (Person person in Persons)
            {
                writer.WriteLine($"{person.FirstName};{person.LastName};{person.Education}");
            }
            writer.Close();
        }
    }
}
