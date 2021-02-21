using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersTable.BLL.ModelsDTO.AbstractDTO;

namespace UsersTable.BLL.ModelsDTO
{
    public class UserDTO : BaseModelDTO
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

    }
}
