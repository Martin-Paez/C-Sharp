using System;
using System.Collections;
using EstudioNS;
using ListaIdNS;

namespace TP 
{
	class Program 
	{
		private const string ABOGADO = "abogado";
		private const string EXPEDIENTE = "expediente";

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
					ok = AgregarAbogado(e);
					break;
				case "2": 
					ok = Eliminar(ABOGADO,"DNI", e);
					break;
				case "3": 
					ImprimirLista(e.Staff, ABOGADO);
					break;
				case "4": 
					ImprimirLista(e.Fichero, EXPEDIENTE);
					break;
				case "5": 
					ok = AgregarExpediente(e);
					break;
				case "6": 
					ok = ModifEstado(e.Fichero);
					break;
				case "7": 
					ok = Eliminar(EXPEDIENTE,"Numero", e);
					break;
				case "8": 
					break;
				case "9": 
					if (preguntar(" ¿Esta seguro de que quiere cerrar el programa? S/N "))
						return false;
						break;
				default:
					Console.WriteLine("Opcion invalida. Debe ingresar un numero de 1 al 9.");
					break;
			}
			if ( ! ok )
				Console.WriteLine("\nNo pudo completarse la operacion.");
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
			Console.WriteLine("9) Salir \n");
			Console.Write("> Numero de Opcion: ");
			return Console.ReadLine().Trim();
		}

		public static bool Eliminar(string tipo, string id, Estudio e)
		{
			Console.WriteLine("Opcion: ELIMINAR " + tipo.ToUpper() );

			if( ! LeerUnDato(ref id, "\n" + id + " del " + tipo + ": ") )
				return false;

			bool ok = false, repetir=false;
			do {
				try{
					repetir = false;
					if ( tipo == ABOGADO )
						e.Despedir(id);
					else 
						e.Eliminar(id);
					Console.WriteLine("\nEliminado con exito");
					ok = true;
				} catch (WarningConteoErroneo err) {
					Console.WriteLine("\nEliminado\n"+err.MSG);
					ok = true;
				} catch (IdInvalido err) {
					repetir = resolver(err.MSG, ref id);
				}
			} while(repetir);
			return ok;
		}

		public static bool AgregarAbogado(Estudio e)
		{
			Console.WriteLine("Opcion: AGREGAR ABOGADO");

			string[] d = LeerDatos("Nombre/Apellido/Especializacion");
			if ( d == null )
				return false;

			ulong dni;
			if ( ! LeerNumPositivo("DNI del abogado: ", null, ref dni) )
				return false;

			Abogado a = new Abogado(d[0],d[1],dni,d[2]);
			bool ok=false, repetir=false;
			do {
				try{
					repetir = false;
					e.Contratar(a);
					Console.WriteLine("\nAgregado con exito");
					ok = true;
				} catch(DniRepetido err) {
					repetir = resolver(err.MSG, ref dni);
					a.corregirDni(dni);
				}
			}while(repetir);
			return ok;
		}

		// Se acepta un abogado null, por ejemplo si todos los abogados completaron su cupo.
		public static bool AgregarExpediente(Estudio est) 
		{
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE");
			
			string[] d = LeerDatos("Numero/Tipo/Estado/Nombre del titular/Apellido del titular");
			if ( d == null )
				return false;

			ulong dni;
			if ( ! LeerNumPositivo("DNI del Titular", null, ref dni) )
				return false;

			Persona p = new Persona(d[3],d[4],dni);
			Expediente exp = new Expediente(d[0],p,d[1],d[2],DateTime.Today); 
			bool ok = false, repetir=false;
			do {
				try {
					repetir=false;
					est.Agregar(exp);
					ok=true;
					Console.WriteLine("\nExpediente creado\n");
					if ( ! AsignarAbogado(exp, est.Staff) )
						Console.WriteLine("\nEl expediente queda archivado sin un abogado asignado");
					else
						Console.WriteLine("\nExpediente archivado");
				} catch(NumExpedienteRepetido err) { 
					string n = exp.Numero;
					repetir = resolver(err.MSG, ref n);
					if (repetir)
						exp.Numero = n;
				}
			} while(repetir);

			return ok;
		}

		public static bool AsignarAbogado(Expediente e, ListaSoloLectura abogados) 
		{
			Console.WriteLine("Opcion: ASIGNAR ABOGADO A UN EXPEDIENTE");
			
			string dni;
			if ( ! LeerNumPositivo("DNI del abogado: ", ref dni, null) )
				return false;
				
			bool ok=false,repetir=false;
			Abogado a;
			do {
				try {
					repetir = false;
					a = (Abogado) abogados.Get(dni); //IdInvalido
					e.SetAbogado(a); // DemasiadosExpedientes
					ok = true;
				} catch(DatoInvalido err) { // IdInvalid() o DemasiadosExpedientes(), se necesita otro DNI
					if ( ! (repetir = resolver("\nAbogado: "+err.MSGm, ref dni)) )
					a = null;	
				}
			} while(repetir);
			return ok;		
		}

		private static bool ModifEstado(ListaSoloLectura exps)
		{
			Console.WriteLine("Opcion: MODIFICAR ESTADO A UN EXPEDIENTE");
			Expediente e= (Expediente) pedir(exps,"Numero de expediente");
			if (e==null)
				return false;
			string dato;			
			if ( LeerUnDato(ref dato,"\nNuevo estado") ) {
				e.Estado = dato;
				Console.WriteLine("\nModificado con exito");
			}
			return true;
		}

		private static Object pedir(ListaSoloLectura lista, string etiqueta) 
		{
			string id;
			if ( ! LeerUnDato(ref id, etiqueta+": ") )
				return null;
			
			Object i=null;
			bool repetir;
			do {
				try {
					i = lista.Get(id);
					repetir=false;
				} catch(IdInvalido err) {
					repetir = resolver(err.MSG+ " al " + etiqueta, ref id);
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
				if ( ! LeerUnDato(ref split[i], "\n"+split[i]+": ") )
					return null;
			}
			Console.WriteLine("\nDatos leidos, analizando informacion...");
			return split;
		}

		public static bool LeerUnDato(ref string dato, string msg) 
		{
			string nuevo;
			Console.WriteLine(msg);
			bool ok = true;
			nuevo = Console.ReadLine().ToUpper().Trim();
			if( nuevo == "" || nuevo == null )
				ok = resolver("No se ingreso ningun valor", ref dato);
			if (ok)
				dato = nuevo;
			return ok;
		}

		public static bool resolver(string msg, ref string s){
			ulong n = null;
			return resolver(msg, ref s, ref n);
		}
		
		public static bool resolver(string msg, ref ulong n){
			string s = null;
			return resolver(msg, ref s, ref n, false);
		}

		public static bool resolver(string msg, ref string s, ref ulong n, bool leerString=true)
		{
			Console.WriteLine(msg);
			bool ok=false;
			if( preguntar("\n¿Desea intentar con un valor distinto? S/N : ") )
				if ( leerString ) 
					ok = LeerUnDato(ref s, "\nIngrese otro: ");  // NullPointerException
				else
					ok = LeerNumPositivo("\nIngrese otro numero: ", ref n);
			if (ok)
				Console.WriteLine("\nDato leido, trabajando ...");
			return ok;
		}

/*
		f( s )
			...
			g( s )
			...

		f( n )

		f( x ) = h ( g( x ) )

		( x == n ) => g = g( n )
		( x == s ) => g = g( s )

		ulong n = 0;
		f ( ref n )

		string s = "";
		f ( ref s )

		f ( ref Object o )
			g ( o )

		g ( ref Object )
			throw Exception()

		g ( ref ulong n )

		g ( ref string s )



		bool leerDato(n)
		bool leerDato(s)

		bool leerNumero(s)
*/

		public static bool preguntar(string pregunta)
		{
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.Write(pregunta);
				rta = Console.ReadLine().ToUpper();
			}
			return rta=="S";
		}

		public static bool LeerNumPositivo(string msg, ref string dato){
			ulong n = 0;
			return resolver(msg, dato, ref n);
		}
		
		public static bool LeerNumPositivo(string msg, ref ulong num){
			string s = "";
			return resolver(msg, ref s, num);
		}

		// 0 < n < 4,294,967,295 , en China hay 1,4G
		// Si el valor es acumulativo, solo puede aumentar con los nacimientos.
		// En argentina los extranjeros son numerados con valores mucho mas altos que los nativos.
		public static bool LeerNumPositivo(string etiqueta, ref string s, ref ulong n)
		{
			if ( ! LeerUnDato(ref s, etiqueta) )
				return false;

			bool ok=false, repetir;
			do{
				try {
					n = ulong.Parse(s);
					ok = true;
				} catch (FormatException) {
					repetir = resolver("\n"+etiqueta+": Se esperaba un numero entero(sin puntos)", ref s);
				}
			} while (repetir);
			return ok;
		}

/*------------------------- CARGAR DATOS / ARCHIVOS -----------------------------------*/

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
			expediente.SetAbogado(abogado);
			estudio.Agregar(expediente);
			estudio.Contratar(abogado);
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