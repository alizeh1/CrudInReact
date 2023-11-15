using CrudInReact.Commonlayer.Model;
using System.Threading.Tasks;

namespace CrudInReact.ServiceLayer
{
    public interface ICrudOperationSL
    {
        //method declaration
        public Task<CreateRecordresponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdaterecordResponse> UpdateRecord(UpdateRecordRequest request);

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
