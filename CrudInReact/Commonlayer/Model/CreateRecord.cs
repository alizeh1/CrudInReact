namespace CrudInReact.Commonlayer.Model
{
    public class CreateRecordRequest 
    {
        public string Username { get; set; }
        public int Age { get; set; }
    }

    public class CreateRecordresponse
    {
     public bool IsSuccess { get; set; }
     public string Message { get; set; }
    }
}
