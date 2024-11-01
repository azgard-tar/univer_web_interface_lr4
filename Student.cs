using System;

namespace LR4
{
    internal class Student
    {
        public string FullName;
        public double Grade;
        private int Age;
        internal string Group;
        protected internal bool IsBudget;

        // Конструктор
        public Student(string fullName, double grade, int age, string group, bool isBudget)
        {
            FullName = fullName;
            Grade = grade;
            Age = age;
            Group = group;
            IsBudget = isBudget;
        }

        // Методи
        public void Greet()
        {
            Console.WriteLine($"Hello, my name is {FullName}.");
        }

        private int GetAge()
        {
            return Age;
        }

        protected string GetGroup()
        {
            return Group;
        }
    }
}
