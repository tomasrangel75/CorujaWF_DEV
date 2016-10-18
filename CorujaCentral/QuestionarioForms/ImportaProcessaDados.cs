using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionarioForms
{
    public partial class ImportaProcessaDados : MetroForm
    {
        public ImportaProcessaDados()
        {
            InitializeComponent();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Equals(""))
            {
                MessageBox.Show("Preencher endereço do folder");
                return;
            }

            string fld = txtPath.Text;
            string[] files = Directory.GetFiles(fld);
            int counter = 0;


            Console.WriteLine("INICIO /////////////////////////////////////////////////////////////////////////////////////////////////");


            using (SQLiteConnection cn = new SQLiteConnection(@"Data Source= C:\GeradorQuestionario\Banco\DBQUEST;Version=3;"))
            {
                cn.Open();


                foreach (string file in files)
                {

                    counter = counter + 1;
                    try
                    {
                        string myFl = Path.GetFileName(file);
                        string pt = fld + @"\" + myFl;
                        string stringConn = @"Data Source=" + pt + ";Version=3;";
                        using (SQLiteConnection cnProvider = new SQLiteConnection(stringConn))
                        {
                            cnProvider.Open();

                            #region ALUNO

                            //Aluno /////////////////////////////////////////////////////////////////////////
                            SQLiteCommand cmd = new SQLiteCommand();
                            cmd.Connection = cnProvider;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"Select " + counter + @" as idAluno, 
                                                Nome, 
                                                Turma_id, 
                                                Sexo 
                                              from 
                                                Aluno";
                            string sql = "";


                            using (SQLiteDataReader r = cmd.ExecuteReader())
                            {

                                while (r.Read())
                                {

                                    sql = @"Insert into Aluno (idAluno,Nome,Turma_id,Sexo) values (" +
                                            r["idAluno"] + ",'"
                                            + r["Nome"] + "',"
                                            + r["Turma_id"] + ",'"
                                            + r["Sexo"] + "')";


                                    ExecMainDb(cn, myFl + " Aluno ", sql);

                                }

                            }


                            #endregion

                            #region PONTUACAO

                            //PONTUACAO //////////////////////////////////////////////////////////////////////////////
                            SQLiteCommand cmdRes = new SQLiteCommand();
                            cmd.Connection = cnProvider;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"Select " + counter + @" as idAluno,
                                                Questao_id,
                                                 CASE Acertou WHEN Acertou = 'False' THEN
                                                        0
                                                    ELSE
                                                        1
                                                    END
                                                 as Acertou,
                                                Tentativas
                                             from
                                                Pontuacao";

                            using (SQLiteDataReader rRes
                            = cmd.ExecuteReader())
                            {
                                while (rRes.Read())
                                {
                                    sql = @"Insert into Pontuacao (Aluno_id,Questao_id,Acertou,Tentativas) values (" +
                                            rRes["idAluno"] + "," +
                                            rRes["Questao_id"] + "," +
                                            rRes["Acertou"] + "," +
                                            rRes["Tentativas"] + ")";

                                    ExecMainDb(cn, myFl + " Pontuacao ", sql);

                                }
                            }

                            #endregion

                            #region RESULTADO

                            //Resultado
                            SQLiteCommand cmdPont = new SQLiteCommand();
                            cmd.Connection = cnProvider;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"Select " + counter + @" as idAluno,
                                                Questionario_id,
                                                TotalAcertos,
                                                TotalErros
                                             from
                                                Resultado";

                            using (SQLiteDataReader rPont
                            = cmd.ExecuteReader())
                            {
                                while (rPont.Read())
                                {

                                    sql = @"Insert into Resultado (Aluno_id,Questionario_id,TotalAcertos,TotalErros) values (" +
                                            rPont["idAluno"] + "," +
                                            rPont["Questionario_id"] + "," +
                                            rPont["TotalAcertos"] + "," +
                                            rPont["TotalErros"] + ")";

                                    ExecMainDb(cn, myFl + " Resultado ", sql);

                                }

                            }

                            #endregion

                            Console.WriteLine("++++++++++++++++++++++++   " + counter);

                            cnProvider.Close();
                            lblCont.Text = counter.ToString();
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("******************************************************");
                        Console.WriteLine(file + " " + exc.Message.ToString());
                        Console.WriteLine("******************************************************");
                    }


                }

            }
            Console.WriteLine("FIM /////////////////////////////////////////////////////////////////////////////////////////////////");
            return;
        }


        public int ExecMainDb(SQLiteConnection cn, string fileRef, string Sql)
        {

            try
            {
                SQLiteCommand command = new SQLiteCommand(Sql, cn);
                command.ExecuteNonQuery();
                Console.WriteLine(fileRef + " => Done");

                command = null;
                return 0;

            }
            catch (Exception exc)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine(fileRef + " " + exc.Message.ToString());
                Console.WriteLine("******************************************************");
                return 1;
            }

        }
    }
}
