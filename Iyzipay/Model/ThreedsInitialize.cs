﻿using System;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class ThreedsInitialize : IyzipayResource
    {
        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public String HtmlContent { get; set; }

        public static ThreedsInitialize Create(CreatePaymentRequest request, Options options)
        {
            ThreedsInitialize response = RestHttpClient.Create().Post<ThreedsInitialize>(options.BaseUrl + "/payment/3dsecure/initialize", GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
