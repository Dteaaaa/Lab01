using Lab02_01;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace Lab02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hiển thị tiếng Việt chuẩn
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Sinh viên thuộc khoa CNTT");
                Console.WriteLine("4. Sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm TB tăng dần");
                Console.WriteLine("6. Sinh viên có điểm TB >= 5 và thuộc khoa CNTT");
                Console.WriteLine("7. Sinh viên có điểm TB cao nhất thuộc khoa CNTT");
                Console.WriteLine("8. Số lượng sinh viên theo từng xếp loại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        CountRank(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // ===== 1. Thêm sinh viên =====
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== NHẬP THÔNG TIN SINH VIÊN ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // ===== Hiển thị danh sách sinh viên =====
        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== DANH SÁCH SINH VIÊN ===");

            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách hiện đang trống!");
                return;
            }

            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        // ===== 3. Sinh viên thuộc khoa CNTT =====
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} ===", faculty);
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }

        // ===== 4. Sinh viên có điểm TB >= 5 =====
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minScore)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} ===", minScore);
            var students = studentList
                .Where(s => s.AverageScore >= minScore)
                .ToList();
            DisplayStudentList(students);
        }

        // ===== 5. Sắp xếp sinh viên theo điểm TB tăng dần =====
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên sắp xếp theo điểm TB tăng dần ===");
            var sortedStudents = studentList
                .OrderBy(s => s.AverageScore)
                .ToList();
            DisplayStudentList(sortedStudents);
        }

        // ===== 6. Sinh viên khoa CNTT và điểm TB >= 5 =====
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minScore)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1} ===", minScore, faculty);
            var students = studentList
                .Where(s => s.AverageScore >= minScore && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(students);
        }

        // ===== 7. Sinh viên có điểm TB cao nhất thuộc khoa CNTT =====
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Sinh viên có điểm TB cao nhất thuộc khoa {0} ===", faculty);
            var studentsInFaculty = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            if (!studentsInFaculty.Any())
            {
                Console.WriteLine("Không có sinh viên thuộc khoa {0}!", faculty);
                return;
            }

            float maxScore = studentsInFaculty.Max(s => s.AverageScore);

            var topStudents = studentsInFaculty
                .Where(s => s.AverageScore == maxScore)
                .ToList();

            DisplayStudentList(topStudents);
        }

        // ===== 8. Số lượng sinh viên theo xếp loại =====
        static void CountRank(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng sinh viên theo xếp loại ===");

            var rankGroups = studentList.GroupBy(s =>
            {
                float score = s.AverageScore;
                if (score >= 9) return "Xuất sắc";
                else if (score >= 8) return "Giỏi";
                else if (score >= 7) return "Khá";
                else if (score >= 5) return "Trung bình";
                else if (score >= 4) return "Yếu";
                else return "Kém";
            });

            foreach (var group in rankGroups)
            {
                Console.WriteLine("{0}: {1}", group.Key, group.Count());
            }
        }
    }
}