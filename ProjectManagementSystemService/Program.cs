using System;
using System.Collections.Generic;
using ProjectManagementSystem4;

namespace ProjectManagementSystemService
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectManager = new ProjectManager();

            Console.WriteLine("Welcome to the Project Management Console App!");

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add a new project");
                Console.WriteLine("2. Add a task to a project");
                Console.WriteLine("3. View tasks in a project");
                Console.WriteLine("4. Update task status");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProject(projectManager);
                        break;
                    case "2":
                        AddTaskToProject(projectManager);
                        break;
                    case "3":
                        ViewTasksInProject(projectManager);
                        break;
                    case "4":
                        UpdateTaskStatus(projectManager);
                        break;
                    case "5":
                        Console.WriteLine("Exiting application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddProject(ProjectManager projectManager)
        {
            try
            {
                Console.Write("Enter project name: ");
                var name = Console.ReadLine();
                Console.Write("Enter start date (yyyy-MM-dd): ");
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter end date (yyyy-MM-dd): ");
                var endDate = DateTime.Parse(Console.ReadLine());

                var project = new Project(name, startDate, endDate);
                projectManager.AddProject(project);

                Console.WriteLine("Project added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void AddTaskToProject(ProjectManager projectManager)
        {
            try
            {
                Console.Write("Enter project name: ");
                var projectName = Console.ReadLine();
                Console.Write("Enter task name: ");
                var taskName = Console.ReadLine();
                Console.Write("Enter team member name: ");
                var teamMemberName = Console.ReadLine();
                Console.Write("Enter team member ID: ");
                var memberId = int.Parse(Console.ReadLine());
                Console.Write("Enter task status (Заплановано, Виконується, Завершено): ");
                var status = Console.ReadLine();

                var teamMember = new TeamMember(teamMemberName, memberId);
                var task = new ProjectManagementSystem4.Task(taskName, teamMember, status);
                projectManager.AddTask(projectName, task);

                Console.WriteLine("Task added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewTasksInProject(ProjectManager projectManager)
        {
            try
            {
                Console.Write("Enter project name: ");
                var projectName = Console.ReadLine();

                var tasks = projectManager.GetTasks(projectName);
                if (tasks.Count == 0)
                {
                    Console.WriteLine("No tasks found in the project.");
                }
                else
                {
                    Console.WriteLine("Tasks:");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"- {task.TaskName} (Status: {task.Status}, Assigned to: {task.AssignedTo.Name})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateTaskStatus(ProjectManager projectManager)
        {
            try
            {
                Console.Write("Enter project name: ");
                var projectName = Console.ReadLine();
                Console.Write("Enter task name: ");
                var taskName = Console.ReadLine();
                Console.Write("Enter new status (Заплановано, Виконується, Завершено): ");
                var newStatus = Console.ReadLine();

                projectManager.UpdateTaskStatus(projectName, taskName, newStatus);

                Console.WriteLine("Task status updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

