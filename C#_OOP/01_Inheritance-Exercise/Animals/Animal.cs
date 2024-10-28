using System;

namespace Animals
{
    public class Animal
    {
        private string _gender;

        public Animal(string name, int age, string gender)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be empty");
            if (age < 0) throw new ArgumentException("Age cannot be negative");

            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; }
        public int Age { get; }
        public string Gender
        { 
            get => this._gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gender cannot be empty");

                this._gender = value;
            }
        }

        public virtual string ProduceSound() => "";
    }
}