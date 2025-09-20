namespace Portfolio.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }      
        public string Technologies { get; set; }
        public string RepositoryLink { get; set; }
        public string? LiveDemoLink { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProjectCategoryId { get; set; } 
        public ProjectCategory ProjectCategory { get; set; }
    }
}
