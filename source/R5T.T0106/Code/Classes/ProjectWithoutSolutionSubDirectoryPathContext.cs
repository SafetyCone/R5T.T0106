using System;


namespace R5T.T0106
{
    public class ProjectWithoutSolutionSubDirectoryPathContext : IProjectWithoutSolutionSubDirectoryPathContext
    {
        public string DirectoryPath { get; set; }
        public IProjectFileContext ProjectFileContext { get; set; }
    }
}
