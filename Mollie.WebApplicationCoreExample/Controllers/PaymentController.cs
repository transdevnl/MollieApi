﻿using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.List;
using Mollie.Api.Models.List.Specific;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Url;
using Mollie.WebApplicationCoreExample.Models;

namespace Mollie.WebApplicationCoreExample.Controllers {
    public class PaymentController : Controller {
        private readonly IPaymentClient _paymentClient;

        public PaymentController(IPaymentClient paymentClient) {
            this._paymentClient = paymentClient;
        }

        [HttpGet]
        public async Task<ViewResult> Index() {
            ListResponse<PaymentListData> paymentList = await this._paymentClient.GetPaymentListAsync();
            return this.View(paymentList);
        }

        [HttpGet]
        public async Task<ViewResult> Next([FromQuery]string url) {
            return await this.GetListByUrl(url);
        }

        [HttpGet]
        public async Task<ViewResult> Previous([FromQuery] string url) {
            return await this.GetListByUrl(url);
        }

        [HttpGet]
        public ViewResult Create() {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentModel model) {
            if (!this.ModelState.IsValid) {
                return this.View();
            }

            PaymentRequest paymentRequest = new PaymentRequest() {
                Amount = new Amount(model.Currency, model.Amount.ToString(CultureInfo.InvariantCulture)),
                Description = model.Description,
                RedirectUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}"
            };

            await this._paymentClient.CreatePaymentAsync(paymentRequest);

            return this.RedirectToAction(nameof(this.Index));
        }

        private async Task<ViewResult> GetListByUrl(string url) {
            UrlObjectLink<ListResponse<PaymentListData>> urlObject = new UrlObjectLink<ListResponse<PaymentListData>>() {
                Href = url
            };

            ListResponse<PaymentListData> paymentList = await this._paymentClient.GetPaymentListAsync(urlObject);
            return this.View(nameof(this.Index), paymentList);
        }
    }
}