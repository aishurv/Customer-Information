﻿using CustomerInformation.Helper;
using CustomerInformation.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
namespace CustomerInformation.Components.Pages
{
    public partial class AddCustomer
    {
        public Customer customer { get; set; } = new Customer();

        protected string Message = string.Empty;
        protected bool IsSaved = false;

        protected override void OnInitialized()
        {
            customer = new Customer();
        }

        private void OnSubmit()
        {
            if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.ID))
            {
                Console.WriteLine("Form data is invalid.");
                JSRuntime.InvokeVoidAsync("showAlert", "Form data is invalid.");
            }
            else
            {
                CustomerCsvHandler.AddCustomer(customer);

                IsSaved = true;
                Message = "Customer added successfully";

            }

            StateHasChanged();
        }
        private void AddAnother()
        {
            IsSaved =false;
        }
        private void UpdateCsvFile()
        {
            if (CustomerCsvHandler.UpdateCsv())
            {
                JSRuntime.InvokeVoidAsync("showAlert", "File updated Successfully !");
            }
            else
            {
                JSRuntime.InvokeVoidAsync("showAlert", "Error ! Check log for more details !");
            }
        }
    }
		
}
