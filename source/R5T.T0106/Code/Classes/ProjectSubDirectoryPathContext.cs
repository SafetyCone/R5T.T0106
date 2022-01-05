using System;


namespace R5T.T0106
{
    public class ProjectSubDirectoryPathContext : IProjectSubDirectoryPathContext
    {
        public string DirectoryPath { get; set; }
        public IProjectFileContext ProjectFileContext { get; set; }
        public ISolutionFileContext SolutionFileContext { get; set; }
    }
}
