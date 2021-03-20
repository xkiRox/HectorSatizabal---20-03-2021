using System.Collections.ObjectModel;
using Prism.Mvvm;
using ToDo.Model;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        DataStore dataStore = new DataStore();

        public ToDoViewModel()
        {
            addCommand = new Command(agregarevent);
        }

        private void agregarevent()
        {
            dataStore.Add(note);
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public ObservableCollection<Task> Tasks
        {
            get { return dataStore.Tasks; }
        }

        private Command addCommand;

        public Command Add
        {
            get { return addCommand; }
            set { addCommand = value; }
        }
    }
}
