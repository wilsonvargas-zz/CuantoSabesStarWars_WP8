using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CuantoSabesStarWars_WP8
{
    public class Util
    {
        private static XDocument cargarDatos = XDocument.Load("DiccionarioPreguntas.xml");
        private static int num = 0;
        private static int num1, num2, num3, num4;
        private static Random rn = new Random();
        

        public static XElement CargarPreguntas()
        {
            var preguntas = (from p in cargarDatos.Descendants("preguntas").Descendants("pregunta") select p).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            return preguntas;
        }

        public static string ObtenerPrimeraPregunta(XElement preguntas)
        {
            num = rn.Next(1, 6);
            var lstRespuestas = preguntas.Elements("r" + num).ToList();
            num1 = num;
            return lstRespuestas.FirstOrDefault().Value;

        }

        public static string ObtenerSegundaPregunta(XElement preguntas)
        {
            num = rn.Next(1, 6);
            while (num == num1)
            {
                num = rn.Next(1, 6);
            }
            var lstRespuestas = preguntas.Elements("r" + num).ToList();
            num2 = num;
            return lstRespuestas.FirstOrDefault().Value;
        }

        public static string ObtenerTerceraPregunta(XElement preguntas)
        {
            num = rn.Next(1, 6);
            while (num == num1 || num == num2)
            {
                num = rn.Next(1, 6);
            }
            var lstRespuestas = preguntas.Elements("r" + num).ToList();
            num3 = num;
            return lstRespuestas.FirstOrDefault().Value;
        }

        public static string ObtenerCuartaPregunta(XElement preguntas)
        {
            num = rn.Next(1, 6);
            while (num == num1 || num == num2 || num == num3)
            {
                num = rn.Next(1, 6);
            }
            var lstRespuestas = preguntas.Elements("r" + num).ToList();
            num4 = num;
            return lstRespuestas.FirstOrDefault().Value;
        }

        public static string ObtenerQuintaPregunta(XElement preguntas)
        {
            num = rn.Next(1, 6);
            while (num == num1 || num == num2 || num == num3 || num == num4)
            {
                num = rn.Next(1, 6);
            }
            var lstRespuestas = preguntas.Elements("r" + num).ToList();

            return lstRespuestas.FirstOrDefault().Value;
        }


    }
}
