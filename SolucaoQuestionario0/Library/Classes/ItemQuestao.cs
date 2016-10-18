using System.IO;
using System.Linq;

namespace Library.Persistencia
{

    public partial class ItemQuestao : ClasseBase
    {
        public static ItemQuestao get(long id)
        {
            return Gerenciador.getContexto().ItemQuestao.Find(id);
        }

        public override bool deletar(object objeto)
        {
            if(Salto.Count > 0)
            {
                Salto.ToList().ForEach(i => i.deletar(i));
            }

            if(ItemArquivo.Count > 0)
            {
                ItemArquivo.ToList().ForEach(i => i.deletar(i));
            }

            return base.deletar(this);
        }

        public bool apagarImagem()
        {
            ItemArquivo itemTeste = ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.imagem);

            if (itemTeste != null)
            {

                itemTeste.deletar(itemTeste);

                ContemImagem = false;
                atualizar(this);
            }
            else
            {
                ContemImagem = false;
                atualizar(this);
            }

            return true;
        }

        public bool apagarAudio()
        {
            ItemArquivo itemTeste = ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audio);

            if (itemTeste != null)
            {

                itemTeste.deletar(itemTeste);

                ContemAudio = false;
                atualizar(this);
            }
            else
            {
                ContemAudio = false;
                atualizar(this);
            }

            return true;
        }

        public bool apagarAudioLeitura()
        {
            ItemArquivo itemTeste = ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.audioLeitura);

            if (itemTeste != null)
            {

                itemTeste.deletar(itemTeste);

                ContemAudio = false;
                atualizar(this);
            }
            else
            {
                ContemAudio = false;
                atualizar(this);
            }

            return true;
        }

        public Arquivo criarImagem(string caminhoArquivo)
        {
            Arquivo arquivoImagem = null;
            string nome = caminhoArquivo;

            FileInfo info = new FileInfo(nome);

            if (info.Exists)
            {
                // Verifica se ja existe para atualizar
                ItemArquivo itemTeste = ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == TipoArquivo.imagem);


                string nomeArquivo = info.Name;
                // Trata tamanho do nome
                if (nomeArquivo.Length > 200)
                {
                    nomeArquivo = nomeArquivo.Remove(200);
                }

                if (itemTeste == null)
                {
                    Arquivo arquivo = new Arquivo
                    {
                        Nome = nomeArquivo,
                        NomeFisico = "Imagem" + idItemQuestao + info.Extension,
                        Extensao = info.Extension,
                        TipoArquivo = TipoArquivo.imagem
                    };

                    arquivo.adicionar(arquivo);

                    var itemArquivo = new ItemArquivo();
                    itemArquivo.ItemQuestao = this;
                    itemArquivo.Arquivo = arquivo;

                    itemArquivo.adicionar(itemArquivo);

                    arquivoImagem = arquivo;
                }
                else
                {
                    Arquivo arquivoExistente = itemTeste.Arquivo;

                    // Apaga o arquivo antigo da pasta
                    string caminhoAnterior = Questao.Diretorio + arquivoExistente.NomeFisico;
                    File.Delete(caminhoAnterior);

                    // Atualiza as informações do novo
                    arquivoExistente.Nome = nomeArquivo;
                    arquivoExistente.NomeFisico = "Imagem" + idItemQuestao + info.Extension;
                    arquivoExistente.Extensao = info.Extension;

                    arquivoExistente.atualizar(arquivoExistente);

                    arquivoImagem = arquivoExistente;
                }

                ContemImagem = true;
                atualizar(this);

                string caminhoFisico = Questao.Diretorio + "\\" + arquivoImagem.NomeFisico;

                File.Copy(caminhoArquivo, caminhoFisico, true);
            }

            return arquivoImagem;
        }

        public Arquivo criarAudio(string caminhoArquivo)
        {
            return criarAudio(caminhoArquivo, TipoArquivo.audio);
        }

        public Arquivo criarAudio(string caminhoArquivo, TipoArquivo tipo)
        {
            Arquivo arquivoAudio = null;
            string nome = caminhoArquivo;

            var info = new FileInfo(nome);

            string nomeArquivo = info.Name;
            // Trata tamanho do nome
            if (nomeArquivo.Length > 200)
            {
                nomeArquivo = nomeArquivo.Remove(200);
            }

            if (info.Exists)
            {
                // Verifica se ja existe para atualizar
                ItemArquivo itemTeste = ItemArquivo.ToList().Find(i => i.Arquivo.TipoArquivo == tipo);

                if (itemTeste == null)
                {
                    var arquivo = new Arquivo();
                    arquivo.Nome = nomeArquivo;
                    arquivo.NomeFisico = tipo.Nome + idItemQuestao + info.Extension;
                    arquivo.Extensao = info.Extension;
                    arquivo.TipoArquivo = tipo;

                    arquivo.adicionar(arquivo);

                    var itemArquivo = new ItemArquivo {ItemQuestao = this, Arquivo = arquivo};

                    itemArquivo.adicionar(itemArquivo);

                    arquivoAudio = arquivo;
                }
                else
                {
                    Arquivo arquivoExistente = itemTeste.Arquivo;

                    // Apaga o arquivo antigo da pasta
                    string caminhoAnterior = Questao.Diretorio + arquivoExistente.NomeFisico;
                    File.Delete(caminhoAnterior);

                    // Atualiza as informações do novo
                    arquivoExistente.Nome = nomeArquivo;
                    arquivoExistente.NomeFisico = tipo.Nome + idItemQuestao + info.Extension;
                    arquivoExistente.Extensao = info.Extension;

                    arquivoExistente.atualizar(arquivoExistente);

                    arquivoAudio = arquivoExistente;
                }

                ContemAudio = true;
                atualizar(this);

                string caminhoFisico = Questao.Diretorio + "\\" + arquivoAudio.NomeFisico;

                File.Copy(caminhoArquivo, caminhoFisico, true);
            }

            return arquivoAudio;
        }
    }
}
