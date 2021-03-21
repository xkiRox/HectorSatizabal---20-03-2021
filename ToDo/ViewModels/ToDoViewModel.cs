using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
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
            AddCommand = new DelegateCommand(AddNote);
            ItemCommand = new DelegateCommand<TodoItem>(DeleteNote);
            CheckCommand = new DelegateCommand<TodoItem>(DoneNote);
        }

        private void AddNote()
        {
            dataItem.Add(note);
        }

        private void DeleteNote(TodoItem todoItem)
        {
            dataItem.Remove(todoItem);
        }

        private void DoneNote(TodoItem todoItem)
        {
            if (todoItem != null) {
                dataItem.Update(todoItem);
            }
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

        public ICommand AddCommand
        {
            get;
            private set;
        }

        public ICommand ItemCommand
        {
            get;
            private set;
        }

        public ICommand CheckCommand
        {
            get;
            private set;
        }
    }
}
