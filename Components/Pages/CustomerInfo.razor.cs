﻿
using CustomerInformation.Helper;
using CustomerInformation.Model;

namespace CustomerInformation.Components.Pages
{
    public partial class CustomerInfo
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
        
    }
}
