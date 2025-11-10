using InventoryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Lib.Services;

public interface IService
{
    List<InventoryItem> Load();
}
