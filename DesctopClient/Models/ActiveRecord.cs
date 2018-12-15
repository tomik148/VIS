using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.Models
{
    public class ActiveRecord<T>
    {
        static HttpClient client = new HttpClient();
        public static string AddressOfServer= "http://localhost:2356/";
        private readonly string name;
        public ActiveRecord(string name)
        {
            this.name = name;

            client.BaseAddress = new Uri(AddressOfServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T[]> GetAllAsync()
        {
            T[] result = null;
            HttpResponseMessage response = await client.GetAsync($"api/{name}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T[]>();
            }
            return result;
        }

        public async Task<T> GetByIDAsync(int ID)
        {
            T result = default(T);
            HttpResponseMessage response = await client.GetAsync($"api/{name}/{ID}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async Task<T> UpdateByIDAsync(int ID, T newVal)
        {
            T result = default(T);
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/{name}/{ID}", newVal);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async Task<T> AddAsync(T newVal)
        {
            T result = default(T);
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/{name}", newVal);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;  
        }

        public async Task DeleteByIDAsync(int ID)
        {
            HttpResponseMessage response = await client.DeleteAsync( $"api/{name}/{ID}");
            var a = response.StatusCode;
        }

    }
}
