using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.Domain
{
    public class TypeOfContent
    {
        public Type Type { get; set; }
    }

    public enum Type
    {
        [EnumMember(Value = "WORD")]
        Word,

        [EnumMember(Value = "EXPRESSION")]
        Expression
    }


}
