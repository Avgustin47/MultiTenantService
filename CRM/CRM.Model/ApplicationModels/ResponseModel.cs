namespace CRM.Model.ApplicationModels
{
    public class ResponseModel<T>
    {
        public bool IsSucces { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
