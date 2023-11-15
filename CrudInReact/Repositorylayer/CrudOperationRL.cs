using CrudInReact.Commonlayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CrudInReact.Repositorylayer
{
    public class CrudOperationRL : ICrudOperationRL
    {

        //dependency injection in repository to call appsetting
        public readonly IConfiguration _configuration;

        //use sql connection package
        public readonly SqlConnection _sqlConnection;
         public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection =new SqlConnection (_configuration[key: "ConnectionStrings:DefaultConnection"]);
        }
        public async Task<CreateRecordresponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordresponse response=new CreateRecordresponse();     //memory allocation
            response.IsSuccess= true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Insert into tblUser(UserName,Age) values(@UserName,@Age)";
                using(SqlCommand sqlCommand=new SqlCommand(SqlQuery,_sqlConnection))
                {
                   sqlCommand.CommandType=System.Data.CommandType.Text;    //when we pass storeprocedure then text replace with storeprocedure
                    sqlCommand.CommandTimeout=180;
                    sqlCommand.Parameters.AddWithValue(parameterName:"@UserName",request.Username);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    _sqlConnection.Open();
                    //how to execute query
                    int status=await sqlCommand.ExecuteNonQueryAsync();
                    if (status<=0)
                    {
                        response.IsSuccess=false;
                        response.Message = "Something went wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess= false;
                response.Message= ex.Message;
            }
            finally { 
                _sqlConnection.Close(); 
            }
            return response;
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "delete from tblUser where Id=@Id";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    //how to execute query
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;


            }
            finally { _sqlConnection.Close(); }
            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response =new ReadRecordResponse();
            response.IsSuccess= true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Select * from tbluser";
                using(SqlCommand sqlCommand=new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType= System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using(SqlDataReader sqlDataReader=await sqlCommand.ExecuteReaderAsync())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            response.readRecordData =new List<ReadRecordData>();
                            while(await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData=new ReadRecordData();
                                dbData.Id = sqlDataReader[name: "Id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Id"]):0;
                                dbData.Username = sqlDataReader[name: "UserName"] != DBNull.Value ? sqlDataReader[name: "UserName"].ToString():string.Empty ;
                                dbData.Age = sqlDataReader[name: "Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "Age"]):0;
                                response.readRecordData.Add(dbData);
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally { 
                _sqlConnection.Close(); 
            }
            return response;
        }

        public async Task<UpdaterecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
           UpdaterecordResponse response = new UpdaterecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Update tblUser set UserName=@Username,Age=@Age where Id=@Id";
                using(SqlCommand sqlCommand=new SqlCommand(SqlQuery,_sqlConnection))
                {
                    sqlCommand.CommandType=System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName:"@UserName",request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    //how to execute query
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }

                }
            }catch(Exception ex) { 
             response.IsSuccess = false;
            response.Message = ex.Message;
            

            }finally { _sqlConnection.Close(); }
            return response;
        }
    }
}
