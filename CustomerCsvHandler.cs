using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
namespace CustomerInformation

{
    public class CustomerCsvHandler
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
        public static List<Customer> GetCustomerData()
        {
            return customersData;
        }
        public static void AddCustomer(Customer customer)
        {
            customersData.Add(customer);
        }
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
    }
}

