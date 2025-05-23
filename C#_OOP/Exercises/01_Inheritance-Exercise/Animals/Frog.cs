﻿using System;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender) { }

        public override string ProduceSound()
        {
            return "Ribbit";
        }

        public override string ToString()
        {
            return "Frog";
        }
    }
}