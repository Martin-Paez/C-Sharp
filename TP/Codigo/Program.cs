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
using IdentificableNS;

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
					AgregarAbogado(e.Abogados);
					break;
				case "2":
					Eliminar("abogado","DNI", e.Abogados);
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
					Eliminar("expediente","Numero", e.Expedientes);
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

		public static void Eliminar(string tipo, string id, ListaId lista){
			Console.WriteLine("Opcion: ELIMINAR " + tipo.ToUpper() );
			Console.Write("\n" + id + " del " + tipo + ": ");
			id = Console.ReadLine();
			bool repetir=false;
			do {
				try{
					lista.Eliminar(id);
				} catch (InconsistenciaExpedientesSinAsignar err) {
					Console.WriteLine("Eliminado\n"+err.MSG);
				} catch (IdInvalido err) {
					repetir = resolver(ref id,err.MSG);}
			} while(repetir);
		}

		public static void AgregarAbogado(ListaAbogados abogados){
			Console.WriteLine("Opcion: AGREGAR ABOGADO \n");
			string[] d = LeerDatos("Nombre/Apellido/DNI/Especializacion");
			if (d==null)
				return;
			Abogado a=null;
			bool repetir=true;
			while(repetir){
				try{
					a = new Abogado(d[0],d[1],d[2],d[3]); // DNI invalido
					abogados.Agregar(a); // DNI repetido
					repetir = false;
				}catch(DatoInvalido err){
					repetir = resolver(ref d[2],err.MSG);
				}}
		}

		public static void AgregarExpediente(Estudio estudio) {
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE\n");
			string[] d = LeerDatos("Numero/Tipo/Estado/Nombre del titular/Apellido del titular/DNI del titular/Dni del Abogado: ");
			if (d==null)
				return;
			Persona p = new Persona(d[3],d[4],d[5]);
			Abogado a=null;
			bool repetir=true;
			while(repetir){
				try{
					a = (Abogado)estudio.Abogados.Get(d[6]);
					repetir = false;
				}catch(DniRepetido err){
					repetir = resolver(ref d[6],err.MSG);
				}}
			Expediente e = new Expediente(d[0],p,d[1],d[2],a,DateTime.Today); 
			repetir=true;
			while(repetir){
				try{
					estudio.Expedientes.Agregar(e);
					repetir = false;
				}catch(DatoInvalido err){
					string n = e.Numero;
					repetir = resolver(ref n,err.MSG);
					if (repetir)
						e.Numero = n;
				}}
		}

		private static void modifExpediente(string numero){
			
		}

/*-------------------------INTERACTUAR CON EL USUARIIO--------------------------------*/
		
		public static void ImprimirLista(ListaId lista, string t) {
			Console.WriteLine("Opcion: IMPRIMIR "+ t.ToUpper() + "\n");
			if ( lista.Count() == 0 )
				Console.WriteLine("No hay " + t);
			else
				Console.WriteLine(lista);
		}

		public static string[] LeerDatos(string nombres){
			string[] split = nombres.Split('/');
			for(int i=0; i<split.Length; i++) {
				Console.Write("  "+split[i]+": ");
				if ( ! LeerUnDato(ref split[i]) )
					return null;
			}
			return split;
		}

		public static bool resolver(ref string param, string msg){
			Console.WriteLine(msg);
			bool ok = deseaContinuar();
			if(ok) {
				Console.Write("\n Ingrese nuevamente: ");
				ok = LeerUnDato(ref param);
			} 
			return ok;
		}

		public static bool LeerUnDato(ref string dato) {
			bool ok = true;
			try{
				dato = tieneDatos(Console.ReadLine()).ToUpper();
			} catch (SinValor err) {
				ok = resolver(ref dato, err.MSG);
			} 
			return ok;
		}

		public static bool deseaContinuar(){
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.WriteLine("\n¿Desea intentar nuevamente? S/N");
				rta = Console.ReadLine().ToUpper();
			}
			return rta=="S";
		}

		public static string tieneDatos(string value){
			if(value == "" || value == null)
				throw new SinValor();
			return value;
		}		
/*------------------------- CARGAR DATOS / ARCHIVOS -----------------------------------*/

		public static Estudio initWorld(){
			Estudio estudio = new Estudio();
			string nombre = "maxi";
			string apellido = "lopez";
			string dni = "34";
			Persona titular = new Persona(nombre,apellido,dni);
			string espec = "familiar";
			Abogado abogado = new Abogado(nombre, apellido, dni, espec);
			Expediente expediente = new Expediente("1",titular,"audiencia", "activo", abogado, DateTime.Today);
			estudio.Expedientes.Agregar(expediente);
			estudio.Abogados.Agregar(abogado);
			return estudio;
		}
			
	}

	public class SinValor:DatoInvalido{
		public SinValor() {
			this.msg = "No se ingreso ningun valor";
		}
	}

}