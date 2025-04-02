using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            if (students.FindByName(name) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(TechnicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject;
            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);
            }

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> idsRequiredSubjects = new List<int>();
            foreach (string requiredSubject in requiredSubjects)
            {
                ISubject subject = subjects.FindByName(requiredSubject);
                idsRequiredSubjects.Add(subject.Id);
            }

            IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, idsRequiredSubjects);
            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(' ')[0];
            string lastName = studentName.Split(' ')[1];

            if (students.FindByName(studentName) == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (universities.FindByName(universityName) == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            bool examNotCovered = false;

            foreach (int exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(exam))
                {
                    examNotCovered = true;
                    break;
                }
            }

            if (examNotCovered == true)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null)
            {
                if (student.University.Name == universityName)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
                }
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }

            if (subjects.FindById(subjectId) == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }

            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            int studentsCount = students.Models.Where(s => s.University == university).Count();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}