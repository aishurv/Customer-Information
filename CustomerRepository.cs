﻿using System;
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
        public static string InputFilePath = "CustomerData.csv";
        public static List<Customer> ReadData(string filePath)
        {
            List<Customer> customers;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, config);

            customers = csv.GetRecords<Customer>().ToList();
            return customers;
        }
        public static List<Customer> ReadData()
        {
            List<Customer> customers;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            var reader = new StreamReader(InputFilePath);
            var csv = new CsvReader(reader, config);

            customers = csv.GetRecords<Customer>().ToList();
            Log.Information($" From {InputFilePath} data loaded Successfully !");
            return customers;
        }
    }
}

