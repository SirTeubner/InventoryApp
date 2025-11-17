using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryApp.Core.Models;
using InventoryApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<InventoryItem> _items = new();

    private IRepository _repository;
    private IPreferencesService _preferences;

    public DashboardViewModel(IRepository service, IPreferencesService preferences)
    {
        this._repository = service;
        this._preferences = preferences;
    }

    [RelayCommand]
    void Load()
    {
        this.Items.Clear();

        List<InventoryItem> items = _repository.Load();

        foreach(InventoryItem item in items)
        {
            this.Items.Add(item);
        }

    }

    [ObservableProperty]
    private string _token = string.Empty;

    [RelayCommand]
    void SetToken()
    {
        _preferences.Set("ApiToken", this.Token);
    }

    [RelayCommand]
    void LoadToken()
    {
        this.Token = _preferences.Get("ApiToken", "");
    }

}
