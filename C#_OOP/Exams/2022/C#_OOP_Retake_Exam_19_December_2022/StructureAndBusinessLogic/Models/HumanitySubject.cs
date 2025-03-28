﻿namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        private const double subjectRate = 1.15;

        public HumanitySubject(int subjectId, string subjectName) : base(subjectId, subjectName, subjectRate)
        {
        }
    }
}