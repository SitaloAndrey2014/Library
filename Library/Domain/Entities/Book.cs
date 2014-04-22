namespace Domain.Entities
{
    public class Book
    {
        public int BookId { get; set;}//id книги
        public string Title { get; set;}// название
        public int AuthorId { get; set;}
        public string DisciplineId { get; set;}
        public int NumberOfPages { get; set;}
        public int NumberOfCopies { get; set;}
        public string Location { get; set;}
        public string ISBN { get; set;}
    }
}
