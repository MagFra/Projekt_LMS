﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lexicon_LMS.Shared.Domain.AssignmetsDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Shared.Domain.ActivitiesDTOs
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int LengthDays { get; set; }


        // Foreign key
        public int ModuleId { get; set; }


        // Navigation property
        public ModuleDTO? Module { get; set; } = null!;
        public ICollection<AssignmentDTO>? ListOfAssignments { get; set; } = null!;
    }
}
