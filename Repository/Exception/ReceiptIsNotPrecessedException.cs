using System;

namespace Repository.Exception
{
    public class ReceiptIsNotPrecessedException : ApplicationException
    {
        public ReceiptIsNotPrecessedException() : base("Entrada de mercadoria não pode ser cancelada.")
        {
            
        }
    }
}