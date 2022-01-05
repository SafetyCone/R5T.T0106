using System;

using R5T.T0106;

using Instances = R5T.T0106.X000.Instances;


namespace System
{
    public static class ProjectFileWithSolutionFileContextExtensions
    {
        public static void InProjectSubDirectoryPathContextSynchronous(this ProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
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

        public static void InProjectCodeDirectoryPathContextSynchronous(this ProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
            Action<ProjectSubDirectoryPathContext> projectSubDirectoryPathContextAction = default)
        {
            projectFileWithSolutionFileContext.InProjectSubDirectoryPathContextSynchronous(
                Instances.CodeDirectoryName.Code(),
                projectSubDirectoryPathContextAction);
        }

        public static void InProjectSubFilePathContextSynchronous(this ProjectFileWithSolutionFileContext projectFileWithSolutionFileContext,
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