namespace CustomerInformation.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllEmployees();
        Task<Customer> GetEmployeeById(string id);
        Task<Customer> AddEmployee(Customer customer);
        Task<Customer> UpdateEmployee(Customer customer);
        Task DeleteEmployee(string id);
    }
}
