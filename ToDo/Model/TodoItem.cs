using System;
using SQLite;

namespace ToDo.Model
{
	public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Note { get; set; }
		public bool Done { get; set; }
	}
}
