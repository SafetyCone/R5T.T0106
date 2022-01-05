using System;

using R5T.T0105;


namespace R5T.T0106
{
    /// <summary>
    /// Directory path with only project file context.
    /// </summary>
    public interface IProjectWithoutSolutionSubDirectoryPathContext :
        IDirectoryPathContext,
        IWithProjectFileContext
    {
    }
}
