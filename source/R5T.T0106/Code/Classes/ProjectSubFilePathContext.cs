using System;


namespace R5T.T0106
{
    public class ProjectSubFilePathContext : IProjectSubFilePathContext
    {
        public string FilePath { get; set; }
        public IProjectFileContext ProjectFileContext { get; set; }
        public ISolutionFileContext SolutionFileContext { get; set; }
    }
}
