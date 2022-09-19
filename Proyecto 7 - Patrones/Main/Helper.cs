using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Main
{
    public class Helper
    {
        public static string GetTypeName<T>(T e)
        {
            string nombre = e!.GetType().Name;
            return nombre.Substring(0, nombre.Length - 2);
        }
    }
}
