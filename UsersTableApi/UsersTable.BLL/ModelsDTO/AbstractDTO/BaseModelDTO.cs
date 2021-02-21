using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersTable.BLL.ModelsDTO.AbstractDTO
{
    public class BaseModelDTO
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
    }
}
