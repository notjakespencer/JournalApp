using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JournalApp.ApiService.Helpers;

namespace JournalApp.ApiService.Services
{
 public class ApiClientService
 {
 private readonly HttpClient _httpClient;

 public ApiClientService(HttpClient httpClient)
 {
 _httpClient = httpClient;
 }

 // Read API base URL from environment variable or user secrets
 private static readonly string ApiBaseUrl = ApiConfig.Get("JournalApp_ApiBaseUrl");

 public void SetAuthToken(string token)
 {
 _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
 }

 public async Task<string?> GetDailyPromptAsync()
 {
 var response = await _httpClient.GetAsync($"{ApiBaseUrl}/prompt/today");
 response.EnsureSuccessStatusCode();
 return await response.Content.ReadAsStringAsync();
 }

 public async Task<bool> SubmitJournalEntryAsync(string entryText, string mood)
 {
 var content = new StringContent($"{{'entry':'{entryText}','mood':'{mood}'}}", System.Text.Encoding.UTF8, "application/json");
 var response = await _httpClient.PostAsync($"{ApiBaseUrl}/journal/submit", content);
 return response.IsSuccessStatusCode;
 }

 // TODO: Add methods for XP, streak, calendar, mood history, etc.
 }
}
