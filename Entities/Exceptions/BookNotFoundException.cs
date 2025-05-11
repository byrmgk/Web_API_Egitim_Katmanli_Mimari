namespace Entities.Exceptions
{
    //TODO:  sealed class kalıtım alınmasını engeller.
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"{id} ye sahip kitap bulunamadı !!!")
        {

        }
    }
}
