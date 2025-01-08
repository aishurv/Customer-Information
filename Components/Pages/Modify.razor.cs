using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomerInformation.Components.Pages
{
    public partial class Modify
    {
        List<Customer> customers = CustomerCsvHandler.GetCustomerData();
        public void EditCustomer(string id)
        {
            //JSRuntime.InvokevoidAsync("showAlert", $"Edit Customer having ID {id}");
        }
        private async Task DeleteCustomer(string id)
        {
            // Await the result of the confirmation dialog
            var customer = customers.FirstOrDefault(c => c.ID == id);
            bool confirm = await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {customer.Name} customer?");
            if (confirm)
            {
                if (customer != null)
                {
                    customers.Remove(customer);
                }
            }
        }
        private void UpdateCsvFile()
        {
            CustomerCsvHandler.UpdateCsv();
            JSRuntime.InvokeVoidAsync("showAlert", "File updated successfully !");
        }
    }
}
