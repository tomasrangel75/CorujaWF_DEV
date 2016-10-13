using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Library.Persistencia;
using System.Diagnostics;
using Library.Persistencia_DbCentral.Models;

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

    //public class CheckForFailedTest
    //{

    //    public void ManageDbIni()
    //    {
    //        string avalFullPath = "";

            
    //        if (File.Exists(avalFullPath + "\\DBQUEST"))
    //        {
    //            string localBanco = avalFullPath + "\\DbQuest";

    //            string conn = ConfigurationManager.
    //                 ConnectionStrings["Banco"].ConnectionString;

    //            conn = conn.Replace("#PARAMETRO#", localBanco);

    //            QuestEntities qEntities = new QuestEntities(conn);
    //            var esps = qEntities.Turma.ToList();
    //            var pacs = qEntities.Aluno.ToList();
    //            var qs = qEntities.Questionario.ToList();
    //            var result = (
    //                from e in esps
    //                join p in pacs on e.idTurma equals p.Turma_id
    //                where e.Nome.Equals(esp) && p.Nome.Equals(pac)
    //                select p.idAluno).Count();
    //            var quest = (from q in qs
    //                         where q.Nome.Equals(prova)
    //                         select q.idQuestionario).Count();
    //            if (result == 0 || quest == 0)
    //            {
    //                MessageBox.Show("Arquivo da criança não encontrado, favor iniciar uma nova avaliação", "Coruja Educação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //                int idAva = Convert.ToInt32(idAval);
    //                var av = new Avaliacao();
    //                av.id = idAva;
    //                av.DelAval();
    //                Process.GetCurrentProcess().Kill();
    //            }





    //        }
    //    }
    //}

}
