using Transaction.DTO;
using Transaction.Entities;
using Transaction.Implementation.Repositories;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;
using Transaction.RequestModel;
using Transaction.ResponseModel;
namespace Transaction.Implementation.Services;
public class SalesRepService : ISalesRepService
{
        private readonly ISalesRepRepository _salesrepRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOpeningStockRepository _openingStockRepository;

    public SalesRepService(ISalesRepRepository salesrepRepository, IProductRepository productRepository, IOpeningStockRepository openingStockRepository)
    {
        _salesrepRepository = salesrepRepository;
        _productRepository = productRepository;
        _openingStockRepository = openingStockRepository;
    }

    public BaseResponse AddSalesRep(SalesRepRequestModel salesRepRequestModel)
        {
            SalesRep salesRep = new SalesRep
            {
                FirstName = salesRepRequestModel.FirstName,
                LastName = salesRepRequestModel.LastName,
                Email = salesRepRequestModel.Email,
                Password = salesRepRequestModel.Password
            };
            bool c = _salesrepRepository.IfExit(salesRep);
            if (c == true)
            {
                _salesrepRepository.AddSalesRep(salesRep);
                return new BaseResponse
                {
                    Message = "Sucessfully added",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Already exits",
                Status = false
            };

        }
        public BaseResponse DeleteSalesRep(int id)
        {
            var c = _salesrepRepository.DeleteSalesRep(id);
            if (c == null)
            {
                return new BaseResponse
                {
                    Message = "Sales Rep not found",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }
        public BaseResponse UpdateSalesRep(int id, SalesRepRequestModel salesRepRequestModel)
        {
            var salesRep = _salesrepRepository.GetSalesRepById(id);

            if (salesRep == null)
            {
                return new BaseResponse
                {
                    Message = "Sales Rep not found",
                    Status = false
                };
            }
            salesRep.FirstName = salesRepRequestModel.FirstName;
            salesRep.LastName = salesRepRequestModel.LastName;
            salesRep.Email = salesRepRequestModel.Email;
            salesRep.Password = salesRepRequestModel.Password;
            var c = _salesrepRepository.UpdateSalesRep(salesRep);
            return new BaseResponse
            {
                Message = "Sucessfully returned",
                Status = true
            };
        }
        public SalesRepResponse GetSalesRepById(int id)
        {
            var salesRep = _salesrepRepository.GetSalesRepById(id);
            if (salesRep == null)
            {
                return new SalesRepResponse
                {
                    Message = "Salesrep not found",
                    Status = false
                };
            }
            return new SalesRepResponse
            {
                Data = new SalesRepDTO
                {
                    Id = salesRep.Id,
                    FirstName = salesRep.FirstName,
                    LastName = salesRep.LastName,
                    Email = salesRep.Email
                },
                Message = "Sucessfully done.",
                Status = false
            };
        }
        public SalesRepsResponseModel GetAllSalesResponse()
        {

            var salesRep = _salesrepRepository.GetAllSalesRep();
            if(salesRep == null)
            {
                return new SalesRepsResponseModel
                {
                    Status = false,
                    Message = "No Sales Representative retrieved"

                };
            }

            var salesRepReturned = salesRep.Select(sr => new SalesRepDTO
                {
                    Id = sr.Id,
                    FirstName = sr.FirstName,
                    LastName = sr.LastName,
                    Email = sr.Email
                }).ToList();

            return new SalesRepsResponseModel
            {
                Data = salesRepReturned,
                Message = "",
                Status = true
            };

            
            // List<SalesRepDTO> salesRepDTOs = new List<SalesRepDTO>();
            // var salesReps = _salesrepRepository.GetAllSalesRep();
            // SalesRepsResponseModel salesRepsResponseModel =  new SalesRepsResponseModel();
            // foreach (var item in salesReps)
            // {
            //     SalesRepDTO salesRepDTO  = new SalesRepDTO();
            //     salesRepDTO.Id = item.Id;
            //     salesRepDTO.FirstName = item.FirstName;
            //     salesRepDTO.LastName = item.LastName;
            //     salesRepDTO.Email = item.Email;
            //     salesRepDTOs.Add(salesRepDTO);
            // }
            // foreach (var item in salesRepDTOs)
            // {
            //     salesRepsResponseModel.Data.Add(item);
            // }
            // return salesRepsResponseModel;
        }
        
}