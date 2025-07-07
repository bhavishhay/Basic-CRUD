using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace TO_DO_app_CRUD
{
    class Program
    {
        // Simple ToDo class to store task data
        public class ToDo
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public bool Status = false;
        }

        // List to store tasks in memory
        static List<ToDo> toDoList = new List<ToDo>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- TO DO APP MENU ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Update Task Status");
                Console.WriteLine("5. Delete Task");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option from (1-6): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        UpdateTask();
                        break;
                    case "4":
                        UpdateTaskStatus();
                        break;
                    case "5":
                        DeleteTask();
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting the app. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 5.");
                        break;
                }
            }
        }

        // Create
        static void AddTask()
        {
            Console.Write("Enter Task Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Task Description: ");
            string description = Console.ReadLine();

            ToDo newTask = new ToDo
            {
                Id = nextId++,
                Title = title,
                Description = description
            };

            toDoList.Add(newTask);
            Console.WriteLine("Task added successfully!");
        }

        // Read
        static void ViewTasks()
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            Console.WriteLine("\n--- Your Tasks ---");
            foreach (var task in toDoList)
            {
                string status = task.Status ? "Completed" : "Not Completed";
                Console.WriteLine($"\n ID: {task.Id},\n Title: {task.Title},\n Description: {task.Description}\n Status: {status}");
            }
        }

        // Update Task Function 
        static void UpdateTask()
        {
            Console.Write("Enter Task ID to update: ");
            string input = Console.ReadLine();

          
            if (int.TryParse(input, out int TaskNumber))
            {
                bool found = false; // flag to check if task is found

                // Loop through the list manually
                for (int i = 0; i < toDoList.Count; i++)
                {
                    if (toDoList[i].Id == TaskNumber)
                    {
                        Console.Write("Enter new Title: ");
                        string newTitle = Console.ReadLine();

                        Console.Write("Enter new Description: ");
                        string newDesc = Console.ReadLine();
              
                        // Update the task directly using index
                        toDoList[i].Title = newTitle;
                        toDoList[i].Description = newDesc;

                        
                        bool Flag = true; // Flag to control the loop for valid input
                        while (Flag)
                        {
                            Console.Write("PRESS y FOR MARK COMPLETED OR n FOR MARK NOT-COMPLETED: ");
                            // Ask user for task status
                            string taskStatus = Console.ReadLine();
                        
                            if (taskStatus == "y" || taskStatus == "Y")
                            {
                                toDoList[i].Status = true;
                                Flag = false;
                                break;
                            }
                            else if (taskStatus == "n" || taskStatus == "N")
                            {
                                toDoList[i].Status = false;
                                Flag = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                        }
                        Console.WriteLine(" \n Task updated successfully! \n ");
                        found = true;
                        break; // stop the loop after finding the task
                    }
                }

                if (!found)
                {
                    Console.WriteLine(" \n Task with given ID not found. \n ");
                }
            }
            else
            {
                Console.WriteLine(" \n Invalid input. Please enter a valid Task ID. \n ");
            }
        }

        // Update Task Status function
        static void UpdateTaskStatus()
        {
            Console.Write("Enter Task ID to update Task Status: ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int TaskNumber))
            {
                bool found = false; // flag to check if task is found

                // Loop through the list manually
                for (int i = 0; i < toDoList.Count; i++)
                {
                    if (toDoList[i].Id == TaskNumber)
                    {
                        
                        bool Flag = true; // Flag to control the loop for valid input
                        while (Flag)
                        {
                            Console.WriteLine("PRESS y FOR MARK COMPLETED OR n FOR MARK NOT-COMPLETED: ");
                            // Ask user for task status
                            string taskStatus = Console.ReadLine();

                            if (taskStatus == "y" || taskStatus == "Y")
                            {
                                toDoList[i].Status = true;
                                Flag = false;
                                break;
                            }
                            else if (taskStatus == "n" || taskStatus == "N")
                            {
                                toDoList[i].Status = false;
                                Flag = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                            }
                        }



                        Console.WriteLine(" \n Task Status updated successfully! \n ");
                        found = true;
                        break; // stop the loop after finding the task
                    }
                }

                if (!found)
                {
                    Console.WriteLine(" \n Task with given ID not found. \n ");
                }
            }
            else
            {
                Console.WriteLine(" \n Invalid input. Please enter a valid Task ID. \n ");
            }
        }


        // Delete
        static void DeleteTask()
        {
            Console.Write("Enter Task ID to delete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int TaskNumber))
            {
                bool found = false;

                // Manually loop through list to find matching task
                for (int i = 0; i < toDoList.Count; i++)
                {
                    if (toDoList[i].Id == TaskNumber)
                    {
                        // Delete the task using index
                        toDoList.RemoveAt(i);
                        Console.WriteLine(" \n Task deleted successfully! \n ");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine(" \n Task with given ID not found. \n ");
                }
            }
            else
            {
                Console.WriteLine(" \n Invalid input. Please enter a valid Task ID. \n ");
            }

        }
    }
}
