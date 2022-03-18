
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab05.Models
{
    public class AnswerImage
    {

        public enum Question
        {
            Earth, Computer
        }

        public int AnswerImageId
        {
            get; 
            set; 
        }

        [Required]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Required]
        [DisplayName("URL")]
        public string Url { get; set; }
    }
}
