using System;
using System.IO;
namespace Escribir
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
			File.Copy("Expedientes.txt", "Expedientes2.txt");

            try
            {
                //Pasa la ruta del archivo
                StreamWriter sw = new StreamWriter("C:\\Test.txt");
			    ListaSoloLectura e = Estudio.Expedientes;

			        for (int i = 0; i < e.Count; i++)
			        {
                        //Esribe una linea de texto (numExp/Titular.Nombre/Titular.Apellido/Titular.DNI/tipo/estado)
                        sw.WriteLine(e[i].Numero/e[i].Titular.Nombre/e[i].Titular.Apellido/e[i].Titular.Dni/e[i].Tipo/e[i].Estado);
			        }
                //Close the file
                sw.Close();
            }
            catch(Exception e)
            {

            }

        }
    }
}