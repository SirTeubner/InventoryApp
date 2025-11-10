using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.Models;

public partial class InventoryItem : ObservableObject
{
    [ObservableProperty]
    long _id = 0;

    [ObservableProperty]
    string _title = string.Empty;

    [ObservableProperty]
    string _inventoryNumber = string.Empty;

    public InventoryItem(string inventoryNumber, string title)
    {
        this.InventoryNumber = inventoryNumber;
        this.Title = title;
    }
}
