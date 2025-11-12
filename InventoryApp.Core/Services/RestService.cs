using InventoryApp.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.Services;

public class RestService : IRepository
{
    private RestClient _client;

    public RestService(string token, string apiBase)
    {
        var options = new RestClientOptions(apiBase)
        {
            ThrowOnAnyError = true,
            Timeout = new TimeSpan(0,2,0),
        };

        this._client = new RestClient(options);
        this._client.AddDefaultHeaders(new Dictionary<string, string>()
        {
            {KnownHeaders.ContentType, "application/json"},
            {KnownHeaders.Accept, "application/json"},
            {KnownHeaders.Authorization, $"Bearer {token}"},
        });
    }


    public List<InventoryItem> Load()
    {
        try
        {
            var request = new RestRequest("/items", Method.Get);

            var result = this._client.Get<InventoryResponse>(request);

            System.Diagnostics.Debug.WriteLine(result);

            if (result.Success)
            {
                return result.Items;
            }
            else
            {
                return new List<InventoryItem>();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            return new List<InventoryItem>();
        }
    }
}
