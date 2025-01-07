using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
namespace Customer_Information

{
    public class CustomerRepository
    {
        public const string InputFilePath = "CustomerData.csv";
        public static List<Customer> customersData = new();
        static CustomerRepository()
        {
            customersData = CustomerRepository.ReadData();
        }
        public static List<Customer> ReadData(string filePath = InputFilePath)
        {
            List<Customer> customers;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, config);

            customers = csv.GetRecords<Customer>().ToList();
            customersData = [.. customers]; // customersData = customers.ToList(); simplified version 
            return customers;
        }
        public static List<Customer> GetCustomerData()
        {
            return customersData;
        }
    }
}

