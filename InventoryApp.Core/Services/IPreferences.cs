using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.Services;

public interface IPreferences
{
    void Set(string name, string nameValue);

    string Get(string name, string defaultValue);
}
