using Customer_Information;
using Microsoft.AspNetCore.Components;

namespace CustomerInformation.Components.Pages
{
    public partial class SortAscending
    {
        List<Customer> customers = CustomerRepository.GetCustomerData();
        string SelectedSortAttribute = string.Empty;
        List<String> ValidSort = Queries.ValidSortAttributes;

        private void OnSortAttributeSelected(ChangeEventArgs e)
        {
            bool order = true;
            SelectedSortAttribute = e.Value?.ToString() ?? Queries.ValidSortAttributes[0]!;
            customers = Queries.SortCustomers(customers, SelectedSortAttribute, order);
        }
        private void ReloadData()
        {
            customers = CustomerRepository.GetCustomerData();

        }
    }
}
