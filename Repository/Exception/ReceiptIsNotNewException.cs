using System;

namespace Repository.Exception
{
    public class ReceiptIsNotNewException : ApplicationException
    {
        public ReceiptIsNotNewException() : base("A seguinte entrada não pode ser mais alterada.")
        {
            
        }
    }
}