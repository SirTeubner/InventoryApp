using InventoryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.Services;

public interface IRepository
{
    List<InventoryItem> Load();
}
