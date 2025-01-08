using Microsoft.AspNetCore.Components;
using Serilog;

namespace CustomerInformation.Components.Pages
{
    public partial class Search
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
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
            SelectedSearchAttribute = e.Value?.ToString() ?? SearchAttribute[0]!;

            if (SelectedSearchAttribute != null)
                DistinctValues = getDistinctValues( SelectedSearchAttribute);
        }
        private void OnValueSelected(ChangeEventArgs e)
        {
            SelectedAttributevalue = e.Value?.ToString() ?? DistinctValues[0]!;
            customers = SearchCustomer(SelectedSearchAttribute, SelectedAttributevalue);

        }
        private void ReloadData()
        {
            customers = CustomerCsvHandler.GetCustomerData();

        }
        List<Customer> SearchCustomer(string attributeName, string attributeValue)
        {
            Log.Information($"Find {attributeValue} of {attributeName}");
#nullable disable
            var property = typeof(Customer).GetProperty(attributeName);

            var matchedCustomers = customers.Where(c =>
            {
                var value = property.GetValue(c)?.ToString();
                return value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
            }).ToList();
            return matchedCustomers;
        }
        List<string> getDistinctValues (string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);

            return customers
                .Select(item => property.GetValue(item, null)?.ToString()) // Get property value and convert to string 
                .Distinct() // Get distinct values
                .ToList(); // Convert to list
        }
    }
}
