namespace DreamJob.Models
{
    public class Skill : DJDbBase
    {
        public Skill()
        { }

        public Skill(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}