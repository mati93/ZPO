namespace Finances.Employees.Classes
{
    public abstract class Person
    {
        private int Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Postcode { get; set; }

        public Person(int id, string name, string surname, int age, int postcode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Postcode = postcode;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public string GetName()
         {
            return Name;
         }

         protected void SetName(string name)
         {
            Name = name;
         }

        public abstract string Interests();
    }
}
