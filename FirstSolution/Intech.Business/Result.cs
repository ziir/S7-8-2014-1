using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.Business
{
    public class Result
    {
        public int TotalFileCount { get; set; }

        public int TotalDirectoryCount { get; set; }

        public int HiddenFileCount { get; set; }

        public int HiddenDirectoryCount { get; set; }

        public int UnaccessibleFileCount { get; set; }
    }
}
