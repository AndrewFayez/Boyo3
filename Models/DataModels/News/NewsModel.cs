using System.ComponentModel.DataAnnotations;

namespace BYO3WebAPI.Models.DataModels.PostModel
{
    public class NewsModel
    {

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
      
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserNews> UserNews { get; set; }

    }
}
