using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private List<int> _coveredExams;
        private IUniversity _university;

        public Student(int studentId, string firstName, string lastName)
        {
            this.Id = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this._coveredExams = new List<int>();
            this._university = null;
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                _lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams
        {
            get { return _coveredExams.AsReadOnly(); }
        }

        public IUniversity University
        {
            get { return _university; }
            private set { _university = value; }
        }

        public void CoverExam(ISubject subject)
        {
            this._coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}