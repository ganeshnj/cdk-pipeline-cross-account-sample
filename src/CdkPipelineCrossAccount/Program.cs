using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CdkPipelineCrossAccount
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CdkPipelineCrossAccountStack(app, "CdkPipelineCrossAccountStack", new StackProps
            {
            });

            app.Synth();
        }
    }
}
