using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using loginWhitSql.PL;
using loginWhitSql.PL_presentacion__; 


namespace loginWhitSql
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.E66
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            Application.Run(new FormInicio());

        }
    }
}
