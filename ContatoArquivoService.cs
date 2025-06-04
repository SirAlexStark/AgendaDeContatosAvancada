using AgendaDeContatosAvancada.Models;

namespace AgendaDeContatosAvancada.Services
{
    public class ContatoArquivoService
    {
        private string caminhoArquivo = "contatos.txt"; // Caminho do arquivo de contatos

        // Salva a lista de contatos no arquivo
        public void Salvar(List<Contato> contatos)
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                foreach (var contato in contatos)
                {
                    // Escreve os dados separados por '|'
                    sw.WriteLine($"{contato.Id}|{contato.Nome}|{contato.Telefone}|{contato.Email}");
                }
            }
        }

        // Carrega a lista de contatos do arquivo e retorna o maior ID
        public List<Contato> Carregar(out int maiorId)
        {
            var contatos = new List<Contato>();
            maiorId = 0; // Inicializa o maior ID como 0

            // Se o arquivo não existir, retorna uma lista vazia
            if (!File.Exists(caminhoArquivo))
                return contatos;

            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    var dados = linha.Split('|'); // Divide a linha pelos separadores '|'
                    if (dados.Length == 4 && int.TryParse(dados[0], out int id))
                    {
                        // Cria um novo contato com os dados lidos
                        var contato = new Contato
                        {
                            Id = id,
                            Nome = dados[1],
                            Telefone = dados[2],
                            Email = dados[3],
                        };
                        contatos.Add(contato);
                        if (id > maiorId)
                        {
                            maiorId = id; // Atualiza o maior ID se necessário
                        }
                    }
                }
            }
            return contatos; // Retorna a lista de contatos carregada
        }
    }
}