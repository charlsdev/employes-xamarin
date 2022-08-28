using employes.controllers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace employes.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public EmployesControllers ctrEmp;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if(ipt_Cedula.Text == null)
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
                registerEmploye();
            }
        }

        private async void registerEmploye() {
            ctrEmp = new EmployesControllers();

            bool status = await ctrEmp.SaveEmploye(ipt_Cedula.Text, ipt_Apellidos.Text, ipt_Nombres.Text, ipt_Salario.Text);

            if (status)
            {
                await DisplayAlert("Información", "Empleado registrado con éxito.", "OK");

                ipt_Cedula.Text = "";
                ipt_Apellidos.Text = "";
                ipt_Nombres.Text = "";
                ipt_Salario.Text = "";
            } 
            else
            {
                await DisplayAlert("Información", "Empleado no ha sido registrado.", "OK");
            }
        }
    }
}