using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameCenter.Projects.TodoList.Models
{
	internal class TodoListModel
	{

		//properties
		//List of tasks - ObservableCollection
		public ObservableCollection<TodoTask> Tasks { get; set; }
		//methods
		//Constructor
		public TodoListModel()
		{
			Tasks = new ObservableCollection<TodoTask>();
		}
		//Update Task(int id)
		public void UpdateTask(int taskId, string newDescription)
		{
			TodoTask? task = Tasks.FirstOrDefault(task => task.Id == taskId);
			if (task != null)
			{
				task.Description = newDescription;
			}
			else
			{
				throw new Exception("The task with this Id wasn't found");
			}
		}
		//ToggleTaskIsComplete(int id)
		public void ToggleTaskIsComplete(int taskId)
		{
			TodoTask? task = Tasks.FirstOrDefault(task => task.Id == taskId);
			if (task != null)
			{
				task.IsComplete = !task.IsComplete;
			}
			else
			{
				throw new Exception("The task with this Id wasn't found");
			}
		}
		//AddNewTask(task)
		public void AddNewTask(TodoTask task)
		{
			Tasks.Add(task);
		}

	}


}
