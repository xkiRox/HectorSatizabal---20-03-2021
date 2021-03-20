using System.Collections.ObjectModel;

namespace ToDo.Model
{
    public class DataStore
    {
        private ObservableCollection<Task> tasks;

        public DataStore()
        {
            tasks = new ObservableCollection<Task>();
        }

        public void Add(string note)
        {
            tasks.Add(new Task { Note = note });
        }

        public void Remove()
        {
            tasks.Clear();
        }

        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
        }
    }
}
