namespace API_CRUD_FUNCIONARIOS.Models
{
    public class Response<T>
    {
        public  List<T> DADOS { get; set; }
        public  bool STATUS { get; set; }
    }
}
