namespace BlazorCMS.Shared.Domain
{
    public class BlogPost : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
