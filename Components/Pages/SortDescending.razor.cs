using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomerInformation.Components.Pages
{
    public partial class SortDescending
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
        string SelectedSortAttribute = string.Empty;
        List<String> ValidSort = [
                "ID",
                "Name",
                "City",
                "Country",
                "Company",
                "Phone",
                "Email"
            ];

        private void OnSortAttributeSelected(ChangeEventArgs e)
        {
            SelectedSortAttribute = e.Value?.ToString() ?? ValidSort[0]!;
            customers = SortCustomersDesc(SelectedSortAttribute);
        }
        private void ReloadData()
        {
            customers = CustomerCsvHandler.GetCustomerData();

        }
#nullable disable
        List<Customer> SortCustomersDesc(string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            return customers.OrderByDescending(c => property.GetValue(c, null)).ToList();
        }
        private void UpdateCsvFile()
        {
            if (CustomerCsvHandler.UpdateCsv(customers))
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File updated Successfully !");
            }
            else
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File Not Updated !");
            }
        }
    }
}
