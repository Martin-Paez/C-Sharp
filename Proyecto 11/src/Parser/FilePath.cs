using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiW
{
    internal class FilePath
    {
        public static string patron;
        public static string patron_imgs = "\\imgs\\{0}.png";
        public static string file_preguntas = "\\preguntas.csv";

       
        public static int w = 100;
        public static int h = 145;

        public static void init_patron()
        {
            patron = System.IO.Directory.GetCurrentDirectory();
            DirectoryInfo? d = System.IO.Directory.GetParent(patron);
            d = d.Parent!.Parent;
            patron = d.FullName + "\\datasets";  

        }

        public static string get_path_img(string nombre) 
        {
            if (patron == null)
                init_patron();
            return (patron + String.Format(FilePath.patron_imgs, nombre));
        }

        public static string Path()
        {
            if (patron == null)
                init_patron();
            return patron + file_preguntas;
        }

        public static void set_patron(string patron_parm)
        {
            patron = patron_parm;
        }

    }
}
