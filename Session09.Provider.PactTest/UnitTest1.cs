using PactNet;
using PactNet.Reporters.Outputters;
using System.Net.Http;
using System.Net.Http.Headers;
using FluentAssertions;
using Xunit;
using PactNet.Infrastructure.Outputters;
using System.Collections.Generic;

namespace Session09.Provider.PactTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
    public class ProviderPact {

        [Fact]
        public void DoTest() {
            var config = new PactVerifierConfig
            {

                // NOTE: We default to using a ConsoleOutput,
                // however xUnit 2 does not capture the console output,
                // so a custom outputter is required.
                Outputters = new List<IOutput>
                        {
                            new XUnitOutput(_outputHelper)
                        },

                // Output verbose verification logs to the test output
                Verbose = true
            };

            //Act / Assert
            IPactVerifier pactVerifier = new PactVerifier(config);
            pactVerifier.ProviderState($"{_pactServiceUri}/provider-states")
                .ServiceProvider("Provider", _providerUri)
                .HonoursPactWith("Consumer")
                .PactUri(@"..\..\..\..\..\pacts\consumer-provider.json")
                .Verify();
        }
    }
   
}
