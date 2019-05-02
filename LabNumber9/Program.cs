using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNumber9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentInfo> studentList = new List<StudentInfo>();
            StudentInfo S = new StudentInfo();
            string welcomeMessage = "Welcome to our C# class!\n";
            string contineProgramMessage = "Would you like to add, delete or learn " +
                "about another student? (y/n): ";
            bool continueProgram = true, moreInfo = true;
                      

            while (continueProgram)
            {
                //Update the studentList from the file
                studentList = StudentInfo.GetDataFromFile();

                //save the prompt with data from the file
                string studentPrompt = $"Which student would you like to learn " +
                $"more about? (enter a number 1-{studentList.Count}): ";

                //Clear the screen and print the welcome
                Console.Clear();
                UserInput.PrintInColor(welcomeMessage, ConsoleColor.Green);

                //ask if the user wants to add a student or learn about one
                string addStudent = UserInput.GetAddLearnDelete("Would you like to add, delete or learn about a student? " +
                    "(add/delete/learn): ", "Please enter \"add\" \"delete\" or \"learn\": ");

                //if they want to learn lauch the learning portion of the program
                if (addStudent.ToLower() == "learn")
                {
                    StudentInfo.PrintNames(studentList);

                    //ask for a student ID and validate that number
                    int studentID = UserInput.GetValidStudentID(studentList.Count,
                    studentPrompt, $"That student does not exist.\n" +
                    $"Please enter a number between 1-{studentList.Count}");

                    string firstName = studentList[studentID - 1].name.Split()[0];
                    
                    //Print the student's name
                    UserInput.PrintInColor($"Student {studentID} is " +
                        $"{studentList[studentID - 1].name}.\n", ConsoleColor.Yellow);

                    moreInfo = true;
                    while (moreInfo)
                    {
                        //Prompt the user for what they want to know
                        Console.WriteLine($"What would you like to know about {firstName}?");

                        //Accept and validate the input
                        string userInput = UserInput.GetStudentData("Please enter \"hometown\", " +
                            "\"favorite food\", \"favorite color\", or \"favorite number\":\n");

                        //Print the results
                        UserInput.PrintInColor($"{firstName}'s {userInput} is " +
                            $"{UserInput.GetStudentInfo(userInput, studentList[studentID - 1])}.\n", 
                            ConsoleColor.Yellow);

                        //Check if they want to run it again
                        moreInfo = GetUserChoice($"Would you like to know more about " +
                            $"{firstName}? (y/n): ", "y", "n");
                    }
                }
                //if they want to add a student launch this part of the program
                else if(addStudent.ToLower() == "add")
                {
                    //accept input from the user and validate it
                    StudentInfo studentToAdd = new StudentInfo
                    {
                        name = UserInput.GetStudentName("Please enter the student's name: "),
                        hometown = UserInput.GetString("Please enter the student's hometown: "),
                        favFood = UserInput.GetString("Please enter the student's favorite food: "),
                        favColor = UserInput.GetString("Please enter the student's favorite color: "),
                        favNum = UserInput.GetString("Please enter the student's favorite number: ")
                    };

                    //add it to the list
                    studentList.Add(studentToAdd);
                    

                    
                   
                }
                else
                {
                    //run delete portion of program 
                    Console.Clear();
                    StudentInfo.PrintNames(studentList);

                    Console.WriteLine("\nPlease enter the number of the student you would like to delete.");
                    Console.WriteLine("If you would like to exit without deleting a student, please press 0.");

                    int deleteStuID = UserInput.GetIDtoDelete(studentList.Count,
                        "Enter your choice: ", $"Please enter a number from 0-{studentList.Count}: ");

                    if(deleteStuID == 0)
                    {
                        UserInput.PrintInColor("\nYou have chosen not to delete any information.\n",
                            ConsoleColor.Green);
                    }
                    else
                    {                        
                        UserInput.PrintInColor($"\nYou have chosen to delete {studentList[deleteStuID - 1].name}." +
                            $"\nGoodbye cruel world!\n", ConsoleColor.Red);
                        studentList.RemoveAt(deleteStuID - 1);
                    }
                }

                //rewrite the file to add the new object
                StudentInfo.WriteData(studentList);

                //check if they want to run it again or quit
                continueProgram = GetUserChoice(contineProgramMessage, "y", "n");
            }          

        }

        public static bool GetUserChoice(string message, string option1, 
            string option2, string error = "Please enter 'y' for yes and 'n' for no.")
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (input == option1)
            {
                return true;
            }
            else if (input == option2)
            {
                return false;
            }
            else
            {
                UserInput.PrintInColor(error + "\n" , ConsoleColor.Red);
                return GetUserChoice(message, option1, option2, error);
            }
        }
    }
}
