using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student : Person, IEntity
    {
        public int Id { get; set; }
        public Group Group{ get; set; }
    }
}
