using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Student Data: ");
                Console.WriteLine("Name\tClass");

                string directorypath = "C:\\simplilearn\\Project3\\";
                List<string> studentData = ReadStudentData(Path.Combine(directorypath, "studentdata.txt"));

                DisplayStudentData(studentData);

                Console.WriteLine("\nStudent Data after Sorting:");
                studentData = SortStudentDataByName(studentData);
                DisplayStudentData(studentData);

                Console.Write("\nEnter a name to search: ");
                string searchName = Console.ReadLine();
                SearchStudentByName(studentData, searchName);

                Console.ReadKey();
            }

            static List<string> ReadStudentData(string filePath)
            {
                List<string> studentData = new List<string>();
                try
                {
                    studentData = new List<string>(File.ReadAllLines(filePath));
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
                return studentData;
            }

            static void DisplayStudentData(List<string> studentData)
            {
                foreach (string data in studentData)
                {
                    Console.WriteLine(data);
                }
            }

            static List<string> SortStudentDataByName(List<string> studentData)
            {
                return studentData.OrderBy(s => s.Split('\t')[0].Trim()).ToList();
            }

            static void SearchStudentByName(List<string> studentData, string searchName)
            {
            var result = studentData.Where(s => s.Split(new[] { "Class-" }, StringSplitOptions.None)[0].Trim()
            .Equals(searchName.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
          
            if (result.Any())
                {
                    Console.WriteLine("\nStudent Found:");
                    DisplayStudentData(result);
                }
                else
                {
                    Console.WriteLine($"\nNo students found with the name '{searchName}'.");
                }
            }
        }
    }
