using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgpromaWebAPI.Viewmodel
{
    public class CheckList
    {
        public int ChecklistId { get; set; }

        public int TaskId { get; set; }

        public string ChecklistName { get; set; }

        public bool Status { get; set; }

        public int PlannedSize { get; set; }

        public int RemainingSize { get; set; }

        public int CompletedSize { get; set; }

        public int ActualSize { get; set; }
        public int calculateDiff { get; set; }
    }
}
