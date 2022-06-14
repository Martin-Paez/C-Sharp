
using System;
using System.IO;
using System.Collections;

namespace Ejercicio_2
{
	class Program
	{
		/* public static string[] CargaDatos()
		   {

		   }
		 */
		public static void Main(string[] args)
		{
			ArrayList planilla = new ArrayList();
			//Lista de datos [nombre. apellido, DNI, especialidad]
			string[] datos = new string[4];

			try
			{
			   //Pasar la direccion y el nombre del archivo
			   StreamReader sr = new StreamReader("Datos.txt");
			   
				//Lee la primera linea de texto
			   string linea = sr.ReadLine();
			   
				//Sigue leyendo hasta el final del archivo
			   while (linea != null)
			   {
					//Separa los datos y los guarda en la lista
					datos = linea.Split('/');
					
					//Guarda los datos en la planilla
					planilla.Add(datos);

			      //Lee la siguiente linea
			      linea = sr.ReadLine();
			   }
			   //Cierra el archivo
			   sr.Close();
			   Console.ReadLine();
			}
			catch(Exception e)
			{
			    Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
			    Console.WriteLine("Ejecutando bloque final.");
			}
		}
	}
}