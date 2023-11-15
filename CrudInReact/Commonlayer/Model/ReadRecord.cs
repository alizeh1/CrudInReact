using System.Collections.Generic;

namespace CrudInReact.Commonlayer.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<ReadRecordData> readRecordData { get; set; }
    }
    public class ReadRecordData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
    }
}
