using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ToDo.Model;

namespace ToDo.Data
{
	public class TodoItemDatabase
	{
		static SQLiteAsyncConnection Database;

		public TodoItemDatabase(string dbPath)
		{
			Database = new SQLiteAsyncConnection(dbPath);
			Database.CreateTableAsync<TodoItem>().Wait();
		}

		public Task<List<TodoItem>> GetItemsAsync()
		{
			return Database.Table<TodoItem>().ToListAsync();
		}

		public Task<List<TodoItem>> GetItemsNotDoneAsync()
		{
			return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
		}

		public Task<TodoItem> GetItemAsync(int id)
		{
			return Database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(string note)
		{
			return Database.InsertAsync(new TodoItem { Note = note });
		}

		public Task<int> SaveItemAsync(TodoItem item)
		{
			if (item.ID != 0)
			{
				return Database.UpdateAsync(item);
			}
			else
			{
				return Database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(TodoItem item)
		{
			return Database.DeleteAsync(item);
		}
	}
}
