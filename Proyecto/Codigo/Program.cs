using System;
using System.Collections;
using System.IO;
using EstudioNS;
using ListaIdNS;

namespace TP
{
	class Program 
	{
		private static string datosLeidos = "\n\nValidando la informacion con la base de datos...";
		private static string longCast = "Se esperaba un numero entero (sin puntos)";
	
		public static void Main(string[] args)
		{
			Estudio estudio = cargarDatos("Datos.txt"); 
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
			/* Elimina el expediente indicado por el usuario 
		 *
		 * Recibe:
		 * 	Estudio:    Estudio que guarda el expediente
		 *
		 * Retorna:
		 * 	True        El expediente fue eliminado
		 * 	False       El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
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

		/* Despide al abogado indicado por el usuario
 		 *
 		 * Recibe:
 		 *   Estudio:   Estudio en el que trabaja el abogado
 		 *
 		 * Retorna:
 		 *   True       El abogado fue despedido
 		 *   False      El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
 		 */
		public static bool Despedir(Estudio e)
		{
			Console.WriteLine("Opcion: DESPEDIR ABOGADO: ");

			string dni = "";
			if( ! LeerUnDato(ref dni, "\nDNI del abogado: ") )
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

		/* Contrata un abogado con los datos ingresados por el usuario
		 * 
		 * Recibe:
		 *   Estudio:   Estudio que contratara al abogado
		 *
		 * Retorna:
		 *   True       El abogado fue contratado
		 *   False      El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		public static bool Contratar(Estudio e)
		{
			Console.WriteLine("Opcion: AGREGAR ABOGADO\n");

			string[] d = LeerDatos("DNI del abogado/Nombre/Apellido/Especializacion");
			if ( d == null )
				return false;

			Console.WriteLine(datosLeidos);

			Abogado a = null;
			bool ok=false, repetir=false;
			do {
				try{
					a = new Abogado(d[0],d[1],d[0],d[2]);
					repetir = false;
					e.Contratar(a);
					Console.WriteLine("\n\nAgregado con exito\n");
					ok = true;
				} catch(DatoInvalido err) {
					repetir = Resolver("\n  " + err.MSG, ref d[0]);
				}
			}while(repetir);
			return ok;
		}

		/* Agrega un expediente con los datos ingresados por el usuario
		 *
		 * Recibe:
		 *   Estudio:   Estudio que guardara el expediente
		 *
		 * Retorna:
		 *   True       El expediente fue agregado (con o sin un abogado asignado)
		 *   False      El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		public static bool Agregar(Estudio est) 
		{
			Console.WriteLine("Opcion: AGREGAR EXPEDIENTE");
			
			string[] d = LeerDatos("Numero/Tipo/Estado/Nombre del titular/Apellido del titular/DNI del Titular");
			if ( d == null )
				return false;

			Console.WriteLine(datosLeidos);

			Expediente exp = null;;
			bool ok = false, repetir=false;
			do {
				try {
					Persona p = new Persona(d[3],d[4],d[5]);
					exp = new Expediente(d[0],p,d[1],d[2],DateTime.Today); 
					repetir=false;
					est.Agregar(exp);
					ok=true;
					Console.WriteLine("\n\nExpediente creado\n");	
				} catch(FormatoDni err) {
					repetir = Resolver("\n  " +err.MSG, ref d[5]);
				}catch(DatoInvalido err) { 
					repetir = Resolver("\n  " +err.MSG, ref d[0]);
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

		/* Asigna un abogado indicado por el usuario a un expediente determinado
		 *
		 * Recibe:
		 *   e:         Estudio que guarda el expediene y en el que trabaja el abogado 
		 *   numExp:    Numero del expediente al cual será asignado el abogado
		 *
		 * Retorna:
		 *   True       El abogado fue asignado al expediente	
		 *   False      El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		public static bool Asignar(Estudio e, string numExp) 
		{
			Console.WriteLine("Opcion: ASIGNAR ABOGADO A UN EXPEDIENTE\n");
			
			if ( numExp == null ) 
				if ( ! LeerUnDato(ref numExp, "Numero de expediente") )
					return false;

			string dni = "";
			if ( ! LeerUnDato(ref dni, "DNI del abogado") )
				return false;

			Console.WriteLine(datosLeidos);

			bool ok=false,repetir=false;
			do {
				try {
					repetir = false;
					e.Asignar(dni, numExp); 
					Console.WriteLine("El expediente fue asignado al abogado exitosamente.");
					ok = true;
				} catch(ExpNoRegistrado err) {
					repetir = Resolver("\n  " +err.MSG, ref numExp);
				} catch(AdvertenciaConteoErroneo err) { // Esta es una ExcepcionAbogado() particular
					Console.WriteLine("\n  " +err.MSG);
					ok = true;
				} catch(ExcepcionAbogado err) { // DniRepetido() , DemasiadosExpedientes(), // AbogadoNoRegistrado()
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
				} catch(IdInvalido err) { 						// Chequear, es para cuando se busca por abogado 
					repetir = Resolver("\n  " + err.MSG, ref id);
				}
			} while(repetir);
			return i;
		}

		/* Imprime los expedientes de tipo audiencia creados durante el mes que indique el usuario
		 *
		 * Recibe:
		 *   lista:     Lista de expedientes a filtrar
		 *
		 * Retorna:
		 *   True       Los expedientes filtados fueron mostrados por consola
		 *   False      El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		private static bool FiltrarAudiencias(ListaSoloLectura exps)
		{
			Console.WriteLine("Opcion: FILTRAR AUDIENCIAS POR MES\n");
			
			int mes = 0;
			string s = "";
			bool repetir = true;
			do
			{
				if ( ! LeerUnDato(ref s, "Mes del expediente") )
					return false;
				try{
					mes = int.Parse(s);
					repetir = mes<1 && mes>12;
				} catch {
					repetir = false;
				}
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

		/* Imprime una lista los elementos 
 		 *
 		 * Recibe:
 		 *   lista:     La lista que se va a imprimir
 		 *   titulo:    El nombre de la lista
 		 *	
 		 */	
		public static void ImprimirLista(ListaSoloLectura lista, string t) 
		{
			Console.WriteLine("Opcion: IMPRIMIR "+ t.ToUpper());
			if ( lista.Count() == 0 )
				Console.WriteLine("No hay " + t);
			else
				Console.WriteLine(lista);
		}

		/* Pide una serie de datos al usuario
		 * 
		 * Recibe:
		 *   nombres:   Etiquetas que identifican cada dato, separadas por "\". 
		 *              Seran mostradas al usuario para indicarle que valor ingresar en cada caso.
		 *
		 * Retorna:
		 *   Lista      Lista con los datos ingresados. Se respeta el orden de las etiquetas recibidas.
		 *   null       El usuario decidio cancelar el ingreso de datos. Se descartan los datos ingresados previamente.
		 */
		public static string[] LeerDatos(string nombres)
		{
			string[] split = nombres.Split('/');
			for(int i=0; i<split.Length; i++) {
				if ( ! LeerUnDato(ref split[i], "\n"+split[i]) )
					return null;
			}
			return split;
		}

		/* Pide un dato particular al usuario
		 *
		 * Recibe:
		 *   dato:		 Variable por referencia donde se guardará el dato 
		 *   etiqueta:	 Nombre del dato que se pide al usuario
		 *
		 * Retorna:
		 *   True       El dato fue guardado 
		 *   False		 El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		public static bool LeerUnDato(ref string dato, string etiqueta) 
		{
			Console.Write(etiqueta+": ");
			bool ok = true;
			string nuevo = Console.ReadLine().ToUpper().Trim();
			if( nuevo == "" || nuevo == null )
				ok = Resolver("\n  No se ingreso ningun valor", ref dato);
			if (ok)
				dato = nuevo;
			return ok;
		}

		/* Resuelve una operacion con un ingreso errono de datos
		 *
		 * Recibe:
		 *   mensaje:	 Mensaje de error particular a la operacion a resolver
		 *   dato:	 	 Variable por referencia donde se guardará el nuevo dato
		 *
		 * Retorna
		 *   True       El nuevo valor es valido
		 *   False		 El usuario decidio cancelar el ingreso de datos (posiblemente por no disponer de datos validos)
		 */
		public static bool Resolver(string msg, ref string s){
			Console.WriteLine("\n  "+msg);
			bool ok=false;
			if( Preguntar("\n  ¿Desea intentar con un valor distinto? S/N : ") )
				ok = LeerUnDato(ref s, "\n  Ingrese otro: ");  // NullPointerException
			return ok;
		}

		/* Resuelve una pregunta del tipo SI/NO
		 *
		 * Recibe:
		 *		Pregunta: La pregunta en un string
		 *
		 * Retorna:
		 *		True 		 Si la respuesta es Si('S')
		 *		False		 Si la respuesta es No('N')
		 */
		public static bool Preguntar(string pregunta)
		{
			string rta="";
			while ( rta != "S" & rta != "N" ) {
				Console.Write(pregunta);
				rta = Console.ReadLine().ToUpper();
			}
			return rta=="S";
		}


/*------------------------------  ARCHIVOS --------------------------------------*/

		// Guarda los datos en un archivo de texto y no perderlos al finalizar
		public static void GuardarDatos(Estudio e)
		{
			bool respaldado = false;
			try{
				File.Copy("Datos.txt", "Datos copia.txt");
				respaldado = true;
			} catch(FileNotFoundException) {
				Console.WriteLine("\n No se encontro el archivo Datos.txt, por lo tanto, no se considera necesaria una copia de respaldo");
			} catch {
				Console.WriteLine("\n  No se puede realizar un respaldo del archivo Datos.txt");
				Console.WriteLine("\n  Si desea continuar, ante un potencial fallo, no se podra garantizar la integridad de los datos");
				if ( ! Preguntar("¿ Desea intentar sobreescribir el archivo con los nuevos datos de todos modos ? S/N : ") )
					return;
			}

			try
			{
				StreamWriter sw = new StreamWriter("Datos.txt");
				ListaSoloLectura listaA = e.Abogados;
				ListaSoloLectura listaE = e.Expedientes;

				for (int i = 0; i < listaA.Count(); i++) {
					Abogado a = (Abogado) listaA.Get(i);
					sw.WriteLine(a.Nombre +"/"+ a.Apellido +"/"+ a.Dni +"/"+ a.Espec);
				}
					
			
            	for (int i = 0; i < listaE.Count(); i++) {
					Expediente exp =(Expediente) listaE.Get(i);
					sw.WriteLine(exp.Numero + "/" + exp.Titular.Nombre + "/" + exp.Titular.Apellido + "/" + exp.Titular.Dni + "/" + exp.Tipo+ "/" + exp.Estado);
				}
				
				//Close the file
				sw.Close();
			}
			catch(Exception)
			{
				Console.WriteLine("\n  No se pudo guardar la informacion correctamente");
				if ( respaldado ) {
					try {
						File.Copy("Datos copia.txt", "Datos.txt");
						Console.WriteLine("\n  Se restauro la copia de respaldo");
					} catch {
						Console.WriteLine("\n  No fue posible restaurar la copia de respaldo");
					}
				} else {
					Console.WriteLine("\n  Como no pudo concretarse la copia de respaldo no es posible garantizar la integradad de los datos.");
				}
			}

		}

		public static Estudio cargarDatos(string f)
		{
			Estudio estudio = new Estudio();
			bool err = false;
			StreamReader sr ;		
			try {
			   sr = new StreamReader(f);
			} catch(Exception) {
				err = true;
				Console.WriteLine("No se cargaron los datos porque no se encontro el archivo: " + f);
			    return estudio;
			}

			int c=1;
			string linea;
			while ( (linea = sr.ReadLine()) != null) {
				string[] s = linea.Split('/');
				try {
					if ( s.Length == 7 ) {
						Persona titular = new Persona(s[1], s[2], s[3]);
						estudio.Agregar( new Expediente(s[0],titular,s[4], s[5], DateTime.Today) );
						estudio.Asignar(s[6], s[0]);
					} else if ( s.Length == 4 ) {
						Abogado a = new Abogado(s[0], s[1], s[2], s[3]);
						estudio.Contratar(a);	
					} else { 
						Console.WriteLine("Linea " + c + ": Cantidad de parametros incorrecta");
						err = true;
					}
				} catch(DatoInvalido e) {
					err = true;
					Console.WriteLine("Linea " + c + ": " + e.MSG);
				} catch(FormatException) {
					err = true;
					Console.WriteLine("Linea " + c + ": " + longCast);
				}
				c++;
			}

			sr.Close();		
			if ( err )
				Console.ReadKey();
			Console.Clear();	
			return estudio;
		}
			
	}

}

