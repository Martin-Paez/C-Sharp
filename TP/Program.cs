/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 23/05/2022
 * Time: 18:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using EstudioNS;

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
					ImprimirLista(e.Abogados, "abogados");
					break;
				case "4":
					ImprimirLista(e.Expedientes, "expedientes");
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
				case "devMode":
					exit = "Modo desarrollador deshabilitado";
					break;
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

		public static void EliminarAbogado(Estudio e){
			Console.WriteLine("Opcion: ELIMINAR ABOGADO \n");
			Console.Write("DNI del abogado: ");
			if ( e.EliminarAbogado(Console.ReadLine()) )
				Console.WriteLine("Eliminado");
			else
				Console.WriteLine("No encontrado");
		}
		
		public static string[] LeerDatos(string nombres){
			string[] split = nombres.Split('/');
			for(int i=0; i<split.Length; i++) {
				Console.Write("  "+split[i]+": ");
				split[i] = Console.ReadLine();
			}
			return split;
		}
	
		public static void AgregarAbogado(Estudio e){
			Console.WriteLine("Opcion: AGREGAR ABOGADO \n");
			string[] d = LeerDatos("Nombre/Apellido/DNI/Especializacion");
			bool ok=true;
			while(ok){
				try{
					e.AgregarAbogado( new Abogado(d[0],d[1],d[2],d[3]) );
					ok = false;
				}catch(DniRepetido err){
					d[2] = err.resolver(); 
				}}
		}
		
		public static void AgregarExpediente(Estudio estudio) {
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE\n");
			string[] d = LeerDatos("Tipo/Estado/Nombre del titular/Apellido del titular/DNI del titular");
			Persona p = new Persona(d[2],d[3],d[4]);
			
			string rta;
			Abogado a;
			do {
				rta="";
				Console.Write("\nDni del Abogado: ");
				a = estudio.GetAbogado(Console.ReadLine());
				if ( a == null )
					Console.WriteLine("No se encontro abogado");
				else if(a.CantExps>=6)
					Console.WriteLine("El abogado tiene demasiados expedientes asignados");
				else
					rta="S"; //Cargado con Exito
				while ( rta != "S" & rta != "N" ) {
					Console.WriteLine("¿Desea dejar el expediente sin asignar? S/N");
					rta = Console.ReadLine().ToUpper();
				} 					
			} while ( rta != "N");
			
			bool ok;
			do {
				ok = false;
				Console.Write("Numero: ");
				Expediente e = new Expediente(Console.ReadLine(),p,d[0],d[1],a,DateTime.Today); // Lo creamos aca porque pidio la Profe
				try {
					estudio.AgregarExpediente( e );
				} catch (Exception err) {
					//ManejadorDeEstudio.resolver(err.Message);
					Console.WriteLine("");
					ok=true;
				}
			} while(ok);
		}
		
		private static void modifExpediente(string numero){
			
		}
		
/*-------------------------IMPRIMIR POR PANTALLA ---------------------------------------*/
		
		public static void ImprimirLista(ArrayList list, string t) {
			Console.WriteLine("Opcion: IMPRIMIR "+ t.ToUpper() + "\n");
			if ( list.Count == 0 )
				Console.WriteLine("No hay " + t);
			else
				foreach(Object e in list) {
					Console.WriteLine(e);
				}
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
			
	}
}