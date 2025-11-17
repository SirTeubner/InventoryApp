using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using InventoryApp.Core.Models;
using InventoryApp.Core.Services;

namespace InventoryApp.Core.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<InventoryItem> _items = new();

        [ObservableProperty]
        private string _token = string.Empty;

        private readonly IRepository _repository;
        private readonly IPreferencesService _preferences;

        public DashboardViewModel(IRepository repository, IPreferencesService preferences)
        {
            _repository = repository;
            _preferences = preferences;
        }

        [RelayCommand]
        private void Load()
        {
            Items.Clear();

            var items = _repository.Load();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        [RelayCommand]
        private void SetToken()
        {
            _preferences.Set("ApiToken", Token);
        }

        [RelayCommand]
        private void LoadToken()
        {
            Token = _preferences.Get("ApiToken", string.Empty);
        }
    }
}
