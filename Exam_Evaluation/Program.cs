using ScoreCard;
using System.Runtime.Intrinsics.X86;

namespace ScoreCard
{
    class Student
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public int Math { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int Language { get; set; }
        public int SST { get; set; }

        public bool Iscleared;
        internal object Grade;

        internal int sum { get;set; }
        public int  Maxscore { get; set; }
    }

    class ScoreCard
    {
        int n = 0;
        Student[] students;
        public void AcceptDetails()
        {
            Console.WriteLine("Enter the number of students");
            n = Convert.ToInt16(Console.ReadLine());
            students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter Details for Student {i + 1}");
                Console.WriteLine("Enter Roll No");
                int rollno = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Student Name");
                string studentname = Console.ReadLine();
                Console.WriteLine("Enter Marks for Maths");
                int maths = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for Science");
                int science = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for English");
                int english = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for Language");
                int lang = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for SST");
                int sst = Convert.ToInt16(Console.ReadLine());
                students[i] = new Student() { RollNo = rollno, StudentName = studentname, Math = maths, Science = science, English = english, Language = lang, SST = sst };
            }
        }

        public void ShowDetails()
        {
            int sum = 0;
            int max = 0;
            int avg = 0;
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Roll No: {students[i].RollNo} Name: {students[i].StudentName}");
                Console.WriteLine($"Math: {students[i].Math}, Science: {students[i].Science}, English: {students[i].English}, Language: {students[i].Language}, SST: {students[i].SST}");
                sum = students[i].Math + students[i].Science + students[i].English + students[i].Language + students[i].SST;
                Console.WriteLine($"Total Score is {sum}");
                
                if (sum > max)
                {
                    max = sum;
                }
                avg = sum / 5;
            }
            Console.WriteLine($"Maximum Score is {max}");
            Console.WriteLine("Average:" + avg);
        }
        public void StudentsGrade()
        {
            foreach (Student student in students)
            {
                double studentAverage = student.sum / 5;
                string Grade;
                if (studentAverage >= 95)
                {
                    Grade = "A";
                }
                else if (studentAverage >= 80)
                {
                    Grade = "B";
                }
                else if (studentAverage >= 70)
                {
                    Grade = "C";
                }
                else if (studentAverage >= 60)
                {
                    Grade = "D";
                }
                else if (studentAverage >= 50)
                {
                    Grade = "E";
                }
                else
                {
                    Grade = "F";
                }
                Console.WriteLine($"Grade of {student.StudentName} (Roll Number: {student.RollNo}): {Grade}");
            }
        }
        public void Topscorer()
        {
            int topscore = 0;
            int topscoreindex = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Maxscore > topscore)
                {
                    topscore = students[i].Maxscore;
                    topscoreindex = i;
                }
            }
            Console.WriteLine($"Top scorer: {students[topscoreindex].StudentName}, Roll No: {students[topscoreindex].RollNo}");

        }

        public void ResultOfStudents()
        {
            int pass = 0;
            int fail = 0;
            foreach (Student student in students)
            {
                if (student.Math >= 35 && student.Science >= 35 && student.English >= 35
               && student.Language >= 35 && student.SST >= 35)
                {
                    pass++;
                }
                else
                {
                    fail++;
                }
            }

            Console.WriteLine($"Number of students who need to repeat the examination: {fail}");
            Console.WriteLine($"Number of students who passed the examination: {pass}");

        }
        public void Re_exam()
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Iscleared == false)
                {
                    Console.WriteLine($"{students[i].StudentName},{students[i].RollNo} Has to reappear the exam ");
                }

            }

        }

        public void Scorecard()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"{students[i].StudentName}SCORECARD");
                Console.WriteLine($"Name:  {students[i].StudentName}");
                Console.WriteLine($"Rollno:  {students[i].RollNo}");
                Console.WriteLine($"Maths Marks:  {students[i].Math}");
                Console.WriteLine($"Science Marks:  {students[i].Science}");
                Console.WriteLine($"English Marks:  {students[i].English}");
                Console.WriteLine($"Language marks:  {students[i].Language}");
                Console.WriteLine($"Social Studies Marks:  {students[i].SST}");
                Console.WriteLine($"Totalmarks:  {students[i].Maxscore}");
                Console.WriteLine($"Grade:  {students[i].Grade}");
            }

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                ScoreCard card = new ScoreCard();
                card.AcceptDetails();
                card.ShowDetails();
                card.ResultOfStudents();
                card.Re_exam();
                card.StudentsGrade();
                card.Topscorer();
                card.Scorecard();
            }
        }
    }
}

