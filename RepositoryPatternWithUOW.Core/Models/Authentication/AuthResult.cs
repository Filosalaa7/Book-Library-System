using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models.Authentication
{
    public class AuthResult
    {
        public bool Succeeded { get; set; }

        public string[] ErrorList { get; set; } = [];
    }
}
