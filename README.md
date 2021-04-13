# Welcome to your CDK C# project!

This is a blank project for C# development with CDK.

The `cdk.json` file tells the CDK Toolkit how to execute your app.

It uses the [.NET Core CLI](https://docs.microsoft.com/dotnet/articles/core/) to compile and execute your project.

## Steps

```
npx cdk bootstrap --cloudformation-execution-policies arn:aws:iam::aws:policy/AdministratorAccess aws://{pipeline-account-id}/us-west-2
npx cdk bootstrap --cloudformation-execution-policies arn:aws:iam::aws:policy/AdministratorAccess --trust {pipeline-account-id} aws://{source-account-id}/us-west-2 --profile source
cdk synth
cdk deploy --all
```

```
The action failed because no branch named main was found in the selected AWS CodeCommit repository MyRepository. Make sure you are using the correct branch name, and then try again. Error: null
```

Go to the source AWS account and create a `main` branch.

Try again source stage.

```
The service role or action role doesn’t have the permissions required to access the Amazon S3 bucket named {bucket-name}. Update the IAM role permissions, and then try again. Error: Amazon S3:AccessDenied:Access Denied (Service: Amazon S3; Status Code: 403; Error Code: AccessDenied; Request ID: {Request ID}; S3 Extended Request ID: {Extended Request ID}; Proxy: null)
```

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template