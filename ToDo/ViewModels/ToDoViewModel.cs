using System.Collections.ObjectModel;
using Prism.Mvvm;
using ToDo.Model;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        DataItem dataItem = new DataItem();

        public ToDoViewModel()
        {
            addCommand = new Command(agregarevent);
        }

        private void agregarevent()
        {
            dataItem.Add(note);
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public ObservableCollection<TodoItem> Tasks
        {
            get { return dataItem.TodoItems; }
        }

        private Command addCommand;

        public Command Add
        {
            get { return addCommand; }
            set { addCommand = value; }
        }
    }
}
