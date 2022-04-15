﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Functions.Worker;

namespace FunctionApp
{
    public static class Function2
    {
        [Function("Function2")]
        public static Book Run([QueueTrigger("functionstesting2", Connection = "MyStorageConnStr")] Book myQueueItem,
            [BlobInput("test-samples/sample1.txt", Connection = "MyStorageConnStr")] string myBlob)
        {
            Console.WriteLine(myBlob);
            return myQueueItem;
        }
    }

    public class Book
    {
        public string name { get; set; }
        public string id { get; set; }
    }

}
