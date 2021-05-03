using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessDelivery
{
    public interface ILibraryManager
    {
        string ReturnBook(Book book, DateTime dateReturned);
    }
}
