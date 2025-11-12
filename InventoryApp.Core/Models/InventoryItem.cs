using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryApp.Core.Models;

public partial class InventoryItem : ObservableObject
{
    /*
    [ObservableProperty]
    long _id = 0;

    [ObservableProperty]
    string _title = string.Empty;

    [ObservableProperty]
    string _inventoryNumber = string.Empty;
    */

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("inventory_number")]
    public string InventoryNumber { get; set; }

    public InventoryItem(string inventoryNumber, string title)
    {
        this.Id = 0;
        this.InventoryNumber = inventoryNumber;
        this.Title = title;
    }
}
