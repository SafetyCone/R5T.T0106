using System;


namespace R5T.T0106
{
    public class LocalRepositoryContext : ILocalRepositoryContext
    {
        public string DirectoryPath { get; set; }
        public string Name { get; set; }
    }
}
