using employes.controllers;
using employes.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace employes.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public EmployesControllers ctrEmp;

        protected IList<AllEmployes> employes;

        public ListPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private async void allEmployesList()
        {
            ctrEmp = new EmployesControllers();
            employes = await ctrEmp.AllEmployes();
            ListEmployes.ItemsSource = employes;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            allEmployesList();
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            ctrEmp = new EmployesControllers();
            Button ced = (Button)sender;
            string cedula = ced.CommandParameter.ToString();

            var opt = await DisplayAlert("Información", "Deseas eliminar el empleado con cédula: " + cedula, "Sí", "No");

            if (opt)
            {
                bool status = await ctrEmp.DeleteEmploye(cedula);

                if (status)
                {
                    await DisplayAlert("Información", "Empleado eliminado con éxito.", "OK");

                    allEmployesList();
                }
                else
                {
                    await DisplayAlert("Información", "Empleado no eliminado.", "OK");
                }
            } 
            else
            {
                return;
            }
        }

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            Button ced = (Button)sender;
            string cedula = ced.CommandParameter.ToString();

            var opt = await DisplayAlert("Información", "Deseas editar el empleado con cédula: " + cedula, "Sí", "No");

            if (opt)
            {
                Application.Current.Properties["ced_Employes"] = cedula;
                await Navigation.PushAsync(new EditPage());
            }
            else
            {
                return;
            }
        }
    }
}