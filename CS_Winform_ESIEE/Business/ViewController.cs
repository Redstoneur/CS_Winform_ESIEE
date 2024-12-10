using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Winform_ESIEE.Vue;

namespace CS_Winform_ESIEE.Business
{
    internal static class ViewController
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
