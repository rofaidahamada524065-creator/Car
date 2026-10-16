using AutoMapper;
using Car.DTOs.Catigory;
using Car.DTOs.Customer;
using Car.DTOs.Employee;
using Car.DTOs.Sale;
using Car.DTOs.Vehicles;
using Car.Model;

namespace Car.Mapping
{
    public class AllProfail:Profile
    {
        public AllProfail()
        {
            CreateMap<Vehicle, Vehicle_DTO>().ReverseMap();
            CreateMap<Vehicle, CreateUpdateVehicle_DTO>().ReverseMap();

            CreateMap<Category, CreateUpdateCatigoryDTO>().ReverseMap();
            CreateMap<Category, CatigoryDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCreateCustomerDTO>().ReverseMap();

            CreateMap<Employee, EmpeloyeeDTO>().ReverseMap();
            CreateMap<Employee, CreateUpdateEmpellyDTO>().ReverseMap();

            CreateMap<Sale, SaleDTO>().ReverseMap();
            CreateMap<Sale, CreateUpdatSaleDTO>().ReverseMap();
        }
    }
}
