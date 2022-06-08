using System;
using System.Collections;
using EstudioNS;
using ListaIdNS;

namespace TP
{
	class Program 
	{
		private static string datosLeidos = "\n\nValidando la informacion con la base de datos...";
		private static string longCast = "\n  Se esperaba un numero entero(sin puntos)";


		public static void Main(string[] args)
		{
			Estudio estudio = cargarDatos(); 
			while( ejecutar( elegirTarea(), estudio ) ); 
		}
		
		private static bool ejecutar(string item, Estudio e)
		{
			Console.Clear();
			bool ok = true;
			switch(item){
				case "1": 
					ok = Contratar(e);
					break;
				case "2": 
					ok = Despedir(e);
					break;
				case "3": 
					ImprimirLista(e.Abogados, "abogados");
					break;
				case "4": 
					ImprimirLista(e.Expedientes, "expedientes");
					break;
				case "5": 
					ok = Agregar(e);
					break;
				case "6": 
					ok = ModifEstado(e.Expedientes);
					break;
				case "7": 
					ok = Eliminar(e);
					break;
				case "8": 
					FiltrarAudiencias(e.Expedientes);
					break;
				case "9":
					Asignar(e, null);
					break;
				case "s": 
					if (Preguntar(" ¿Esta seguro de que quiere cerrar el programa? S/N "))
						return false;
						break;
				default:
					Console.WriteLine("Opcion invalida. Debe ingresar un numero de 1 al 9.");
					break;
			}
			if ( ! ok )
				Console.WriteLine("\n\nNo pudo completarse la operacion.\n");
			Console.Write("\nPresiona cualquier tecla para volver al menu. . . ");
			Console.ReadKey(true);
			return true;
		}

		public static string elegirTarea()
		{
			Console.Clear();
			Console.WriteLine("1) Agregar abogado");
			Console.WriteLine("2) Eliminar abogado");
			Console.WriteLine("3) Listado de abogados");
			Console.WriteLine("4) Listado de expedientes");
			Console.WriteLine("5) Agregar expediente");
			Console.WriteLine("6) Modificar el estado de un expediente");
			Console.WriteLine("7) Eliminar expediente por numero ");
			Console.WriteLine("8) Listado de expedientes de tipo ‘audiencia'");
			Console.WriteLine("9) Asignar expediente a un abogado");
			Console.WriteLine("s) Salir \n");
			Console.Write("> Numero de Opcion: ");
			return Console.ReadLine().Trim();
		}


/* ---------------------------  OPERACIONES CON ESTUDIO ---------------------------------- */

		public static bool Eliminar(Estudio e)
		{
			Console.WriteLine("Opcion: ELIMINAR EXPEDIENTE : ");

			string n = "";
			if( ! LeerUnDato(ref n, "\nNumero de expediente : ") )
				return false;

			bool ok = false, repetir=false;
			do {
				try{
					repetir = false;
					e.Eliminar(n);
					Console.WriteLine("\nExpediente eliminado");
					ok = true;
				} catch (AdvertenciaConteoErroneo err) {
					Console.WriteLine("\nEliminado\n"+err.MSG);
					ok = true;
				} catch (ExpNoRegistrado err) {
					repetir = Resolver("\n  " +err.MSG, ref n);
				}
			} while(repetir);
			return ok;
		}

		public static bool Despedir(Estudio e)
		{
			Console.WriteLine("Opcion: DESPEDIR ABOGADO: ");

			ulong dni = 0;
			if( ! LeerNumPositivo("\nDNI del abogado: ", ref dni) )
				return false;

			bool ok = false, repetir=false;
			do {
				try{
					repetir = false;
					e.Despedir(dni);
					Console.WriteLine("\n\nAbogado despedido\n");
					ok = true;
				} catch (AdvertenciaConteoErroneo err) {
					Console.WriteLine("\n\nDespedido\n"+err.MSG);
					ok = true;
				} catch (AbogadoNoRegistrado err) {
					repetir = Resolver("\n  " +err.MSG, ref dni);
				}
			} while(repetir);
			return ok;
		}

		public static bool Contratar(Estudio e)
		{
			Console.WriteLine("Opcion: AGREGAR ABOGADO\n");

			ulong dni = 0;
			if ( ! LeerNumPositivo("DNI del abogado", ref dni) )
				return false;

			string[] d = LeerDatos("Nombre/Apellido/Especializacion");
			if ( d == null )
				return false;

			Console.WriteLine(datosLeidos);

			Abogado a = new Abogado(d[0],d[1],dni,d[2]);
			bool ok=false, repetir=false;
			do {
				try{
					repetir = false;
					e.Contratar(a);
					Console.WriteLine("\n\nAgregado con exito\n");
					ok = true;
				} catch(DniRepetido err) {
					repetir = Resolver("\n  " + err.MSG, ref dni);
					a.Dni = dni;
				}
			}while(repetir);
			return ok;
		}

