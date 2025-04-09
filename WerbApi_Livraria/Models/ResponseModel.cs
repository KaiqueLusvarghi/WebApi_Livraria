namespace WerbApi_Livraria.Models
{
    public class ResponseModel<T> //tipo generico que vai atender Livros e Autores
    {
        public T? Dados { get; set; } //Tipo generico 
        public string Mensagem {  get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
