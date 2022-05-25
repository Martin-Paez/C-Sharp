/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			Estudio e = initWorld();
			while( resolverItem( elegirItem() , e) );
		}
		
		private static bool resolverItem(string item, Estudio e){
			Console.Clear();
			string exit = "\nPresiona una tecla para volver al menu. . . ";
			switch(item.Trim()){
				case "1":
					AgregarAbogado(e);
					break;
				case "2":
					EliminarAbogado(e);
					break;
				case "3":
					ImprimirAbogados(e);
					break;
				case "4":
					ImprimirExpedientes(e);
					break;
				case "5":
					AgregarExpediente(e);
					break;
				case "6":
					break;
				case "7":
					break;
				case "8":
					break;
				case "9":
					return false;
				default:
					exit = "Opcion invalida";
					break;
			}
			Console.Write(exit);
			Console.ReadKey(true);
			return true;
		}
		
		public static string elegirItem(){
			Console.Clear();
			Console.WriteLine("1) Agregar abogado");
			Console.WriteLine("2) Eliminar abogado");
			Console.WriteLine("3) Listado de abogados");
			Console.WriteLine("4) Listado de expedientes");
			Console.WriteLine("5) Agregar expediente");
			Console.WriteLine("6) Modificar el estado de un expediente");
			Console.WriteLine("7) Eliminar expediente por numero ");
			Console.WriteLine("8) Listado de expedientes de tipo ‘audiencia'");
			Console.WriteLine("9) Salir \n");
			Console.Write("> Numero de Opcion: ");
			return Console.ReadLine();
		}

		public static void AgregarAbogado(Estudio e){
			Console.WriteLine("Opcion: AGREGAR ABOGADO \n");
			string nombre="", apellido="", dni="";
			crearPersona(ref nombre, ref apellido, ref dni);
			try {
				Console.Write("Especializacion: ");
				e.AgregarAbogado( new Abogado(nombre, apellido, dni, Console.ReadLine()) );
			} catch (Exception err) {
				Manejador.resolver(err.Message);
			}
		}
		
		public static void LeerPersona(ref string nombre, ref string apellido, ref string dni){
			Console.Write("Nombre: ");
			nombre = Console.ReadLine();
			Console.Write("Apellido: ");
			apellido = Console.ReadLine();
			Console.Write("DNI: ");
			dni = Console.ReadLine();
		}
	
		public static void EliminarAbogado(Estudio e){
			Console.WriteLine("Opcion: ELIMINAR ABOGADO \n");
			Console.Write("DNI del abogado: ");
			if ( e.EliminarAbogado(Console.ReadLine()) )
				Console.WriteLine("Eliminado");
			else
				Console.WriteLine("No encontrado");
		}
		
		public static void AgregarExpediente(Estudio estudio) {
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE\n");
			Console.Write("Titular: \n");
			string nombre="", apellido="", dni="";
			LeerPersona(ref nombre, ref apellido, ref dni);
			Persona p = new Persona(nombre, apellido, dni);
			Console.Write("Dni del Abogado: ");
			Abogado a = estudio.GetAbogado(Console.ReadLine());
			Console.Write("Tipo: ");
			string tipo = Console.ReadLine();
			Console.Write("Estado: ");
			string estado = Console.ReadLine();
			bool ok;
			do {
				ok = false;
				Console.Write("Numero: ");
				string numero = Console.ReadLine();
				Expediente e = new Expediente(numero, p, tipo, estado, a, DateTime.Today); // Lo creamos aca porque pidio la Profe
				try {
					estudio.AgregarExpediente( e );
				} catch (Exception err) {
					Manejador.resolver(err.Message);
					Console.WriteLine("");
					ok=true;
				}
			} while(ok);
		}
		
		private static void modifExpediente(string numero){
			
		}
		
/*------------------------- CARGAR DATOS / ARCHIVOS -----------------------------------*/
		
		public static Estudio initWorld(){
			Estudio estudio = new Estudio();
			string nombre = "maxi";
			string apellido = "lopez";
			string dni = "34.123.123";
			Persona titular = new Persona(nombre,apellido,dni);
			string espec = "familiar";
			Abogado abogado = new Abogado(nombre, apellido, dni, espec);
			Expediente expediente = new Expediente("1",titular,"audiencia", "activo", abogado, DateTime.Today);
			estudio.AgregarExpediente(expediente);
			estudio.AgregarAbogado(abogado);
			return estudio;
		}
		
/*-------------------------IMPRIMIR POR PANTALLA ---------------------------------------*/
		
		private static void ImprimirPersona(Persona p) {
			Console.WriteLine("Nombre y apellido: " + p.Nombre + " " + p.Apellido);
			Console.WriteLine("DNI: " + p.Dni);
		}
		
		public static void ImprimirAbogado(Abogado a) {
			ImprimirPersona(a);
			Console.WriteLine("Especializacion: " + a.Espec + "\n");
		}
		
		public static void ImprimirAbogados(Estudio e) {
			Console.WriteLine("Opcion: IMPRIMIR ABOGADOS \n");
			if ( e.Abogados.Count == 0 )
				Console.WriteLine("No hay abogados");
			else
				foreach(Abogado a in e.Abogados) {
				ImprimirAbogado(a);
				}
		}
				
		public static void ImprimirExpedientes(Estudio estudio) {
			Console.WriteLine("Opcion: IMPRIMIR EXPEDIENTES\n");
			if ( estudio.Expedientes.Count == 0 )
				Console.WriteLine("No hay expedientes");
			else
				foreach(Expediente e in estudio.Expedientes) {
					Console.WriteLine("Numero de expediente: " + e.Numero);
					Console.WriteLine("Estado: " + e.Estado);
					Console.WriteLine("Tipo: " + e.Tipo);
					Console.WriteLine("Fecha de creacion: " + e.FechaCreacion);
					Console.WriteLine("\nDatos del titular: ");
					ImprimirPersona(e.Titular);
					if (e.Abogado != null) {
						Console.WriteLine("\nDatos del abogado: ");
						ImprimirAbogado(e.Abogado);
						Console.WriteLine("");
					} else 
						Console.WriteLine("\nNo tiene un abogado asignado \n");
				}
		}
			
	}
}