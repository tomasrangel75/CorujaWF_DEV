using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Persistencia;

namespace QuestionarioForms
{
    public class ItemRelatorioAluno
    {
        public enum corRelatorio
        {
            branco = -1,
            vermelho = 0,
            amarelo = 1,
            verde = 2,
            azul = 3
        }

        public Aluno aluno;

        public int corAluno;

        public List<int> vetCorEixo;

        public static ItemRelatorioAluno.corRelatorio convertCorRelatorioFromColor(Color color)
        {
            if (color == Color.Red)
            {
                return corRelatorio.vermelho;
            }
            else if (color == Color.Yellow)
            {
                return corRelatorio.amarelo;
            }
            else if (color == Color.Green)
            {
                return corRelatorio.verde;
            }
            else if (color == Color.Blue)
            {
                return corRelatorio.azul;
            }
            else
            {
                return corRelatorio.branco;
            }
        }

        public static Color convertColorRelatorioFromCor(int corInt)
        {
            corRelatorio cor = (corRelatorio)Enum.Parse(typeof (corRelatorio), corInt.ToString());

            if (cor == corRelatorio.azul)
            {
                return Color.LightSkyBlue;
            }
            else if (cor == corRelatorio.vermelho)
            {
                return Color.IndianRed;
            }
            else if (cor == corRelatorio.amarelo)
            {
                return Color.Khaki;
            }
            else if (cor == corRelatorio.verde)
            {
                return Color.LightGreen;
            }
            else
            {
                return Color.White;
            }
        }


    }
}
