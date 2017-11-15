using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConcepts.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PositiveInteger : ValidationAttribute
    {
    }
}
