using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_LMS.Shared.Domain
{
    public class UserListDTO
    {
        public ICollection<UserDTO> ListOfUsers { get; set; } = new List<UserDTO>();
    }
}
