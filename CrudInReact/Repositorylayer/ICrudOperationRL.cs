using CrudInReact.Commonlayer.Model;
using System.Threading.Tasks;

namespace CrudInReact.Repositorylayer
{
    public interface ICrudOperationRL
    {
        public Task<CreateRecordresponse> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdaterecordResponse> UpdateRecord(UpdateRecordRequest request);

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
