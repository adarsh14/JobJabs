using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using JobJabs.Entity;

namespace JobJabs.DAL
{
    public class DatabaseApi
    {
        public string _ApiUrl = string.Empty;
        public DatabaseApi(string apiUrl)
        {
            _ApiUrl = apiUrl;
        }

        public iResponse PostApi<T>(iRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_ApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Basic " + request.AuthorizationToken);
                    client.DefaultRequestHeaders.Add("x-api-version", "1.0");
                  //  Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                    string json = JsonConvert.SerializeObject(request.Param, Formatting.Indented);
                    Task<HttpResponseMessage> response = client.PostAsync(request.ApiName, new StringContent(json, Encoding.UTF8, "application/json"));
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var trimStartChars = "[";
                        var trimEndChars = "]";
                        var ServiceResult = response.Result.Content.ReadAsStringAsync().Result.TrimStart(trimStartChars.ToCharArray()).TrimEnd(trimEndChars.ToCharArray());
                        apiResponse.Data = JsonConvert.DeserializeObject<T>(ServiceResult);
                        apiResponse.Status = 1;
                    }
                    else
                        apiResponse.Message = "Failed";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        public iResponse GetApi<T>(iRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_ApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", request.AuthorizationToken);
                    client.DefaultRequestHeaders.Add("x-api-version", "1.0");
                    Task<HttpResponseMessage> response = client.GetAsync(request.ApiName);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        var ServiceResult = response.Result.Content.ReadAsStringAsync().Result.Trim('[').TrimEnd(']');
                        apiResponse.Data = JsonConvert.DeserializeObject<T>(ServiceResult);
                        apiResponse.Status = 1;
                    }
                    else
                        apiResponse.Message = "Failed";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        public iResponse GetApiWithoutBaseUrl<T>(iRequest request)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    if (!string.IsNullOrEmpty(request.AuthorizationToken))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", request.AuthorizationToken);
                    }
                    if (!string.IsNullOrEmpty(request.ApiUrl))
                    {
                        Task<HttpResponseMessage> response = client.GetAsync(request.ApiUrl);
                        if (response.Result.IsSuccessStatusCode)
                        {
                            var ServiceResult = response.Result.Content.ReadAsStringAsync().Result.Trim('[').TrimEnd(']');
                            apiResponse.Data = JsonConvert.DeserializeObject<T>(ServiceResult);
                            apiResponse.Status = 1;
                        }
                        else
                            apiResponse.Message = "Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                apiResponse.Message = ex.Message;
                WriteToLogClass.WriteInfo("SMS Api Failure ------------------\n" + ex.Message);
            }

            return apiResponse;
        }

     
    }
}