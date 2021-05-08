using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Web.Models
{
    public class ChatViewModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
