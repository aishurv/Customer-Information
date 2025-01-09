﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
namespace CustomerInformation

{
    public static class CustomerCsvHandler
    {
        public const string InputFilePath = "CustomerData.csv";
        public static List<Customer> customersData = new();
        static CustomerCsvHandler()
        {
            customersData = CustomerCsvHandler.ReadData();
        }
        public static List<Customer> ReadData(string filePath = InputFilePath)
        {
            List<Customer> customers;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            using (var reader = new StreamReader(filePath))
            {
                var csv = new CsvReader(reader, config);
                customers = csv.GetRecords<Customer>().ToList();
            }
            customersData = [.. customers]; // customersData = customers.ToList(); simplified version 
            return customers;
        }
        /// <summary>
        /// Return the List<Customer> 
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomerData()
        {
            return customersData;
        }
        /// <summary>
        /// Add Customer in List To reflect the change in .csv perform UpdateCsv
        /// </summary>
        /// <param name="customer"></param>
        public static void AddCustomer(Customer customer)
        {
            customersData.Add(customer);
        }
        /// <summary>
        /// Update the Csv file add delete and modify changes reflect 
        /// </summary>
        public static void UpdateCsv()
        {
            var writer = new StreamWriter(InputFilePath);
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write the header row and data
                if (customersData.Count != 0)
                    csv.WriteRecords(customersData);
                else
                    csv.WriteRecords("No Result Found !");
            }
        }
        /// <summary>
        /// Update Csv with the given list of Customer data 
        /// </summary>
        /// <param name="customersDataList"></param>
        public static void UpdateCsv(List<Customer> customersDataList)
        {
            var writer = new StreamWriter(InputFilePath);
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write the header row and data
                if (customersDataList.Count != 0)
                    csv.WriteRecords(customersDataList);
                else
                    Log.Warning("customersDataList Is Empty !");
            }
            customersData = [.. customersDataList];
        }
        /// <summary>
        /// Return the Customer data from given string if not found details return new customer instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Customer GetCustomerById(string id)
        {
            Customer? customer = customersData.FirstOrDefault(c => c.ID == id);
            return customer?? new Customer();
        }
    }
}

