using System;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;

namespace System
{
    public static class IProjectFileContextExtensions
    {
        public static void InProjectSubDirectoryPathContextSynchronous(this IProjectFileContext projectFileWithSolutionFileContext,
           string projectSubDirectoryRelativePath,
           Action<ProjectWithoutSolutionSubDirectoryPathContext> projectWithoutSolutionSubDirectoryPathContextAction = default)
        {
            var subDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectFileWithSolutionFileContext.DirectoryPath,
                projectSubDirectoryRelativePath);

            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            var projectSubDirectoryPathContext = new ProjectWithoutSolutionSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectFileWithSolutionFileContext,
            };

            FunctionHelper.Run(projectWithoutSolutionSubDirectoryPathContextAction, projectSubDirectoryPathContext);
        }
    }
}
