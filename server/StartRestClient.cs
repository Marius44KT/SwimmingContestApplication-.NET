using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace concursInot;


public class StartRestClient
{
    public class RestClient
    {
        public const string BaseUrl = "http://localhost:8080/app/participants";
        public readonly HttpClient _httpClient = new HttpClient();

        public async Task GetParticipantsAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var part = await response.Content.ReadAsStringAsync();
            var participants = JsonConvert.DeserializeObject<Participant[]>(part);
            Console.WriteLine("All participants:");
            foreach (var participant in participants)
            {
                Console.WriteLine(participant.ToString());
            }
        }

        public async Task GetParticipantAsync(long id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Participant with id {id} not found.");
                return;
            }

            response.EnsureSuccessStatusCode();
            var part = await response.Content.ReadAsStringAsync();
            var participant = JsonConvert.DeserializeObject<Participant>(part);
            Console.WriteLine("Participant details:");
            Console.WriteLine(participant);
        }

        public async Task CreateParticipantAsync(Participant participant)
        {
            var part = JsonConvert.SerializeObject(participant);
            var response =
                await _httpClient.PostAsync(BaseUrl, new StringContent(part, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdParticipant = JsonConvert.DeserializeObject<Participant>(responseContent);
            Console.WriteLine("Created participant:");
            Console.WriteLine(createdParticipant);
        }

        public async Task UpdateParticipantAsync(Participant participant)
        {
            var part = JsonConvert.SerializeObject(participant);
            var response = await _httpClient.PutAsync($"{BaseUrl}/{participant.Id}",
                new StringContent(part, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Participant with id {participant.Id} not found.");
                return;
            }

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var updatedParticipant = JsonConvert.DeserializeObject<Participant>(responseContent);
            Console.WriteLine("Updated participant:");
            Console.WriteLine(updatedParticipant);
        }

        public async Task DeleteParticipantAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine($"Participant with id {id} not found.");
                return;
            }

            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Participant with id {id} deleted.");
        }
    }

    static async Task Main(string[] args)
    {
            var restClient = new RestClient();

            // Get all participants
            await restClient.GetParticipantsAsync();

            // Get participant by id
            await restClient.GetParticipantAsync(3);

            // Create new participant
            Participant p = new Participant(4,Distanta.dist800m,Stil.spate);
            Console.WriteLine(p.ToString());
            //p.Id=20;
            await restClient.CreateParticipantAsync(p);

            var response = await restClient._httpClient.GetAsync("http://localhost:8080/app/participants");
            response.EnsureSuccessStatusCode();
            var part = await response.Content.ReadAsStringAsync();
            var participants = JsonConvert.DeserializeObject<Participant[]>(part);
            long id=20;
            p.setDistanta(Distanta.dist1500m);
            await restClient.UpdateParticipantAsync(p);

            await restClient.GetParticipantAsync(id);

            // Delete created participant
            await restClient.DeleteParticipantAsync(id);

            // await restClient.GetParticipantAsync(id);
    }
}