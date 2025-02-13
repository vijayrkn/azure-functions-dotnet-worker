﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace Microsoft.Azure.Functions.Worker.Sdk.Generators
{
    internal class DiagnosticDescriptors
    {
        private static DiagnosticDescriptor Create(string id, string title, string messageFormat, string category, DiagnosticSeverity severity)
        {
            var helpLink = $"https://aka.ms/azfw-rules?ruleid={id}";

            return new DiagnosticDescriptor(id, title, messageFormat, category, severity, isEnabledByDefault: true, helpLinkUri: helpLink);
        }

        public static DiagnosticDescriptor IncorrectBaseType { get; }
                = Create(id: "AZFW0003",
                    title: "Invalid base class for extension startup type.",
                    messageFormat: "'{0}' must derive from '{1}'.",
                    category: "Startup",
                    severity: DiagnosticSeverity.Error);

        public static DiagnosticDescriptor ConstructorMissing { get; }
                = Create(id: "AZFW0004",
                    title: "Extension startup type is missing parameterless constructor.",
                    messageFormat: "'{0}' class must have a public parameterless constructor.",
                    category: "Startup",
                    severity: DiagnosticSeverity.Error);

        public static DiagnosticDescriptor MultipleBindingsGroupedTogether { get; }
                = Create(id: "AZFW0005",
                    title: "Multiple bindings are grouped together on one property, method, or parameter syntax.",
                    messageFormat: "{0} '{1}' must have only one binding attribute.",
                    category: "FunctionMetadataGeneration",
                    severity: DiagnosticSeverity.Error);

        public static DiagnosticDescriptor SymbolNotFound { get; }
                = Create(id: "AZFW0006",
                    title: "Symbol could not be found in user compilation.",
                    messageFormat: "The symbol '{0}' could not be found.",
                    category: "FunctionMetadataGeneration",
                    severity: DiagnosticSeverity.Warning);

        public static DiagnosticDescriptor MultipleHttpResponseTypes { get; }
                  = Create(id: "AZFW0007",
                    title: "Symbol could not be found in user compilation.",
                    messageFormat: "Found multiple public properties of type HttpResponseData defined in return type '{0}'. Only one HTTP response binding type is supported in your return type definition.",
                    category: "FunctionMetadataGeneration",
                    severity: DiagnosticSeverity.Error);

        public static DiagnosticDescriptor InvalidCardinality { get; }
                  = Create(id: "AZFW0008",
                    title: "Input or Trigger Binding Cardinality is invalid.",
                    messageFormat: "The Cardinality of the Input or Trigger Binding on parameter '{0}' is invalid. IsBatched may be used incorrectly.",
                    category: "FunctionMetadataGeneration",
                    severity: DiagnosticSeverity.Error);
    }
}
