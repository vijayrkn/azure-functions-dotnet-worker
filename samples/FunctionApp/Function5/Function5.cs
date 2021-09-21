﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Core.Converters.Converter;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class Function5
    {
        private readonly IHttpResponderService _responderService;
        private readonly ILogger<Function5> _logger;

        public Function5(IHttpResponderService responderService, ILogger<Function5> logger)
        {
            _responderService = responderService;
            _logger = logger;
        }

        [Function(nameof(Function5))]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req, 
            FunctionContext executionContext,
            [Converter(typeof(MyCustomerConverter))] CustomerViewModel customer)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString($"View model received> ID:{customer?.Id}, NAME: {customer?.Name}");
            return response;
        }
    }

    public interface IHttpResponderService
    {
        HttpResponseData ProcessRequest(HttpRequestData httpRequest);
    }

    public class DefaultHttpResponderService : IHttpResponderService
    {
        public DefaultHttpResponderService()
        {

        }

        public HttpResponseData ProcessRequest(HttpRequestData httpRequest)
        {
            var response = httpRequest.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Date", "Mon, 18 Jul 2016 16:06:00 GMT");
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString("Welcome to .NET 5!!");

            return response;
        }
    }
}
