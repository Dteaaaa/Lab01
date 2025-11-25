using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_01
{
    internal class Student : Person   // <== SỬA Ở ĐÂY
    {
        private float averageScore;
        private string faculty;

        public Student() { }

        public Student(string id, string fullname, float averageScore, string faculty)
            : base(id, fullname)   // (1)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        public float AverageScore
        {
            get => averageScore;
            set => averageScore = value;
        }

        public string Faculty
        {
            get => faculty;
            set => faculty = value;
        }

        public override void Input()   // (2)
        {
            base.Input();   // gọi Input() của Person

            Console.Write("Khoa: ");
            Faculty = Console.ReadLine();

            Console.Write("Điểm trung bình: ");
            AverageScore = float.Parse(Console.ReadLine());
        }

        public override void Output()   // (3)
        {
            base.Output();   // gọi Output() của Person

            Console.WriteLine(" - Điểm trung bình: {0} - Khoa: {1}",
                this.AverageScore, this.Faculty);
        }
    }
}
