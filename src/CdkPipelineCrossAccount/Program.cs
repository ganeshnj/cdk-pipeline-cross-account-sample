using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;
using Environment = Amazon.CDK.Environment;

namespace CdkPipelineCrossAccount
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var sourceEnv = new Environment()
            {
                Account = "{source-account-id}",
                Region = "us-west-2"
            };

            var pipelineEnv = new Environment()
            {
                Account =  "{pipeline-account-id}",
                Region = "us-west-2"
            };

            var app = new App();

            var sourceStack = new SourceStack(app, "SourceStack", new StackProps
            {
                Env = sourceEnv,
            });

            new CdkPipelineStack(app, "CdkPipelineStack", new CdkPipelineStackProps
            {
                Env = pipelineEnv,
                MyRepository = sourceStack.MyRepository
            });

            app.Synth();
        }
    }
}
