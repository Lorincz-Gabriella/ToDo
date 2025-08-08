using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoMAUI.ViewModel
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy; //field mert nincs getter/setter

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy; //isNotBusy helyettesiti !isBusyval


    }
}
