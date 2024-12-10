using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Winform_ESIEE.Vue;

namespace CS_Winform_ESIEE.Vue
{
    internal static class View
    {
        public static GestionStock gestionstock;
        public static GestionReapproMixed gestionreappromixed;
        public static GestionStock init()
        {
            gestionstock = new GestionStock();
            gestionreappromixed = new GestionReapproMixed();
            return gestionstock;
        }
    }
}
