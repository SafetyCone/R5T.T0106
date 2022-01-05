using System;

using R5T.T0037;
using R5T.T0041;
using R5T.T0044;


namespace R5T.T0106.X000
{
    public static class Instances
    {
        public static ICodeDirectoryName CodeDirectoryName { get; } = T0037.CodeDirectoryName.Instance;
        public static IFileSystemOperator FileSystemOperator { get; } = T0044.FileSystemOperator.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
    }
}
