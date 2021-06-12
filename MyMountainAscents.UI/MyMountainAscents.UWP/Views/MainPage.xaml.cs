using MyMountainAscents.UWP.Models;
using MyMountainAscents.UWP.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyMountainAscents.UWP
{
    public sealed partial class MainPage : Page
    {
        public List<Mountain> Mountains;


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public MainPage()
        {
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using (var client = new HttpClient(handler))
                {
                    //client.BaseAddress = new Uri("https://localhost:44341/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("https://localhost:44341/api/mountain");
                    string httpResponseBody = "";
                    if (response.IsSuccessStatusCode)
                    {
                        httpResponseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<Mountain>>(httpResponseBody);
                        Mountains = new List<Mountain>();
                        Mountains = result;
                        this.InitializeComponent();
                    }
                }
            }
            catch (Exception f)
            {
                var test = f;
            }
        }
    }
}
