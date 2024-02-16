using RestSharp;

namespace EWS.Job
{
    public class ClientProvider
    {
        public static async Task<RestResponse> GetAsync(string url, string? jwtToken = "")
        {
            var client = new RestClient();
            //client.Timeout = -1;
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(jwtToken))
                request.AddHeader("Authorization", $"Bearer {jwtToken}");

            return await client.ExecuteAsync(request);
            //RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
            //return response.Content ?? "";
        }
    }
}