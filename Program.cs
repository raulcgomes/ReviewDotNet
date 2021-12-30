using System;

namespace ReviewDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            string userOption = GetUserOption();
            var StudentIndex = 0;
            decimal scoreSum = 0;
            decimal scoreAvarage = 0;

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("Set student name:");
                        Student student = new Student();
                        student.Name = Console.ReadLine();
                        
                        Console.WriteLine("Set student score:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal score)){
                            student.Score = score;
                        } else {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        students[StudentIndex] = student;
                        StudentIndex++;

                        break;
                    case "2":
                        foreach (var s in students) {
                            if (!string.IsNullOrEmpty(s.Name))
                            {
                                Console.WriteLine($"Student: {s.Name}, Score: {s.Score}");   
                            }
                        }
                        break;
                    case "3":
                        foreach (var stud in students)
                        {
                            if (!string.IsNullOrEmpty(stud.Name))
                            {
                                scoreSum += stud.Score;
                            }    
                        }
                        scoreAvarage = scoreSum / StudentIndex;
                        Console.WriteLine($"The general avarege is: {scoreAvarage}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();

            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - Insert new student");
            Console.WriteLine("2 - List students");
            Console.WriteLine("3 - General average");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine();
            return userOption;
        }
    }
}
