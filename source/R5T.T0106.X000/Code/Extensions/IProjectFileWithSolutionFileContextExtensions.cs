using System;
using System.Threading.Tasks;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;


namespace System
{
    public static class IProjectFileWithSolutionFileContextExtensions
    {
        public static async Task InProjectSubDirectoryPathContext(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            string projectSubDirectoryRelativePath,
            Func<ProjectSubDirectoryPathContext, Task> projectSubDirectoryPathContextAction = default)
        {
            var subDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectFileWithSolutionFileContext.DirectoryPath,
                projectSubDirectoryRelativePath);

            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            var projectSubDirectoryPathContext = new ProjectSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectFileWithSolutionFileContext,
                SolutionFileContext = projectFileWithSolutionFileContext.SolutionFileContext,
            };

            await FunctionHelper.Run(projectSubDirectoryPathContextAction, projectSubDirectoryPathContext);
        }

        public static void InProjectSubDirectoryPathContextSynchronous(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            string projectSubDirectoryRelativePath,
            Action<ProjectSubDirectoryPathContext> projectSubDirectoryPathContextAction = default)
        {
            var subDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectFileWithSolutionFileContext.DirectoryPath,
                projectSubDirectoryRelativePath);

            Instances.FileSystemOperator.CreateDirectory(subDirectoryPath);

            var projectSubDirectoryPathContext = new ProjectSubDirectoryPathContext
            {
                DirectoryPath = subDirectoryPath,
                ProjectFileContext = projectFileWithSolutionFileContext,
                SolutionFileContext = projectFileWithSolutionFileContext.SolutionFileContext,
            };

            FunctionHelper.Run(projectSubDirectoryPathContextAction, projectSubDirectoryPathContext);
        }

        public static async Task InCodeDirectoryFilePathContext(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            string subFileRelativePath,
            Func<ProjectSubFilePathContext, Task> codeDirectoryFilePathContextAction = default)
        {
            await projectFileWithSolutionFileContext.InCodeDirectoryPathContext(
                async codeDirectoryContext =>
                {
                    await codeDirectoryContext.InProjectSubFilePathContex(subFileRelativePath,
                        codeDirectoryFilePathContextAction);
                });
        }

        public static async Task InCodeDirectoryPathContext(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            Func<ProjectSubDirectoryPathContext, Task> codeDirectoryContextAction = default)
        {
            await projectFileWithSolutionFileContext.InProjectSubDirectoryPathContext(
                Instances.CodeDirectoryName.Code(),
                codeDirectoryContextAction);
        }

        public static void InCodeDirectoryPathContextSynchronous(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            Action<ProjectSubDirectoryPathContext> codeDirectoryContextAction = default)
        {
            projectFileWithSolutionFileContext.InProjectSubDirectoryPathContextSynchronous(
                Instances.CodeDirectoryName.Code(),
                codeDirectoryContextAction);
        }

        public static void InProjectSubFilePathContextSynchronous(this IProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            string projectSubFileRelativePath,
            Action<ProjectSubFilePathContext> projectSubFilePathContextAction = default)
        {
            // Get the sub-file path.
            var subFilePath = Instances.PathOperator.GetFilePath(
                projectFileWithSolutionFileContext.DirectoryPath,
                projectSubFileRelativePath);

            // Make sure the directory for the file exists.
            var projectSubFileDirectoryPath = Instances.PathOperator.GetDirectoryPathOfFilePath(subFilePath);

            Instances.FileSystemOperator.CreateDirectory(projectSubFileDirectoryPath);

            // Now modify the sub-file.
            var projectSubFilePathContext = new ProjectSubFilePathContext
            {
                FilePath = subFilePath,
                ProjectFileContext = projectFileWithSolutionFileContext,
                SolutionFileContext = projectFileWithSolutionFileContext.SolutionFileContext,
            };
            
            FunctionHelper.Run(projectSubFilePathContextAction, projectSubFilePathContext);
        }
    }
}