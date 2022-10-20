using System;
using System.Collections.Generic;

namespace AdhocDesignerSample.ViewModels
{
    public class IndexViewModel
    {

        public IEnumerable<string> ProjectsFromFileSystem { get; set; }

        public IEnumerable<Tuple<int,string>>  ProjectsFromRepository { get; set; }

    }
}