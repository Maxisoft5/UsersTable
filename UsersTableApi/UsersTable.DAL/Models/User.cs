using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.DAL.Models.Abstract;

namespace UsersTable.DAL.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}