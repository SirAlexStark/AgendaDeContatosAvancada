namespace AgendaDeContatosAvancada.Models
{
    //Classe que representa um contato na agenda de contatos avançada
    public class Contato
    {
        public int Id { get; set; } // Identificador único do contato
        public string Nome { get; set; } // Nome do contato
        public string Telefone { get; set; } // Número de telefone do contato
        public string Email { get; set; } // Endereço de e-mail do contato
    }
}
