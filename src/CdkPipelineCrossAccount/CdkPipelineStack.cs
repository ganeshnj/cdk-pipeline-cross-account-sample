using Amazon.CDK;
using Amazon.CDK.AWS.CodePipeline;
using Amazon.CDK.AWS.CodePipeline.Actions;
using Amazon.CDK.Pipelines;
using Construct = Constructs.Construct;

namespace CdkPipelineCrossAccount
{
    public class CdkPipelineStack : Stack
    {
        internal CdkPipelineStack(Construct scope, string id, CdkPipelineStackProps props = null) : base(scope, id, props)
        {
            var sourceArtifact = new Artifact_("SourceArtifact");
            var outputArtifact = new Artifact_("OutputArtifact");

            var sourceAction = new CodeCommitSourceAction(new CodeCommitSourceActionProps
            {
                ActionName = "CodeCommit",
                Output = sourceArtifact,
                Repository = props.MyRepository,
                Branch = "main",
            });

            // Self mutation
            var pipeline = new CdkPipeline(this, "CdkPipeline", new CdkPipelineProps
            {
                PipelineName = "CrossAccountSourcePipeline",
                CloudAssemblyArtifact = outputArtifact,

                SourceAction = sourceAction,

                // It synthesizes CDK code to cdk.out directory which is picked by SelfMutate stage to mutate the pipeline
                SynthAction = new SimpleSynthAction(new SimpleSynthActionProps
                {
                    SourceArtifact = sourceArtifact,
                    CloudAssemblyArtifact = outputArtifact,
                    InstallCommands = new[]
                    {
                        "npm install -g aws-cdk",
                    },
                    BuildCommands = new[] {"dotnet build"},
                    SynthCommand = "cdk synth",
                }),
            });
        }
    }
}
