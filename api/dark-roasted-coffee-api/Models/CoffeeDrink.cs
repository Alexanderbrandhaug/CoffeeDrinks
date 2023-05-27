using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace dark_roasted_coffee_api.Models;

public class CoffeeDrink
{
    public int id { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public FormCode FormCode { get; set; }
    public int displayOrder { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public Availability Availability { get; set; }
    public Assets assets { get; set; }
    public List<Size> sizes { get; set; }

}