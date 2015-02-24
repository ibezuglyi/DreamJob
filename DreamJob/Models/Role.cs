namespace DreamJob.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("webpages_Roles")]
    public class Role
    {
        public Role()
        {
            this.UsersInRoles = new List<UsersInRole>();
        }

        [Key]
        public int RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; }

        [ForeignKey("RoleId")]
        public ICollection<UsersInRole> UsersInRoles { get; set; }
    }
}