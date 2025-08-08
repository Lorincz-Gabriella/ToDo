using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDoMAUI.Models;
using ToDoMAUI.Models.DTOs;
using ToDoMAUI.Services.Interfaces;

namespace ToDoMAUI.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly IService todoService;
        public ObservableCollection<GetToDoItemDTO> Todos { get; } = new(); 
        public MainViewModel(IService todoService)
        {
            this.todoService = todoService;
            Title = "ToDo list";
        }

        [RelayCommand] //ui rol egy kattintassal (control hatasara) tudju.k futtatni
        public async Task GetToDosAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            try
            {
                var result = await todoService.GetAllToDOsAsync();
                foreach(var todo in result)
                {
                    Todos.Add(todo);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task DeleteToDoAsync(Guid id)
        {
            try
            {
                var result = await todoService.DeleteToDoItemAsync(id);
                if (result.IsdeleteSuccesful)
                {
                    await GetToDosAsync();
                }
                else
                {
                    await Shell.Current.DisplaySnackbar("ToDo not delete");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
