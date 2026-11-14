using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Abstractions.Enums
{
    public enum UserRoleType
    {
        // cross-Domain 1-9
        [Description("Editorial Office")]
        EOF = 1,

        // Submission Domain 11 -19
        [Description("Author")]
        Author = 11,


        [Description("Corresponding Author")]
        CORAUT = 12


    }
}
