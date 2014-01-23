using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CuantoSabesStarWars_WP8.Resources;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace CuantoSabesStarWars_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        string respuestaValida = "";
        int puntos = 0;
        int intentos = 3;
        XElement listaPregunta = null;
        // Constructor
        public MainPage()
        { 
            InitializeComponent();
        //    if ((Visibility)App.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible) {
        //        Color currentAccentColorHex =
        //(Color)Application.Current.Resources["PhoneDarkThemeVisibility"];
        //        tbPregunta.Text = "background = dark";
        //    }
        //    else
        //    {
        //         Color currentAccentColorHex =
        //(Color)Application.Current.Resources["PhoneLightThemeVisibility"];
        //        tbPregunta.Text = "background = light";
        //    }
           
            CargarDatos();
        }

        public void CargarDatos()
        {
            listaPregunta = Util.CargarPreguntas();
            var preg = listaPregunta.Elements("contenido").ToList();
            tbPregunta.Text = preg.FirstOrDefault().Value;
            var rspValidad = listaPregunta.Elements("r1").ToList();
            respuestaValida = rspValidad.FirstOrDefault().Value;
            btnResp1.Content = Util.ObtenerPrimeraPregunta(listaPregunta);
            btnResp2.Content = Util.ObtenerSegundaPregunta(listaPregunta);
            btnResp3.Content = Util.ObtenerTerceraPregunta(listaPregunta);
            btnResp4.Content = Util.ObtenerCuartaPregunta(listaPregunta);
            btnResp5.Content = Util.ObtenerQuintaPregunta(listaPregunta);
        }

        private void SeleccionBoton1(object sender, RoutedEventArgs e)
        {
            if (btnResp1.Content.ToString().Equals(respuestaValida))
            {
                puntos++;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                ComprobarPuntuacion();
            }
        }

        private void SeleccionBoton2(object sender, RoutedEventArgs e)
        {
            if (btnResp2.Content.ToString().Equals(respuestaValida))
            {
                puntos++;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                ComprobarPuntuacion();
            }
        }

        private void SeleccionBoton3(object sender, RoutedEventArgs e)
        {
            if (btnResp3.Content.ToString().Equals(respuestaValida))
            {
                puntos++;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                ComprobarPuntuacion();
            }
        }

        private void SeleccionBoton4(object sender, RoutedEventArgs e)
        {
            if (btnResp4.Content.ToString().Equals(respuestaValida))
            {
                puntos++;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                ComprobarPuntuacion();
            }
        }

        private void SeleccionBoton5(object sender, RoutedEventArgs e)
        {
            if (btnResp5.Content.ToString().Equals(respuestaValida))
            {
                puntos++;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                ComprobarPuntuacion();
            }

        }


        private void ComprobarPuntuacion()
        {
            intentos--;
            if (intentos == 0)
            {
                Intento3.Visibility = Visibility.Visible;
                OverMessage.Text = "Obtuviste " + puntos + " puntos en ¿Cuánto sabes de Star Wars? \nSi deseas puedes compartir tu puntaje";
                MainContainer.Visibility = Visibility.Collapsed;
                LoseContainer.Visibility = Visibility.Visible;
                contenedorIntentos.Visibility = Visibility.Collapsed;
                Intento1.Visibility = Visibility.Collapsed;
                Intento2.Visibility = Visibility.Collapsed;
                Intento3.Visibility = Visibility.Collapsed;
                intentos = 3;
                Contador.Text = puntos.ToString();
                CargarDatos();
            }
            else
            {
                switch (intentos)
                {
                    case 2:
                        contenedorIntentos.Visibility = Visibility.Visible;
                        Intento1.Visibility = Visibility.Visible;
                        CargarDatos();
                        break;
                    case 1:
                        contenedorIntentos.Visibility = Visibility.Visible;
                        Intento2.Visibility = Visibility.Visible;
                        CargarDatos();
                        break;
                }

            }
        }

        private void ButtonShare_Click(object sender, RoutedEventArgs e)
        {
            ShareStatusTask sst = new ShareStatusTask();
            sst.Status = "¡He obtenido " + puntos + " puntos en ¿Cuánto sabes de Star Wars?! Alguien puede conseguir más?";
            sst.Show();
        }

        private void ButtonReload_Click(object sender, RoutedEventArgs e)
        {
            puntos = 0;
            Contador.Text = puntos.ToString();
            LoseContainer.Visibility = Visibility.Collapsed;
            MainContainer.Visibility = Visibility.Visible;
        }


    }
}
