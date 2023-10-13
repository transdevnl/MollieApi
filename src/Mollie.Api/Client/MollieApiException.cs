using System;
using Mollie.Api.Models.Error;
using Newtonsoft.Json;

namespace Mollie.Api.Client {
    public class MollieApiException : Exception {
        public int StatusCode { get; set; }
        public MollieErrorMessage Details { get; set; }

        public MollieApiException(int statusCode, string json) : base(ParseErrorMessage(json).ToString()){
            StatusCode = statusCode;
            this.Details = ParseErrorMessage(json);
        }

        private static MollieErrorMessage ParseErrorMessage(string json) {
            return JsonConvert.DeserializeObject<MollieErrorMessage>(json);
        }
    }
}