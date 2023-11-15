using CrudInReact.Commonlayer.Model;
using CrudInReact.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudInReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationAPIController : ControllerBase
    {
        //Implement Dependency injection 
        public readonly ICrudOperationSL _crudOperationSL;

        //Define constructor
        public CrudOperationAPIController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL= crudOperationSL;
        }

         //which post api we call route can help you or route defferentiate two api
        [HttpPost]
        [Route(template: "Createrecord")]
        public async Task<IActionResult> Createrecord(CreateRecordRequest request)
        {
            CreateRecordresponse recordresponse = null;
            try
            {
                recordresponse = await _crudOperationSL.CreateRecord(request);
            }
            catch (Exception ex) { 
                recordresponse.IsSuccess= false;
                recordresponse.Message= ex.Message;
            }
            return Ok(recordresponse);

        }

        

        [HttpGet]
        [Route("ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.ReadRecord();
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateRecord")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
           UpdaterecordResponse response = null;
            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.DeleteRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
