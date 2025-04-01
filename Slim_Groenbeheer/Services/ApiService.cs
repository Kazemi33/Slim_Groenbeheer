using Slim_Groenbeheer.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiService
{
    private readonly HttpClient BaseAddress;

    public ApiService(HttpClient httpClient)
    {
        BaseAddress = httpClient;
    }
    

    //sensor
    public async Task<List<SensorData>> GetSensorDataAsync()
    {
        return await BaseAddress.GetFromJsonAsync<List<SensorData>>("sensors");
    }

    //kas
    public async Task<List<KassenData>> GetKassenDataAsync()
    {
        return await BaseAddress.GetFromJsonAsync<List<KassenData>>("kassen");
    }
    //metingen
    public async Task<List<MetingenData>> GetMetingenDataAsync()
    {
        return await BaseAddress.GetFromJsonAsync<List<MetingenData>>("metingen");
    }

}
