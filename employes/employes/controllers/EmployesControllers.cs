using employes.models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace employes.controllers
{
    public class EmployesControllers
    {
        string urlAPI = "http://192.168.100.86:4000/api";

        public async Task<bool> SaveEmploye(string ced, string ape, string nom, string sal)
        {
            Uri url = new Uri(urlAPI);

            Employes emp = new Employes
            {
                cedula = ced,
                apellidos = ape,
                nombres = nom,
                salario = sal
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(emp);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<List<AllEmployes>> AllEmployes()
        {
            Uri url = new Uri(urlAPI);

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<AllEmployes>>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteEmploye(string ced)
        {
            string uri = $"{urlAPI}/{ced}";

            var client = new HttpClient();

            var response = await client.DeleteAsync(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Employes> OneEmploye(string ced)
        {
            Uri url = new Uri($"{urlAPI}/{ced}");

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Employes>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateEmploye(string ced, string ape, string nom, string sal)
        {
            Uri url = new Uri(urlAPI);

            Employes emp = new Employes
            {
                cedula = ced,
                apellidos = ape,
                nombres = nom,
                salario = sal
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(emp);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
