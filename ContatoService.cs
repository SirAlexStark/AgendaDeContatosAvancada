using AgendaDeContatosAvancada.Models;

namespace AgendaDeContatosAvancada.Services
{
    public class ContatoService
    {
        private List<Contato> contatos = new List<Contato>();
        private int proximoId = 1; // Variável para gerar IDs únicos   

        // Retorna todos os contatos da Lista
        public List<Contato> ObterTodos()
        {
            return contatos;
        }

        public void AdicionarContato(Contato contato)
        {
            contato.Id = proximoId++; // Atribui um ID único ao contato
            contatos.Add(contato); // Adiciona o contato à lista
        }

        public void DefinirProximoId(int maiorId)
        {
            proximoId = maiorId + 1; // Define o próximo ID com base no maior ID existente
        }
    }


}
