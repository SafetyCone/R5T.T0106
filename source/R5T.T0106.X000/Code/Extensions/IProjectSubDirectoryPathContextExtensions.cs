using System;
using System.Threading.Tasks;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;


namespace System
{
    public static class IProjectSubDirectoryPathContextExtensions
    {
        public static async Task InProjectSubFilePathContex(this IProjectSubDirectoryPathContext projectSubDirectoryPathContext,
            string subFileRelativePath,
            Func<ProjectSubFilePathContext, Task> projectSubFilePathContextAction = default)
        {
            // Get the sub-file path.
            var subFilePath = Instances.PathOperator.GetFilePath(
                projectSubDirectoryPathContext.DirectoryPath,
                subFileRelativePath);

            // Make sure the directory for the file exists.
            var projectSubFileDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(subFilePath);

            Instances.FileSystemOperator.CreateDirectory(projectSubFileDirectoryPath);

            // Now modify the sub-file.
            var projectSubFilePathContext = new ProjectSubFilePathContext
            {
                FilePath = subFilePath,
                ProjectFileContext = projectSubDirectoryPathContext.ProjectFileContext,
                SolutionFileContext = projectSubDirectoryPathContext.SolutionFileContext,
            };

            await FunctionHelper.Run(projectSubFilePathContextAction, projectSubFilePathContext);
        }

        public static void InProjectSubFilePathContextSynchronous(this IProjectSubDirectoryPathContext projectSubDirectoryPathContext,
            string subFileRelativePath,
            Action<ProjectSubFilePathContext> projectSubFilePathContextAction = default)
        {
            // Get the sub-file path.
            var subFilePath = Instances.PathOperator.GetFilePath(
                projectSubDirectoryPathContext.DirectoryPath,
                subFileRelativePath);

            // Make sure the directory for the file exists.
            var projectSubFileDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(subFilePath);

            Instances.FileSystemOperator.CreateDirectory(projectSubFileDirectoryPath);

            // Now modify the sub-file.
            var projectSubFilePathContext = new ProjectSubFilePathContext
            {
                FilePath = subFilePath,
                ProjectFileContext = projectSubDirectoryPathContext.ProjectFileContext,
                SolutionFileContext = projectSubDirectoryPathContext.SolutionFileContext,
            };

            FunctionHelper.Run(projectSubFilePathContextAction, projectSubFilePathContext);
        }

        public static async Task InProjectSubDirectoryPathContex(this IProjectSubDirectoryPathContext projectSubDirectoryPathContext,
           string subDirectoryRelativePath,
           Func<ProjectSubDirectoryPathContext, Task> projectSubDirectoryPathContextAction = default)
        {
            // Get the sub-directory path.
            var subDirectoryPath = Instances.PathOperator.GetFilePath(
                projectSubDirectoryPathContext.DirectoryPath,
                subDirectoryRelativePath);

            // Make sure the sub-directory exists.
            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            // Now modify the sub-directory.
            var childProjectSubDirectoryPathContext = new ProjectSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectSubDirectoryPathContext.ProjectFileContext,
                SolutionFileContext = projectSubDirectoryPathContext.SolutionFileContext,
            };

            await FunctionHelper.Run(projectSubDirectoryPathContextAction, childProjectSubDirectoryPathContext);
        }

        public static void InProjectSubDirectoryPathContextSynchronous(this IProjectSubDirectoryPathContext projectSubDirectoryPathContext,
            string subDirectoryRelativePath,
            Action<ProjectSubDirectoryPathContext> projectSubDirectoryPathContextAction = default)
        {
            // Get the sub-directory path.
            var subDirectoryPath = Instances.PathOperator.GetFilePath(
                projectSubDirectoryPathContext.DirectoryPath,
                subDirectoryRelativePath);

            // Make sure the directory for the file exists.
            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            // Now modify the sub-file.
            var childProjectSubDirectoryPathContext = new ProjectSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectSubDirectoryPathContext.ProjectFileContext,
                SolutionFileContext = projectSubDirectoryPathContext.SolutionFileContext,
            };

            FunctionHelper.Run(projectSubDirectoryPathContextAction, childProjectSubDirectoryPathContext);
        }
    }
}
