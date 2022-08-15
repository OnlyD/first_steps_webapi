namespace HelloWorld;

public class WeatherForecast // Definicion de objeto, es el conjunto de propiedades
{
    public DateTime Date
    {
        get; set;
    }

    public int TemperatureC
    {
        get; set;
    }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary
    {
        get; set;
    }
}