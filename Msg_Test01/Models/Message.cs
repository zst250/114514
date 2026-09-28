using System.ComponentModel.DataAnnotations;

namespace Msg_Test01.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "名字不能为空")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "留言不能为空")]
        public string Content { get; set; } = "";
        public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
