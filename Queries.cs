using Serilog;
namespace Customer_Information
{
    public class Queries
    {
        public static List<string> ValidSearchAttributes =
            [
                "CustomerID",
                "CustomerName",
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany",
                "CustomerPhone",
                "CustomerEmail"
            ];
        public static List<string> ValidSortAttributes =
            [
                "CustomerID",
                "CustomerName",
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany",
                "CustomerPhone",
                "CustomerEmail"
            ];
        public static List<string> ValidGroupAttributes =
            [
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany"
            ];
        public static List<Customer> Find(List<Customer> customers , string attributeName , string attributeValue)
        {
            Log.Information($"Find {attributeValue} of {attributeName}");
#nullable disable
            var property = typeof(Customer).GetProperty(attributeName);
            
            var matchedCustomers = customers.Where(c =>
            {
                var value = property.GetValue(c)?.ToString();
                return !string.IsNullOrEmpty(value) &&
                       !string.IsNullOrEmpty(attributeValue) &&
                       value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
            }).ToList();
            return matchedCustomers;
        }
        public static List<Customer> SortCustomers(List<Customer> customers, string attributeName, bool ascending = true)
        {
            var property = typeof(Customer).GetProperty(attributeName);            
            return ascending
                ? customers.OrderBy(c => property.GetValue(c, null)).ToList()
                : customers.OrderByDescending(c => property.GetValue(c, null)).ToList();
        }
        public static IEnumerable<IGrouping<object, Customer>> GroupByAttribute(List<Customer> collection, string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            
            return collection.GroupBy(item => property.GetValue(item, null));
        }
       public static List<string> getDistinctValues (List<Customer> collection,string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            
            return collection
                .Select(item => property.GetValue(item, null)?.ToString()) // Get property value and convert to string
                .Where(value => value != null) // Filter out null values
                .Distinct() // Get distinct values
                .ToList(); // Convert to list
        }

    }
}
