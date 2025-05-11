namespace Entities.DataTransferObjects
{
    //TODO : BookDto oluşturduk. Aynnı properylere sahip ama ileride ilişkisel veri tabaanı olacak şekilde düşünelim ..
    //[Serializable]
    public record BookDto //ctrl + .
    {
        public int Id { get; init; }
        public String Title { get; init; }
        public decimal Price { get; init; }
    }
}
