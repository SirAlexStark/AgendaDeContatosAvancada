using AgendaDeContatosAvancada.Models;
using AgendaDeContatosAvancada.Services;

class Program
{
    static void Main(string[] args)
    {
        // Instancias de serviços
        var contatoService = new ContatoService();
        var arquivoService = new ContatoArquivoService();

        // Carrega os contatos do arquivo e obtém o maior ID
        var contatos = arquivoService.Carregar(out int maiorId);
        contatoService.DefinirProximoId(maiorId); // Define o próximo ID com base no maior ID existente

        // Adiciona os contatos carregados à memória
        foreach (var contato in contatos)
        {
            contatoService.AdicionarContato(contato);
        }

        // Interface de usuário simples

        Console.WriteLine("---- Agenda de Contatos ----");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        // Cria um novo contato

        var novoContato = new Contato
        {
            Nome = nome,
            Telefone = telefone,
            Email = email
        };

        // Adiciona o contato a lista e salva no arquivo
        contatoService.AdicionarContato(novoContato);
        arquivoService.Salvar(contatoService.ObterTodos());


        Console.WriteLine("Contato adicionado com sucesso!");
    }

}