		public static bool Agregar(Estudio est) 
		{
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE");
			
			string[] d = LeerDatos("Numero/Tipo/Estado/Nombre del titular/Apellido del titular");
			if ( d == null )
				return false;

			ulong dni = 0;
			if ( ! LeerNumPositivo("\nDNI del Titular", ref dni) )
				return false;

			Console.WriteLine(datosLeidos);

			Persona p = new Persona(d[3],d[4],dni);
			Expediente exp = new Expediente(d[0],p,d[1],d[2],DateTime.Today); 
			bool ok = false, repetir=false;
			do {
				try {
					repetir=false;
					est.Agregar(exp);
					ok=true;
					Console.WriteLine("\n\nExpediente creado\n");	
				} catch(NumExpedienteRepetido err) { 
					repetir = Resolver("\n  " +err.MSG, ref d[0]);
					exp.Numero = d[0];
				}
			} while(repetir);

			if ( ok )
				if ( Preguntar("\n¿Desea asignar un abogado al expediente? S/N : ") ) {
					Console.WriteLine("\n-------------------------------------------------------------\n");
					if ( Asignar(est, exp.Numero) ) {
						Console.WriteLine("-------------------------------------------------------------");
						Console.WriteLine("\n\nExpediente archivado\n");
					} else
						Console.WriteLine("\n\nEl expediente queda archivado sin un abogado asignado\n");
				}

			return ok;
		}

		public static bool Asignar(Estudio e, string numExp) 
		{
			Console.WriteLine("Opcion: ASIGNAR ABOGADO A UN EXPEDIENTE\n");
			
			if ( numExp == null ) 
				if ( ! LeerUnDato(ref numExp, "Numero de expediente") )
					return false;

			ulong dni = 0;
			if ( ! LeerNumPositivo("DNI del abogado", ref dni) )
				return false;

			Console.WriteLine(datosLeidos);

			bool ok=false,repetir=false;
			do {
				try {
					repetir = false;
					e.Asignar(dni, numExp); 
					Console.WriteLine("El expediente fue asignado al abogado exiosamente.");
					ok = true;
				} catch(ExpNoRegistrado err) {
					repetir = Resolver("\n  " +err.MSG, ref numExp);
				} catch(AdvertenciaConteoErroneo err) { // Esta es una ExcepcionAbogado() particular
					Console.WriteLine("\n  " +err.MSG);
					ok = true;
				} catch(ExcepcionAbogado err) { // DniRepetido() , DemasiadosExpedientes()
					repetir = Resolver("\n  " +err.MSG, ref dni);
				}
			} while(repetir);

			if (ok)
				Console.WriteLine("\n\nEl expediente fue asignado al abogado \n");	
			return ok;
		}

		/* Modifica el estado de un expediente indicado por el usuario.
		 *
		 * Recibe:
		 *   lista: 	La lista donde buscar el expediente
		 * 
		 * Retorna:
		 *   True 		Si se modifico con exito
		 *   False 		No se encontro el expediente o el usuario no ingreso un nuevo estado
		 */
		private static bool ModifEstado(ListaSoloLectura exps)
		{
			Console.WriteLine("Opcion: MODIFICAR ESTADO A UN EXPEDIENTE\n");
			
			Expediente e= (Expediente) Buscar(exps,"Numero de expediente");
			if (e==null)
				return false;
			
			Console.WriteLine("El estado actual es: " + e.Estado);
			string dato = "";			
			if ( LeerUnDato(ref dato,"\nNuevo estado") ) {
				e.Estado = dato;
				Console.WriteLine("\n\nModificado con exito\n");
			}
			
			return true;
		}

		/* Busca el elemento indicado por el usuario.
		 *
		 * Recibe:
		 *   lista: 	La lista donde buscar el elemento  
		 *   etiqueta: 	Nombre del atrbuto que se solicitara al usuario para identificar al elemento
		 *
		 * Retorna:
		 *   Elemento	Perteneciente a la lista
		 *	 null		Si el usuario no quizo seguir intentado luego de ingresar un identificador invalido
		 */
		private static Object Buscar(ListaSoloLectura lista, string etiqueta) 
		{
			string id = "";
			if ( ! LeerUnDato(ref id, etiqueta+": ") )
				return null;

			Object i=null;
			bool repetir;
			do {
				try {
					repetir = false;
					i = lista.Get(id);
					repetir=false;
				} catch(ExpNoRegistrado err) {
					repetir = Resolver("\n  " +err.MSG, ref id);
				} catch(IdInvalido) { 						// Chequear, es para cuando se busca por abogado 
					ulong n = 0;
					repetir = Resolver(longCast, ref n);
					id = n.ToString();
				}
			} while(repetir);
			return i;
		}

