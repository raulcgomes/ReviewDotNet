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
                        decimal totalScore = 0;
                        var studentQuantity = 0;

                        for (int i = 0; i < students.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(students[i].Name)){
                                totalScore += students[i].Score;
                                studentQuantity++;
                            }
                        }
                        
                        var generalAvarage = totalScore / studentQuantity;
                        EnumConcept generalConcept;

                        if (generalAvarage < 2){
                            generalConcept = EnumConcept.E;
                        } else if (generalAvarage < 4){
                            generalConcept = EnumConcept.D;
                        } else if(generalAvarage < 6){
                            generalConcept = EnumConcept.C;
                        } else if(generalAvarage < 8){
                            generalConcept = EnumConcept.B;
                        } else {
                            generalConcept = EnumConcept.A;
                        }
                        

                        Console.WriteLine($"General avarage: {generalAvarage}, Concept: {generalConcept}");

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
