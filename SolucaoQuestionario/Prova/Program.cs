﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Prova
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProvaAluno prova = new ProvaAluno();
   
            if (ConfigurationManager.AppSettings["escolheu"] != "0")
            {
                Application.Run(prova);
   
            }
        }
    }
}
