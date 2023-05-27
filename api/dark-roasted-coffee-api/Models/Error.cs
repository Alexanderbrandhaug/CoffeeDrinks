namespace dark_roasted_coffee_api.Models;

public class Error
{
    public int code { get; set; }
    public string message { get; set; }


    public Error(int code, string message)
    {
        this.code = code;
        this.message = message;
    }
}