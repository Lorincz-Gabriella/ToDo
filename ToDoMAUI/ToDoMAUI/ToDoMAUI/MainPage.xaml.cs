using ToDoMAUI.ViewModel;

namespace ToDoMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainViewModel vm)
            {
                vm.GetToDosCommand.Execute(null);
            }
        }
    }

}
