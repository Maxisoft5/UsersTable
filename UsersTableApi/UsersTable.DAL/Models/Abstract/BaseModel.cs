using System;
using System.Collections.Generic;
using System.Text;

namespace UsersTable.DAL.Models.Abstract
{
    public class BaseModel
    {
        public int Id { get; set; }
        public Guid PublicId { get; init; } = Guid.NewGuid();

    }
}
