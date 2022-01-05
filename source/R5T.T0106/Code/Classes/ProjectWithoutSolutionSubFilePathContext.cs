using System;


namespace R5T.T0106
{
    public class ProjectWithoutSolutionSubFilePathContext : IProjectWithoutSolutionSubFilePathContext
    {
        public string FilePath { get; set; }
        public IProjectFileContext ProjectFileContext { get; set; }
    }
}
