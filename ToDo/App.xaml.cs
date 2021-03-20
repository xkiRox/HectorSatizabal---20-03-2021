using Plugin.Permissions.Abstractions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using ToDo.Common;
using ToDo.View;
using ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ToDo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            InitializeAppPermissionsAsync();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, ToDoViewModel>();
        }

        private async void InitializeAppPermissionsAsync()
        {
            var hasPermission = await Utils.CheckPermissions(Permission.Storage);
            if (!hasPermission)
                return;
        }
    }
}
