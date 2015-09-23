using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Negocio;
using Entidades;

namespace Iglesia_luz_y_vida
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            persona persona = new persona();
            persona.cedula = txtCedula.Text;
            persona.nombres = txtNombres.Text;
            persona.apellidos = txtApellidos.Text;
            persona.direccion = txtDireccion.Text;
            persona.telefono = txtTelefono.Text;
            persona.email = txtEmail.Text;
            persona.fecha_nacimiento = Convert.ToDateTime(dtFechaNacimiento.Text);
            persona.estatus = txtEstatus.Text;

            personaNC personaNC = new personaNC();
            personaNC.nuevo(persona);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            personaNC personaNC = new personaNC();
            dgCoincidencias.ItemsSource = personaNC.traerTodos();
            
        }
    }
}
