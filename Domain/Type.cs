using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WordsThatIKnowWebAPI.Domain
{
    public class Type
    {
        public TypeOfContent TypeOfContent { get; set; }
        public TypeOfDefinition TypeOfDefinition { get; set; }
    }

    public enum TypeOfContent
    {
        [EnumMember(Value = "WORD")]
        Word,

        [EnumMember(Value = "EXPRESSION")]
        Expression
    }

    public enum TypeOfDefinition
    {
        [EnumMember(Value = "NOUN")]
        Noun,

        [EnumMember(Value = "VERB")]
        Verb
    }

}
