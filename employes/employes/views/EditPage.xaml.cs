using employes.controllers;
using employes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace employes.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EmployesControllers ctrEmp;
        //protected Employes employe;
        string cedEmploye = Convert.ToString(Application.Current.Properties["ced_Employes"]);

        public EditPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ipt_Cedula.Text = "";
            ipt_Apellidos.Text = "";
            ipt_Nombres.Text = "";
            ipt_Salario.Text = "";

            ctrEmp = new EmployesControllers();
            Employes employe = await ctrEmp.OneEmploye(cedEmploye);

            ipt_Cedula.Text = employe.cedula.ToString();
            ipt_Apellidos.Text = employe.apellidos.ToString();
            ipt_Nombres.Text = employe.nombres.ToString();
            ipt_Salario.Text = employe.salario.ToString();
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (ipt_Cedula.Text == null)
            {
                ipt_Cedula.Focus();
                DisplayAlert("Información", "El campo cédula no puede estar vacío.", "OK");
            }
            else if (ipt_Apellidos.Text == null)
            {
                ipt_Apellidos.Focus();
                DisplayAlert("Información", "El campo apellido no puede estar vacío.", "OK");
            }
            else if (ipt_Nombres.Text == null)
            {
                ipt_Nombres.Focus();
                DisplayAlert("Información", "El campo nombre no puede estar vacío.", "OK");
            }
            else if (ipt_Salario.Text == null)
            {
                ipt_Salario.Focus();
                DisplayAlert("Información", "El campo salario no puede estar vacío.", "OK");
            }
            else
            {
                saveUpdateEmploye();
            }
        }

        private async void saveUpdateEmploye()
        {
            ctrEmp = new EmployesControllers();

            bool status = await ctrEmp.UpdateEmploye(ipt_Cedula.Text, ipt_Apellidos.Text, ipt_Nombres.Text, ipt_Salario.Text);

            if (status)
            {
                await DisplayAlert("Información", "Empleado actualizado con éxito.", "OK");

                ipt_Cedula.Text = "";
                ipt_Apellidos.Text = "";
                ipt_Nombres.Text = "";
                ipt_Salario.Text = "";

                await Navigation.PushAsync(new ListPage());
            }
            else
            {
                await DisplayAlert("Información", "Empleado no ha sido actualizado.", "OK");
            }
        }
    }
}