﻿namespace CrudInReact.Commonlayer.Model
{
    public class UpdateRecordRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
    }

    public class UpdaterecordResponse
    {
        public bool IsSuccess { get; set; } 
        public string Message { get; set; }
    }
}
