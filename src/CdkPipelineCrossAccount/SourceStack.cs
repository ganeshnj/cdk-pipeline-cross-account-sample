using Amazon.CDK;
using Amazon.CDK.AWS.CodeCommit;

namespace CdkPipelineCrossAccount
{
    internal class SourceStack : Stack
    {
        public SourceStack(Constructs.Construct scope, string source, IStackProps prop) : base(scope, source, prop)
        {
            MyRepository = new Repository(this, "MyRepository", new RepositoryProps()
            {
                RepositoryName = "MyRepository"
            });
        }

        public IRepository MyRepository { get; }
    }
}