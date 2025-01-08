using Customer_Information;
using Microsoft.AspNetCore.Components;

namespace CustomerInformation.Components.Pages
{
    public partial class CustomerInfo
    {
        List<Customer> customers = CustomerRepository.GetCustomerData();
        
    }
}
