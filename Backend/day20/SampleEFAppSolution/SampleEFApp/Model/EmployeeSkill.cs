using System;
using System.Collections.Generic;

namespace SampleEFApp.Model
{
    public partial class EmployeeSkill
    {
        public int EmployeeId { get; set; }
        public int Skill { get; set; }
        public double? Skilllevel { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Skill SkillNavigation { get; set; } = null!;
    }
}
