using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameCenter.Projects.TodoList.Models
{
	internal class TodoTask
	{

		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsComplete { get; set; }


		public TodoTask(int id, string description)
		{
			Id = id;
			Description = description;
			CreatedDate = DateTime.Now;
			IsComplete = false;
		}


	}

}

