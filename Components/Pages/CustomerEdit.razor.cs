﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomerInformation.Components.Pages
{
    public partial class CustomerEdit
    {
        [Parameter]
        public required string Id { get; set; }
        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        [SupplyParameterFromForm]
        public Customer customer { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Saved = false;
            customer = CustomerCsvHandler.GetCustomerById(Id);
        }

        protected void SaveToFile()
        {
            CustomerCsvHandler.UpdateCsv();
            JSRuntime.InvokeVoidAsync("showAlert", "File updated successfully !");
        }
        protected void OnUpdate()
        {
            Saved=true;
            JSRuntime.InvokeVoidAsync("showAlert", "Customer Details updated successfully !");
        }
        protected void BackToModify()
        {
            NavigationManager.NavigateTo($"/modify");
        }
    }
}
