﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Functions.Worker.Context.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit.Sdk;

namespace Microsoft.Azure.Functions.Worker.Tests
{
    internal static class TestUtility
    {
        public static string DefaultPropertyName = "input";

        public static DefaultModelBindingFeature GetDefaultBindingFeature(Action<WorkerOptions> configure = null)
        {
            return new ServiceCollection()
                .Configure<WorkerOptions>(o => configure?.Invoke(o))
                .AddSingleton<DefaultModelBindingFeature>()
                .RegisterOutputChannel()
                //.RegisterDefaultConverters()
                .BuildServiceProvider()
                .GetService<DefaultModelBindingFeature>();
        }

        public static T AssertIsTypeAndConvert<T>(object target)
        {
            if (target is not T converted)
            {
                throw new AssertActualExpectedException(typeof(T), target?.GetType(), string.Empty);
            }

            return converted;
        }

        public static IOptions<TOptions> WrapOptions<TOptions>(TOptions options = null) where TOptions : class, new()
        {
            options ??= new TOptions();
            return new OptionsWrapper<TOptions>(options);
        }
    }
}
