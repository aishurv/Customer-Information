using Customer_Information;
using Microsoft.AspNetCore.Components;

namespace CustomerInformation.Components.Pages
{
    public partial class Search
    {
        List<Customer> customers = CustomerRepository.GetCustomerData();
        List<String> SearchAttribute = Queries.ValidSearchAttributes;
        List<String> DistinctValues = new(){
    "Select Attribute"
    };
        string SelectedSearchAttribute = string.Empty;
        string SelectedAttributevalue = string.Empty;
        private void OnSearchAttributeSelected(ChangeEventArgs e)
        {
            SelectedSearchAttribute = e.Value?.ToString() ?? Queries.ValidSearchAttributes[0]!;

            if (SelectedSearchAttribute != null)
                DistinctValues = Queries.getDistinctValues(customers, SelectedSearchAttribute);
        }
        private void OnValueSelected(ChangeEventArgs e)
        {
            SelectedAttributevalue = e.Value?.ToString() ?? DistinctValues[0]!;

            if (SelectedAttributevalue != null)
                customers = Queries.Find(customers, SelectedSearchAttribute, SelectedAttributevalue);
        }
        private void ReloadData()
        {
            customers = CustomerRepository.GetCustomerData();

        }
    }
}
