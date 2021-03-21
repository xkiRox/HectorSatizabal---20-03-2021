using System;
using System.IO;
using Plugin.Permissions.Abstractions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using ToDo.Common;
using ToDo.Data;
using ToDo.View;
using ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDo
{
    public partial class App : PrismApplication
    {
        static TodoItemDatabase database;

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            InitializeAppPermissionsAsync();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, ToDoViewModel>();
        }

        private async void InitializeAppPermissionsAsync()
        {
            var hasPermission = await Utils.CheckPermissions(Permission.Storage);
            if (hasPermission)
                return;
        }
    }
}
