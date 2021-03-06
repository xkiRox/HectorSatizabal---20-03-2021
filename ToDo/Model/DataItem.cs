using System;
using System.Collections.ObjectModel;

namespace ToDo.Model
{
    public class DataItem
    {
        private ObservableCollection<TodoItem> todoItems;

        public DataItem()
        {
            todoItems = new ObservableCollection<TodoItem>();
            var items = App.Database.GetItemsAsync().Result;
            if (items != null) {
                todoItems = new ObservableCollection<TodoItem>(items);
            }
        }

        public void Add(string note)
        {
            todoItems.Add(new TodoItem { Note = note });
            App.Database.SaveItemAsync(note);
        }

        public void Remove()
        {
            todoItems.Clear();
        }

        public void Remove(TodoItem item)
        {
            todoItems.Remove(item);
            App.Database.DeleteItemAsync(item);
        }

        public void Update(TodoItem item)
        {
            App.Database.SaveItemAsync(item);
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get {
                return todoItems;
            }
        }
    }
}