		private static bool FiltrarAudiencias(ListaSoloLectura exps)
		{
			Console.WriteLine("Opcion: FILTRAR AUDIENCIAS POR MES\n");
			
			ulong mes = 0;
			bool repetir = true;
			do
			{
				if ( ! LeerNumPositivo("Mes del expediente", ref mes) )
					return false;

				repetir = mes<1 && mes>12;
				if (repetir && ! Preguntar("Se esperaba un numero mayor a cero y menor a trece. ¿Desea reintentar? S/N: "))
					return false;
			} while(repetir);

			Console.WriteLine("\n-----------------------------------------------\n");
			for (int i = 0; i<exps.Count(); i++)
			{
				Expediente e = (Expediente) exps.Get(i); //Las excepciones fueron evitadas con el metodo 'Count()'
				if (e.FechaCreacion.Month == (int)mes)
					Console.WriteLine(e + "\n\n-----------------------------------------------\n");
			}
			return true;
		}


/*-------------------------INTERACTUAR CON EL USUARIIO--------------------------------*/
		
		public static void ImprimirLista(ListaSoloLectura lista, string t) 
		{
			Console.WriteLine("Opcion: IMPRIMIR "+ t.ToUpper());
			if ( lista.Count() == 0 )
				Console.WriteLine("No hay " + t);
			else
				Console.WriteLine(lista);
		}

		public static string[] LeerDatos(string nombres)
		{
			string[] split = nombres.Split('/');
			for(int i=0; i<split.Length; i++) {
				if ( ! LeerUnDato(ref split[i], "\n"+split[i]) )
					return null;
			}
			return split;
		}

		public static bool LeerUnDato(ref string dato, string etiqueta) 
		{
			string nuevo;
			Console.Write(etiqueta+": ");
			bool ok = true;
			//nuevo = Console.ReadLine().ToUpper().Trim();
			
			if( nuevo == "" || nuevo == null )
				ok = Resolver("No se ingreso ningun valor", ref dato);
			if (ok)
				dato = nuevo;
			return ok;
		}

		public static bool Resolver(string msg, ref string s){
			Console.WriteLine("\n  "+msg);
			bool ok=false;
			if( Preguntar("\n  ¿Desea intentar con un valor distinto? S/N : ") )
				ok = LeerUnDato(ref s, "\n  Ingrese otro: ");  // NullPointerException
			return ok;
		}
		
		public static bool Resolver(string msg, ref ulong n){
			Console.WriteLine("\n  "+msg);
			bool ok=false;
			if( Preguntar("\n  ¿Desea intentar con un numero distinto? S/N : ") )
				ok = LeerNumPositivo("\n  Ingrese otro numero: ", ref n);
			return ok;
		}

		public static bool Preguntar(string pregunta)
		{
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.Write(pregunta);
				rta = Console.ReadLine().ToUpper();
			}
			return rta=="S";
		}
		
		public static bool LeerNumPositivo(string etiqueta, ref ulong n){
			string s = "";
			if ( ! LeerUnDato(ref s, etiqueta) )
				return false;

			bool ok=false, repetir=false;
			do{
				try {
					repetir = false;
					n = ulong.Parse(s);
					ok = true;
				} catch (FormatException) {
					repetir = Resolver(longCast, ref s);
				}
			} while (repetir);
			return ok;
		}


/*------------------------------  ARCHIVOS --------------------------------------*/

		public static Estudio cargarDatos()
		{
			Estudio estudio = new Estudio();
			string nombre = "maxi";
			string apellido = "lopez";
			ulong dni = 1;
			Persona titular = new Persona(nombre,apellido,dni);
			string espec = "familiar";
			Abogado abogado = new Abogado(nombre, apellido, dni, espec);
			Expediente expediente = new Expediente("1",titular,"audiencia", "activo", DateTime.Today);
			estudio.Agregar(expediente);
			estudio.Contratar(abogado);
			estudio.Asignar(abogado.Dni, expediente.Numero);
			return estudio;
		}
			
	}

}

