using System;
using System.Threading.Tasks;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;

namespace System
{
    public static class IProjectFileContextExtensions
    {
        public static async Task InProjectSubDirectoryPathContext(this IProjectFileContext projectFileWithSolutionFileContext,
            string projectSubDirectoryRelativePath,
            Func<ProjectWithoutSolutionSubDirectoryPathContext, Task> projectSubDirectoryPathContextAction = default)
        {
            var subDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectFileWithSolutionFileContext.DirectoryPath,
                projectSubDirectoryRelativePath);

            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            var projectSubDirectoryPathContext = new ProjectWithoutSolutionSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectFileWithSolutionFileContext
            };

            await FunctionHelper.Run(projectSubDirectoryPathContextAction, projectSubDirectoryPathContext);
        }

        public static void InProjectSubDirectoryPathContextSynchronous(this IProjectFileContext projectFileWithSolutionFileContext,
            string projectSubDirectoryRelativePath,
            Action<ProjectWithoutSolutionSubDirectoryPathContext> projectSubDirectoryPathContextAction = default)
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

            FunctionHelper.Run(projectSubDirectoryPathContextAction, projectSubDirectoryPathContext);
        }
    }
}
