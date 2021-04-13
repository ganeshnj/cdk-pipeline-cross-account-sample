using Amazon.CDK;
using Amazon.CDK.AWS.CodeCommit;

namespace CdkPipelineCrossAccount
{
    internal class CdkPipelineStackProps : StackProps
    {
        public IRepository MyRepository { get; set; }
    }
}