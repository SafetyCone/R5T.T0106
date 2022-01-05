using System;

using R5T.T0105;


namespace R5T.T0106
{
    public interface ISolutionFileContext :
        IDirectoryPathContext,
        IFilePathContext,
        INameContext
    {
    }
}
