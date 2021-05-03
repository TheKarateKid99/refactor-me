using System;

namespace ProcessDelivery
{
    public class Book
    {
        //Making setter private so they become immutable and thus once the dates are passed in the values cannot be changed
        public Book(DateTime? lastReturnedDate, DateTime? lastDueDate, DateTime currentDueDate)
        {
            LastReturnedDate = lastReturnedDate;
            LastDueDate = lastDueDate;
            CurrentDueDate = currentDueDate;
        }
        public DateTime? LastReturnedDate { get; private set; }
        public DateTime? LastDueDate { get; private set; }
        public DateTime CurrentDueDate { get; private set; }
    }
}