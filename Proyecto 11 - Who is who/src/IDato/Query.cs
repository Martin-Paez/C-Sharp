using System;
using System.Collections.Generic;
using WiW.src.Clasificador;

namespace WiW.src.IDato
{
    public class Query : IData
    {
        private string Phrase { get; }
        private string Reply { get; set; }

        public Query(string feature, string txt)
        {
            Reply = feature;
            if (txt.StartsWith("¿{0}"))
            {
                txt = txt.Substring(5);
                Phrase = "¿" + char.ToUpper(txt[0]) + txt.Substring(1);
            }
            else
                Phrase = string.Format(txt, Reply);
        }
        public bool answer(string txt)
        {
            if (Reply == "no")
                return txt.Equals("si");
            return txt.Equals(Reply);
        }
        public override string ToString()
        {
            return Phrase;
        }
    }
}
