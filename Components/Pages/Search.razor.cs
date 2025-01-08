using Customer_Information;
using Microsoft.AspNetCore.Components;

namespace CustomerInformation.Components.Pages
{
    public partial class Search
    {
        List<Customer> customers = CustomerCsvDataReader.GetCustomerData();
        List<String> SearchAttribute = [
                "ID",
                "Name",
                "City",
                "Country",
                "Company",
                "Phone",
                "Email"
            ];
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
        }
        private void ReloadData()
        {
            customers = CustomerCsvDataReader.GetCustomerData();

        }
    }
}
