namespace Portfolio.Domain.Entities
{
    public class ProjectCategory
    {
        public ProjectCategory()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
