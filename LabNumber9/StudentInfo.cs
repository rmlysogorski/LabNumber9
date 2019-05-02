using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNumber9
{
    class StudentInfo
    {
        public string name;
        public string hometown;
        public string favFood;
        public string favColor;
        public string favNum;

        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavFood { get; set; }
        public string FavColor { get; set; }
        public string FavNum { get; set; }

        public static List<StudentInfo> GetDataFromFile()
        {
            List<StudentInfo> studentList = new List<StudentInfo>();
            string[] items = new string[5];

            StreamReader file = new StreamReader(@"studentList.bin");
            string text = file.ReadToEnd();

            foreach (string line in text.Split('\n'))
            {
                if (line.Split('\t')[0] != string.Empty)
                {
                    int counter = 0;
                    foreach (string item in line.Split('\t'))
                    {
                        items[counter] = item;
                        counter++;
                    }
                    StudentInfo studentToAdd = new StudentInfo();
                    studentToAdd.name = items[0];
                    studentToAdd.hometown = items[1];
                    studentToAdd.favFood = items[2];
                    studentToAdd.favColor = items[3];
                    studentToAdd.favNum = items[4];
                    studentList.Add(studentToAdd);
                }

            }

            file.Close();

            studentList.Sort(delegate (StudentInfo a, StudentInfo b)
            {
                return a.name.Split().Last().CompareTo(b.name.Split().Last());
            });

            return studentList;
        }

        public static void WriteData(List<StudentInfo> studentList)
        {
            try
            {
                TextWriter tw = new StreamWriter(@"studentList.bin");

                foreach (StudentInfo s in studentList)
                {
                    tw.Write(s.name);
                    tw.Write("\t");
                    tw.Write(s.hometown);
                    tw.Write("\t");
                    tw.Write(s.favFood);
                    tw.Write("\t");
                    tw.Write(s.favColor);
                    tw.Write("\t");
                    tw.Write(s.favNum);
                    tw.Write("\n");
                }

                tw.Close();

            }
            catch (IOException E)
            {
                Console.WriteLine(E.Message);
            }
            return;
        }

        public static void PrintNames(List<StudentInfo> studentList)
        {
            int count = 1;
            foreach (StudentInfo s in studentList)
            {
                Console.WriteLine($"{count}\t{s.name}");
                count++;
            }
        }

    }

}
