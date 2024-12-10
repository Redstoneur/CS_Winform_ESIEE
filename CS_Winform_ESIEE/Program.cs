using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS_Winform_ESIEE.Business;
using CS_Winform_ESIEE.Data;
using CS_Winform_ESIEE.Modele;
using CS_Winform_ESIEE.Vue;

namespace CS_Winform_ESIEE
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "dev")
            {
                TestDatabase();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Vue.View.init());
            Vue.View.gestionreappromixed.Hide();
        }

        static void TestDatabase()
        {
            try
            {
                var articleController = new ArticleController();
                var articles = articleController.GetAllArticles();
                Console.WriteLine(@"Articles in database:");
                foreach (var article in articles)
                {
                    Console.WriteLine($@"Id: {article.IdArticle}, Name: {article.Nom}, Price: {article.PrixUnitaire}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"Database test failed: {ex.Message}");
            }
        }
    }
}