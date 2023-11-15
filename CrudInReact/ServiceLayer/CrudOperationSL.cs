using CrudInReact.Commonlayer.Model;
using CrudInReact.Repositorylayer;
using System.Threading.Tasks;

namespace CrudInReact.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {
        //call repository layer in service layer implement dependency injection
        public readonly ICrudOperationRL _crudOperationRL;

        //constuctor dependency injection
        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL= crudOperationRL;
        }

        public async Task<CreateRecordresponse> CreateRecord(CreateRecordRequest request)
        {
           return await _crudOperationRL.CreateRecord(request);
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudOperationRL.ReadRecord();
        }

        public async Task<UpdaterecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateRecord(request);
        }
    }
}
