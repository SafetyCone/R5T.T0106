using System;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;


namespace System
{
    public static class ProjectWithoutSolutionSubDirectoryPathContextExtensions
    {
        public static void InProjectSubFilePathContextSynchronous(this ProjectWithoutSolutionSubDirectoryPathContext projectWithoutSolutionSubDirectoryPathContext,
            string projectSubFileRelativePath,
            Action<ProjectWithoutSolutionSubFilePathContext> projectWithoutSolutionSubFilePathContextAction = default)
        {
            // Get the sub-file path.
            var subFilePath = Instances.PathOperator.GetFilePath(
                projectWithoutSolutionSubDirectoryPathContext.DirectoryPath,
                projectSubFileRelativePath);

            // Make sure the directory for the file exists.
            var projectSubFileDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(subFilePath);

            Instances.FileSystemOperator.CreateDirectory(projectSubFileDirectoryPath);

            // Now modify the sub-file.
            var projectSubFilePathContext = new ProjectWithoutSolutionSubFilePathContext
            {
                FilePath = subFilePath,
                ProjectFileContext = projectWithoutSolutionSubDirectoryPathContext.ProjectFileContext,
            };

            FunctionHelper.Run(projectWithoutSolutionSubFilePathContextAction, projectSubFilePathContext);
        }
    }
}
