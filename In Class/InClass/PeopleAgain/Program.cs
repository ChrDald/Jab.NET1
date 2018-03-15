using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleAgain
{
    class Person
    {
        private String PName;
        private int PAge;

        public Person(String name, int age)
        {
            Name = name;    // Name (capital N) calls the getters/setters for the Name string below, and name (lowercase) refers to the value passed to the constructor
            Age = age;
        }

        public String Name  // c# style getters and setters
        {
            get
            {
                return PName;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the name has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {

                }
                {
                    PName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return PAge;
            }
            set
            {
                if (value > 150 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    PAge = value;
                }
                
            }
        }
        public override string ToString()
        {
            return ("Name: " + Name + " Age: " + Age);
        }
    }
        

    class Student : Person
    {
        /*
        public String Program { get; set; } // Auto-Implemented getter/setter syntax
        public double GPA { get; set; } 
        */
        private String SProgram;
        private double SGPA;

        public Student(String name, int age, String program, double gpa) : base(name, age)
        {
            Program = program;
            GPA = gpa;
        }

        public String Program
        {
            get
            {
                return SProgram;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the program has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    SProgram = value;
                }
            }
        }
        public double GPA
        {
            get
            {
                return SGPA;
            }
            set
            {
                if (value > 4.3 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    SGPA = value;
                }
            }
        }
        public override String ToString()
        {
            return "Student name: " + Name + " Student Age: " + Age + " Program: " + Program + " GPA: " + GPA;
        }
    }

    class Teacher : Person
    {
        private String TSubject;
        private double TYearsOfExperience;

        public Teacher(String name, int age, String subject, double yearsOfExperience) : base(name, age)
        {
            Subject = subject;
            YearsOfExperience = yearsOfExperience;
        }

        public String Subject
        {
            get
            {
                return TSubject;
            }
            set
            {
                var regex = new Regex(@"(\D|\s){1,20}");    // supposed to be any character except digits, 1 to 20 characters long
                // verify the subject has the right format
                if (!regex.IsMatch(value))
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    TSubject = value;
                }
            }
        }
        public double YearsOfExperience
        {
            get
            {
                return TYearsOfExperience;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new InvalidDataException("Invalid Name value...");
                }
                else
                {
                    TYearsOfExperience = value;
                }
            }
        }

        public override String ToString()
        {
            return "Teacher name: " + Name + " Teacher Age: " + Age + " Teaches: " + Subject + " Experience: " + YearsOfExperience;
        }
    }

    class Program
    {
        static List<Person> PeopleList = new List<Person>();

        static void Main(string[] args)
        {
            try
            {
                String[] fileLines = File.ReadAllLines(@"people.txt");
                String type = null;
                String name;
                String age;

                foreach (String lines in fileLines)
                {
                    // check if line contains valid data first 
                    // first get rid of the empty lines
                    String CurrentLine = lines.Trim();
                    if (CurrentLine == "")
                    {
                        continue;
                    }
                    // next check if the "person type" is correct

                    String[] peopleType = lines.Split(':'); // has to be SINGLE quotes here (google why)
                    String[] peopleNames = peopleType[1].Split(',');
                    
                    if (peopleNames.Length < 2)
                    {
                        continue;
                    }
                    else if (peopleNames.Length < 3) // for people of type "Person"
                    {
                        try
                        {
                            type = peopleType[0];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Index out of bounds @ String type = peopleType[0];");
                        }

                        // verify the type is valid (ex. not "Cookie")
                        if (!type.Equals("Person") && !type.Equals("Student") && !type.Equals("Teacher"))
                        {
                            Console.WriteLine(type + " --> Skipping invalid data...");
                            continue;
                        }
                        name = peopleNames[0];
                        age = peopleNames[1];
                        Person person = new Person(name, Int32.Parse(age)); // maybe handle this possible excetion?
                        PeopleList.Add(person);
                    }

                    else // for type "Student" or "Teacher"
                    {
                        type = peopleType[0];
                        if (!type.Equals("Person") && !type.Equals("Student") && !type.Equals("Teacher"))
                        {
                            Console.WriteLine(type + " --> Skipping invalid data...");
                            continue;
                        }

                        name = peopleNames[0];
                        age = peopleNames[1];

                        if (type.Equals("Student"))
                        {
                            // for students get GPA and Program (peopleNames[2 and 3])
                            Console.WriteLine("People Names [2]: " + peopleNames[2]);
                            Console.WriteLine("People Names [3]: " + peopleNames[3]);
                            try
                            {
                                double GPA = double.Parse(peopleNames[2]); // check for exceptions
                                String Program = peopleNames[3];
                                Student student = new Student(name, Int32.Parse(age), Program, GPA);
                                PeopleList.Add(student);
                            } catch (InvalidDataException)
                            {
                                // **NOTE** for SOME REASON, ALFRED IS THROWING THIS ERROR GOD KNOWS WHY
                                Console.WriteLine("Invalid Data Exception...");
                                continue;
                            }
                            

                        }
                        else if (type.Equals("Teacher"))
                        {
                            // for teachers get Subject and Experience

                            String Subject = peopleNames[2];
                            int YearsOfExp = Int32.Parse(peopleNames[3]);

                            Teacher teacher = new Teacher(name, Int32.Parse(age), Subject, YearsOfExp);
                            PeopleList.Add(teacher);
                        }
                    }

                }
                
                foreach (Person person in PeopleList)
                {
                    Console.Write(person.ToString());
                }
                
                Console.ReadKey();
            } catch (Exception)
            {
                Console.WriteLine("IO Error (probably)");
            }         
            
        }
    }
}
