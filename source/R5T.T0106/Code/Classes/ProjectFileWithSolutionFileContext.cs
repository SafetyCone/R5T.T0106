using System;


namespace R5T.T0106
{
    public class ProjectFileWithSolutionFileContext : IProjectFileContext, IWithSolutionFileContext
    {
        public string Name { get; set; }
        public string DirectoryPath { get; set; }
        public string FilePath { get; set; }

        public ISolutionFileContext SolutionFileContext { get; set; }
    }
}
