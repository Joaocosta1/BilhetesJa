using System;

namespace Repository.Exception
{
    public class ProductHasCompositionException : ApplicationException
    {
        public ProductHasCompositionException() : base("Produto com composição não pode ter composição.")
        {
            
        }
    }
}