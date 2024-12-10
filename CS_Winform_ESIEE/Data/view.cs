using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Winform_ESIEE.Vue;

namespace CS_Winform_ESIEE.Data
{
    internal static class view
    {
        public static GestionStock gs;
        public static GestionReapproMixed grm;
        public static GestionStock init()
        {
            gs = new GestionStock();
            grm = new GestionReapproMixed();
            return gs;
        }
    }
}
