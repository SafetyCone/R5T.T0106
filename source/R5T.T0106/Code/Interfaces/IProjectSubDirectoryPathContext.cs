using System;

using R5T.T0105;


namespace R5T.T0106
{
    /// <summary>
    /// By default, with project and solution file contexts.
    /// Other -Without contexts can be created to obmit project and/or solution file contexts.
    /// </summary>
    public interface IProjectSubDirectoryPathContext :
        IDirectoryPathContext,
        IWithSolutionFileContext,
        IWithProjectFileContext
    {
    }
}
