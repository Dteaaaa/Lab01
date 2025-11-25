using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_01
{
    internal class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. Xuất sinh viên khoa CNTT");
                Console.WriteLine("7. Giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. Sinh viên điểm cao nhất khoa CNTT");
                Console.WriteLine("9. Số lượng sinh viên theo xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");

                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        PrintStudents();
                        break;
                    case 4:
                        PrintTeachers();
                        break;
                    case 5:
                        CountLists();
                        break;
                    case 6:
                        PrintCNTTStudents();
                        break;
                    case 7:
                        PrintTeacherQuan9();
                        break;
                    case 8:
                        PrintTopCNTTStudent();
                        break;
                    case 9:
                        CountRank();
                        break;
                }

            } while (choice != 0);
        }

        // 1. Thêm sinh viên
        static void AddStudent()
        {
            Student s = new Student();
            Console.WriteLine("Nhập thông tin sinh viên:");
            s.Input();
            students.Add(s);
        }

        // 2. Thêm giáo viên
        static void AddTeacher()
        {
            Teacher t = new Teacher();
            Console.WriteLine("Nhập thông tin giáo viên:");
            t.Input();
            teachers.Add(t);
        }

        // 3. Xuất danh sách sinh viên
        static void PrintStudents()
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (var s in students)
                s.Output();
        }

        // 4. Xuất danh sách giáo viên
        static void PrintTeachers()
        {
            Console.WriteLine("=== Danh sách giáo viên ===");
            foreach (var t in teachers)
                t.Output();
        }

        // 5. Số lượng
        static void CountLists()
        {
            Console.WriteLine($"Tổng số sinh viên: {students.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teachers.Count}");
        }

        // 6. Sinh viên CNTT
        static void PrintCNTTStudents()
        {
            Console.WriteLine("=== Sinh viên khoa CNTT ===");
            var result = students.Where(s => s.Faculty.ToUpper() == "CNTT");
            foreach (var s in result)
                s.Output();
        }

        // 7. Giáo viên Quận 9
        static void PrintTeacherQuan9()
        {
            Console.WriteLine("=== Giáo viên ở Quận 9 ===");
            var result = teachers.Where(t => t.Address.Contains("Quận 9"));
            foreach (var t in result)
                t.Output();
        }

        // 8. SV điểm cao nhất khoa CNTT
        static void PrintTopCNTTStudent()
        {
            var cntt = students.Where(s => s.Faculty.ToUpper() == "CNTT").ToList();

            if (cntt.Count == 0)
            {
                Console.WriteLine("Không có SV CNTT.");
                return;
            }

            float max = cntt.Max(s => s.AverageScore);

            Console.WriteLine("=== SV điểm cao nhất khoa CNTT ===");
            foreach (var s in cntt.Where(s => s.AverageScore == max))
                s.Output();
        }

        // 9. Số lượng SV theo xếp loại
        static void CountRank()
        {
            int xs = students.Count(s => s.AverageScore >= 9);
            int g = students.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int k = students.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int tb = students.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            int y = students.Count(s => s.AverageScore < 5);

            Console.WriteLine("=== Số lượng xếp loại ===");
            Console.WriteLine($"Xuất sắc: {xs}");
            Console.WriteLine($"Giỏi: {g}");
            Console.WriteLine($"Khá: {k}");
            Console.WriteLine($"Trung bình: {tb}");
            Console.WriteLine($"Yếu: {y}");
        }
    }
}
