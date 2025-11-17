using InventoryApp.Core.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Core.Services
{
    public class RestService : IRepository
    {
        private readonly RestClient _client;
        private readonly IPreferencesService _preferences;

        private const string ApiBase = "https://inventory.test/api";

        public RestService(IPreferencesService preferences)
        {
            _preferences = preferences;

            var options = new RestClientOptions(ApiBase)
            {
                ThrowOnAnyError = true,
                Timeout = new TimeSpan(0, 2, 0),
            };

            _client = new RestClient(options);
        }

        public List<InventoryItem> Load()
        {
            try
            {
                // aktuellen Token aus Preferences lesen
                var token = _preferences.Get("ApiToken", string.Empty);

                var request = new RestRequest("/items", Method.Get);

                // Header pro Request setzen
                request.AddHeader(KnownHeaders.ContentType, "application/json");
                request.AddHeader(KnownHeaders.Accept, "application/json");

                if (!string.IsNullOrWhiteSpace(token))
                {
                    request.AddHeader(KnownHeaders.Authorization, $"Bearer {token}");
                }

                var result = _client.Get<InventoryResponse>(request);

                System.Diagnostics.Debug.WriteLine(result);

                if (result.Success)
                {
                    return result.Items;
                }

                return new List<InventoryItem>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return new List<InventoryItem>();
            }
        }
    }
}
