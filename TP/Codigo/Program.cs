using System;
using System.Collections;
using EstudioNS;
using ListaIdNS;

namespace TP 
{
	class Program 
	{
		private static string datosLeidos = "\n\nValidando la informacion con la base de datos...";
		private static string longCastExceptionMsg = "\n  Se esperaba un numero entero(sin puntos)";

		public static void Main(string[] args)
		{
			Estudio estudio = cargarDatos(); 
			while( ejecutar( elegirOpcion(),estudio ) ); 
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
					break;
				case "9":
						Asignar(e, null);
						break;
				case "s": 
					if (preguntar(" ¿Esta seguro de que quiere cerrar el programa? S/N "))
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

		public static string elegirOpcion()
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
				} catch (NumExpInvalido err) {
					repetir = resolver("\n  " +err.MSG, ref n);
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
				} catch (DniInvalido err) {
					repetir = resolver("\n  " +err.MSG, ref dni);
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
					repetir = resolver("\n  " + err.MSG, ref dni);
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
					if ( preguntar("\n¿Desea asignar un abogado al expediente? S/N : ") ) {
						Console.WriteLine("\n-------------------------------------------------------------\n");
						if ( Asignar(est, exp.Numero) ) {
							Console.WriteLine("-------------------------------------------------------------");
							Console.WriteLine("\n\nExpediente archivado\n");
						} else
							Console.WriteLine("\n\nEl expediente queda archivado sin un abogado asignado\n");
					}
				} catch(NumExpedienteRepetido err) { 
					repetir = resolver("\n  " +err.MSG, ref d[0]);
					exp.Numero = d[0];
				}
			} while(repetir);

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
					ok = true;
				} catch(NumExpInvalido err) {
					repetir = resolver("\n  " +err.MSG, ref numExp);
				} catch(AdvertenciaConteoErroneo err) { // Esta es una ExcepcionAbogado() particular
					Console.WriteLine("\n  " +err.MSG);
					ok = true;
				} catch(ExcepcionAbogado err) { // DniRepetido() , DemasiadosExpedientes()
					repetir = resolver("\n  " +err.MSG, ref dni);
				}
			} while(repetir);

			if (ok)
				Console.WriteLine("\n\nEl expediente fue asignado al abogado \n");	
			return ok;
		}

		private static bool ModifEstado(ListaSoloLectura exps)
		{
			Console.WriteLine("Opcion: MODIFICAR ESTADO A UN EXPEDIENTE\n");
			
			Expediente e= (Expediente) Buscar(exps,"Numero de expediente");
			if (e==null)
				return false;

			string dato = "";			
			if ( LeerUnDato(ref dato,"\nNuevo estado") ) {
				e.Estado = dato;
				Console.WriteLine("\n\nModificado con exito\n");
			}
			
			return true;
		}

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
				} catch(NumExpInvalido err) {
					repetir = resolver("\n  " +err.MSG, ref id);
				} catch(FormatException) { 						// Chequear, es para cuando se busca por abogado 
					ulong n = 0;
					repetir = LeerNumPositivo(longCastExceptionMsg, ref n);
					id = n.ToString();
				}
			} while(repetir);
			return i;
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
			nuevo = Console.ReadLine().ToUpper().Trim();
			if( nuevo == "" || nuevo == null )
				ok = resolver("No se ingreso ningun valor", ref dato);
			if (ok)
				dato = nuevo;
			return ok;
		}

		public static bool resolver(string msg, ref string s){
			Console.WriteLine("\n  "+msg);
			bool ok=false;
			if( preguntar("\n  ¿Desea intentar con un valor distinto? S/N : ") )
				ok = LeerUnDato(ref s, "\n  Ingrese otro: ");  // NullPointerException
			return ok;
		}
		
		public static bool resolver(string msg, ref ulong n){
			Console.WriteLine("\n  "+msg);
			bool ok=false;
			if( preguntar("\n  ¿Desea intentar con un numero distinto? S/N : ") )
				ok = LeerNumPositivo("\n  Ingrese otro numero: ", ref n);
			return ok;
		}

		public static bool preguntar(string pregunta)
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
					repetir = resolver(longCastExceptionMsg, ref s);
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

/*
Ejemplo funcion AgregarAbogado, sin utilizar excepcines:
			
			Console.WriteLine("Opcion: AGREGAR ABOGADO \n");
			string[] d = LeerDatos("Nombre/Apellido/DNI/Especializacion");
			if (d==null)
				return;
			Abogado a=null;
			bool repetir;
			repetir = true;
			while(repetir) {
				a = new Abogado(d[0],d[1],d[2],d[3]);
				if (a==null)
					repetir = resolver(ref d[2], "Formato del DNI invalido, debe ser un numero (sin puntos)");
				else if (abogados.Agregar(a))
						repetir = false;
					else
						repetir = resolver(ref d[2], "El DNI ya esta registrado con otro abogado");
			}

Desventajas:
	No se puede reutilizar los mensajes si se repite el error en otra funcion
	Es mas complejo seguir la logica de cada uno de los posibles casos
	Si hubieran mas de una excepcion asociada a un mismo caso, seria mas engorroso por este camino. 
	Casi la mismas cantidad de lineas de codigo

Otro ejemplo, mismas deventajas:

		public static void AgregarExpediente2(Estudio estudio) {
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE\n");
			string[] d = LeerDatos("Numero/Tipo/Estado/Nombre del titular/Apellido del titular/DNI del titular");
			if (d==null)
				return;
			Persona p = null;
			bool repetir=true;
			do{
				p = new Persona(d[3],d[4],d[5]); 
				if (p==null && ! resolver(ref d[5],"ssadasdsadasdasdasd;lasjdlasjd;ahsd;hsadiahsudihsad"))
					return;
				else 
					repetir = false;
			}while(repetir);
			Abogado a = null;
			do {
				a = (Abogado) pedir(estudio.Abogados, "DNI del Abogado");
				if (a!=null && a.CantExps==a.MaxExp){
					repetir = resolver(ref d[6], "ssadasdsadasdasdasd;lasjdlasjd;ahsd;hsadiahsudihsad");
					a = null;
				} else
					repetir=false;
			] while (repetir);		
			if (a==null)
				Console.WriteLine("El expediente fue creado, pero no tiene abogado asignado.");
			Expediente e = new Expediente(d[0],p,d[1],d[2],a,DateTime.Today); 
			do {
				if ( ! estudio.Expedientes.Agregar(e)) {
					string n = e.Numero;
					repetir = resolver(ref n,"ssadasdsadasdasdasd;lasjdlasjd;ahsd;hsadiahsudihsad");
					if (repetir)
						e.Numero = n;
				} else
					repetir=false;
			}while(repetir);
		}

*/