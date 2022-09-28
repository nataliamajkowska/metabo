using MetaboCoins.Helpers;
using MetaboCoins.Helpers.Response;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MetaboCoins.Services
{
    public class NonHttpResponseMessage
    {
        public String Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }

    public class ApiServices
    {
        private string _url = "http://localhost:24654/api/"; //dev ios url
        public string error = "ERROR";
        public ApiServices()
        {
            // localhost for UWP/iOS or special IP for Android
            if (Device.RuntimePlatform == Device.Android)
            {

                _url = "http://10.0.2.2:24654/api/";

            }
            _url = "http://apimetabo.hostingasp.pl/api/";
        }

        public async Task<NonHttpResponseMessage> GetResponse(string path, object model, bool isauthenticated = true)
        {
            var ret = new NonHttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(model);

                if (isauthenticated)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ProfileHelper.Token);
                }

                try
                {
                    var properties = new Dictionary<string, string>
                {
                    { "path", path },
                    { "data", json.ToString()},
                    { "isauthenticated", isauthenticated.ToString() }
                };
                    HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var ret2 = await client.PostAsync(_url + path, content);
                    ret.StatusCode = ret2.StatusCode;
                    ret.Content = await ret2.Content.ReadAsStringAsync();
                    ret.IsSuccessStatusCode = ret2.IsSuccessStatusCode;

                    return ret;
                }
                catch (Exception exception)
                {
                    NonHttpResponseMessage httpResponse = new NonHttpResponseMessage();
                    httpResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    return httpResponse;
                }
            }
        }
        public async Task<string> CheckApiResponseObject(NonHttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var apiResponse = response.Content;
                if (apiResponse != null)
                {
                    var baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                    if (baseResponse.Status == "Success")
                    {
                        string json = JsonConvert.SerializeObject(baseResponse.Obj);
                        return json;
                    }
                    else if (baseResponse.Status == "Error")
                    {
                        if (baseResponse.Message == "WrongLoginOrPassword")
                        {
                            await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("login"));
                            return error;
                        }
                        else if (baseResponse.Message == "Duplicate")
                        {
                            await PopupNavigation.Instance.PushAsync(new DuplicateScanPopup());
                            return error;
                        }
                        else if (baseResponse.Message == "Failed")
                        {
                            await PopupNavigation.Instance.PushAsync(new FailedScanPopup());
                            return error;
                        }
                        else
                        {
                            await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("error", baseResponse.Message));
                            return error;
                        }
                    }
                    else if (baseResponse.Status == "InternalError")
                    {
                        await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("internalError", baseResponse.Message));
                        return error;
                    }
                    else
                    {
                        await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("noConnection"));
                        return error;
                    }
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("noConnection"));
                    return error;
                }
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new NotificationAlertPopup("noConnection"));
                return error;
            }
        }
    }
}
