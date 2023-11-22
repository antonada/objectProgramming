using System;
using System.Collections.Generic;


namespace ex_2
{
    abstract class Person
    {
        public string FirstName;
        public string LastName;
        public string PASEL;

        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetPasel(string pasel)
        {
            PASEL = pasel;
        }

        public abstract int GetAge();
        public abstract string GetGender();
        public abstract string GetEducationInfo();
        public abstract string GetFullName();
        public abstract bool CanGoAloneToHome();
    }

    class Student : Person
    {
        public string School;
        private bool canGoAloneToHome;

        public void SetSchool(string school)
        {
            School = school;
        }
        public void SetCanGoHomeAlone(bool canGoHomeAlone)
        {
            canGoAloneToHome = canGoHomeAlone;
        }
        public void ChangeSchool(string newSchool)
        {
            School = newSchool;
        }

        public override int GetAge()
        {
            return 18;
        }

        public override string GetGender()
        {
            return PASEL[9] % 2 == 0 ? "Female" : "Male";
        }
        public override string GetEducationInfo()
        {
            return $"Student at {School}";
        }
        public override string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        public override bool CanGoAloneToHome()
        {
            return canGoAloneToHome || GetAge() >= 12;
        }

        public string Info()
        {
            if (GetAge() < 12 && !canGoAloneToHome)
            {
                return "Under 12 cannot return alone unless they have permission";
            }
            else
            {
                return "Student can go home alone";
            }
        }
    }

    class Teacher : Student
    {
        private string AcademicTitle;
        private List<Student> SubordinateStudents;

        public Teacher(string academicTitle)
        {
            AcademicTitle = academicTitle;
            SubordinateStudents = new List <Student>();
        }
        public void AddSubordinateStudent(Student student)
        {
            SubordinateStudents.Add(student);
        }
        public void WhichStudentCanGoHomeAlone()
        {
            Console.WriteLine("Students who can go home alone:");
            foreach (var student in SubordinateStudents)
            {
                if (student.CanGoAloneToHome())
                {
                    Console.WriteLine($"{student.GetFullName()} - {student.GetGender()} - {student.Info()}");
                }
            }
        }
        public void PrintTeacherAndStudentsInfo(string dayOfWeek)
        {
            Console.WriteLine($"{School} On: {dayOfWeek}");
            Console.WriteLine($"Teacher: {AcademicTitle} {FirstName} {LastName}");
            Console.WriteLine("List of students:");
            int lp = 1;
            foreach (var student in SubordinateStudents)
            {
                Console.WriteLine($"{lp}. {student.GetFullName()} - {student.GetGender()} - {student.Info()}");
                lp++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher("Dr.");
            teacher.SetFirstName("Anton");
            teacher.SetLastName("Hryshchenko");
            teacher.SetSchool("School");

            Student student1 = new Student();
            student1.SetFirstName("Johny");
            student1.SetLastName("Depp");
            student1.SetSchool("School");
            student1.SetCanGoHomeAlone(false);

            Student student2 = new Student();
            student2.SetFirstName("Robert");
            student2.SetLastName("Polson");
            student2.SetSchool("School");
            student2.SetCanGoHomeAlone(true);

            teacher.AddSubordinateStudent(student1);
            teacher.AddSubordinateStudent(student2);

            teacher.PrintTeacherAndStudentsInfo("Whensday");
            teacher.WhichStudentCanGoHomeAlone();
        }
    }
}
