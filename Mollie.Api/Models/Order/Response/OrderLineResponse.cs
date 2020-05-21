﻿using Mollie.Api.JsonConverters;
using Newtonsoft.Json;
using System;

namespace Mollie.Api.Models.Order {
    public class OrderLineResponse : OrderLineRequest {
        /// <summary>
        /// The order line’s unique identifier, for example odl_dgtxyl.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Status of the order line
        /// </summary>
        public OrderLineStatus Status { get; set; }

        /// <summary>
        /// Whether or not the order line can be (partially) canceled.
        /// </summary>
        public bool IsCancelable { get; set; }

        /// <summary>
        /// The number of items that are shipped for this order line.
        /// </summary>
        public int QuantityShipped { get; set; }

        /// <summary>
        /// The total amount that is shipped for this order line.
        /// </summary>
        public Amount AmountShipped { get; set; }

        /// <summary>
        /// The number of items that are refunded for this order line.
        /// </summary>
        public int QuantityRefunded { get; set; }

        /// <summary>
        /// The total amount that is refunded for this order line.
        /// </summary>
        public Amount AmountRefunded { get; set; }

        /// <summary>
        /// The number of items that are canceled in this order line.
        /// </summary>
        public int QuantityCanceled { get; set; }

        /// <summary>
        /// The total amount that is canceled in this order line.
        /// </summary>
        public Amount AmountCanceled { get; set; }

        /// <summary>
        /// The number of items that can still be shipped for this order line.
        /// </summary>
        public int ShippableQuantity { get; set; }

        /// <summary>
        /// The number of items that can still be refunded for this order line.
        /// </summary>
        public int RefundableQuantity { get; set; }

        /// <summary>
        /// The number of items that can still be canceled for this order line.
        /// </summary>
        public int CancelableQuantity { get; set; }

        /// <summary>
        /// The order line’s date and time of creation
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Provide any data you like, for example a string or a JSON object. We will save the data 
        /// alongside the order. Whenever you fetch the order with our API, we’ll also include the 
        /// metadata. You can use up to approximately 1kB.
        /// </summary>
        [JsonConverter(typeof(RawJsonConverter))]
        public string Metadata { get; set; }
    }
}
