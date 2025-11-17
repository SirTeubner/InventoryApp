using InventoryApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Gui.Services;

public class PreferenceService : IPreferencesService
{
    public string Get(string name, string defaultValue)
    {
        return Preferences.Get(name, defaultValue);
    }

    public void Set(string name, string nameValue)
    {
        Preferences.Set(name, nameValue);
    }
}
