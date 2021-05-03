using ProcessDelivery.Common;
using System;

namespace ProcessDelivery
{
    public class LibraryManager : ILibraryManager
    {
        public LibraryManager()
        {
                
        }

        public string ReturnBook(Book book, DateTime dateReturned)
        {
            try
            {
                return RiksValidatorV2.ReturnRiskValidator(book, dateReturned);
            }
            catch(Exception ex)
            {
                return $"Exception occured: {ex.Message}";
            }
        }

    }
}
