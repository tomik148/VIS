using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.Models
{
    public static class HttpC {
       public static HttpClient client;
    }
    public class ActiveRecord<T> : INotifyPropertyChanged
    {
        public static string AddressOfServer= "http://localhost:2356/";
        private readonly string name;
        public ActiveRecord(string name)
        {
            this.name = name;
            if (HttpC.client == null)
            {
                HttpC.client = new HttpClient
                {
                    BaseAddress = new Uri(AddressOfServer)
                };
                HttpC.client.DefaultRequestHeaders.Accept.Clear();
                HttpC.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public async Task<T[]> GetAllAsync()
        {
            T[] result = null;
            HttpResponseMessage response = await HttpC.client.GetAsync($"api/{name}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T[]>();
            }
            return result;
        }

        public async Task<T> GetByIDAsync(int ID)
        {
            T result = default(T);
            HttpResponseMessage response = await HttpC.client.GetAsync($"api/{name}/{ID}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async Task<T> UpdateByIDAsync(int ID, T newVal)
        {
            T result = default(T);
            HttpResponseMessage response = await HttpC.client.PutAsJsonAsync($"api/{name}/{ID}", newVal);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async Task<T> AddAsync(T newVal)
        {
            T result = default(T);
            HttpResponseMessage response = await HttpC.client.PostAsJsonAsync($"api/{name}", newVal);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;  
        }

        public async Task DeleteByIDAsync(int ID)
        {
            HttpResponseMessage response = await HttpC.client.DeleteAsync( $"api/{name}/{ID}");
            var a = response.StatusCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnPropertyChanged<Type>(ref Type target, Type val, [CallerMemberName]string PropertyName = "")
        {
            target = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
