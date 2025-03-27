using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int _id;
        private string _name;
        private string _category;
        private int _capacity;
        private List<int> _requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
            this._requiredSubjects = requiredSubjects.ToList();
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                _name = value;
            }
        }

        public string Category
        {
            get { return _category; }
            private set
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException(ExceptionMessages.CategoryNotAllowed, value);
                }
                _category = value;
            }
        }

        public int Capacity
        {
            get { return _capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                _capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects
        {
            get { return _requiredSubjects.AsReadOnly(); }
        }
    }
}