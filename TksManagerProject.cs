using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Assessment
{
    public class Task
    {
       public string TskName { set; get; }
       public string Description { set; get; }
       public DateTime Duedate { set; get; }
       public bool IsCompleted { set; get; } 

        public Task(string TskName,string Description,DateTime Duedate)
        {
            this.TskName = TskName;
            this.Description = Description;
            this.Duedate = Duedate;
            this.IsCompleted =false;
        }
      

    }






    internal class TksManagerProject
    {
      
     
        List<Task> tasks;

        public string JsonFilePath = "C:\\Users\\yogih\\source\\repos\\Assessment\\bin\\Debug\\net6.0\\myJsonFile.json";

        public TksManagerProject()
        {

            tasks = new List<Task>();

            LoadTaskFromJson();
        }

        public void AddTask(string Taskname, string Description, DateTime Duetime)
        {
            //   tasks = new List<Task>();
            tasks.Add(new Task(Taskname, Description, Duetime));
            SaveTskintoJson();
            Console.WriteLine("Task is Saved Successfully!...");
        }



        public void ViewTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No task found!...");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine("\n" + "Task Name: " + task.TskName);
                    Console.WriteLine("\n" + "Task Description: " + task.Description);
                    Console.WriteLine("\n" + "Task DueDate: " + task.Duedate);
                    Console.WriteLine("\n" + "Task Status: " + task.IsCompleted);
                    Console.WriteLine("..............................................");
                    Console.WriteLine();
                }
            }
        }


        public void MarkCompleted(int tasksIndex)
        {
            if (tasksIndex >= 0 && tasksIndex < tasks.Count)
            {
                tasks[tasksIndex].IsCompleted = true;
                SaveTskintoJson();
                Console.Write("\n" + "Task is marked complete successfully!...");
              
            }
        }

        public void DeleteTask(int taskIndex)
        {
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                tasks.RemoveAt(taskIndex);
                SaveTskintoJson();
                Console.Write( "......Task is Deleted successfully!...");
              
            }
        }

        public void SaveTskintoJson()
        {
            var json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(JsonFilePath, json);
            Console.WriteLine("......Changed Occured Successfully!......");
            Console.WriteLine("\n");
        }
        public void LoadTaskFromJson()
        {
            if (File.Exists(JsonFilePath))
            {
                var json = File.ReadAllText(JsonFilePath);
                tasks = JsonConvert.DeserializeObject<List<Task>>(json);
            }
        }


   

        static void Main(String[] args)
        {
            try
            {
                TksManagerProject taskmanager = new TksManagerProject();
                int choice;

                while (true)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("                         Welcome to Task Manager Console App                       ");
                    Console.Write("                                  "+DateTime.Now+"                                  ");
                    Console.WriteLine("\n");
                    Console.WriteLine("\t"+"1: AddTask");
                    Console.WriteLine("\t"+"2: ViewTask");
                    Console.WriteLine("\t"+"3: MarkTaskCompleted");
                    Console.WriteLine("\t"+"4: DeleteTask");
                    Console.WriteLine("\t"+"5: Exit");
                    Console.WriteLine();
                    Console.Write("\n"+"Enter the choice from user: ");
                    choice = Int32.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.Write("\n"+"...............Add a Task............");
                                Console.Write("\n" + "Enter the task to be add: ");
                                string taskname = Console.ReadLine();
                                Console.Write("Enter the Description: ");
                                string description = Console.ReadLine();
                               // Console.Write("Enter the date in yyyy-MM-dd format: ");
                                // DateTime date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                                DateTime date = DateTime.Now;
                                taskmanager.AddTask(taskname, description, date);
                            }catch(Exception e)
                            {
                               Console.WriteLine( e.Message);
                            }
                            
                            break;

                        case 2:
                            Console.Write("....................View a task..................");
                            taskmanager.ViewTask();
                            break;

                        case 3:
                            Console.WriteLine(".....................Mark The Task Complete/Incomplete..............");
                            Console.Write("\n" + "Enter the task index: ");
                            int marktksindex = Int32.Parse(Console.ReadLine());
                            taskmanager.MarkCompleted(marktksindex);
                            break;

                        case 4:
                            Console.Write(".....................Delete the task...................");
                            Console.Write("\n"+"Enter the Task index to be Deleted: ");
                            int deletetskindex = Int32.Parse(Console.ReadLine());
                            taskmanager.DeleteTask(deletetskindex);
                            break;

                        case 5:
                            Console.WriteLine(".....................Want to Exit...................");
                            break;

                        case 6:
                            Console.Write("....................Invalid Choice............");
                            break;
                    }

                }
            }

            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}

    

