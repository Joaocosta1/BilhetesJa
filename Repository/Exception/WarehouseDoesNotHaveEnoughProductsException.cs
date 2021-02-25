using System;

namespace Repository.Exception
{
    public class WarehouseDoesNotHaveEnoughProductsException : ApplicationException
    {
        public WarehouseDoesNotHaveEnoughProductsException() : base("Almoxarifado não possui estoque o suficiente para realizar a operação.")
        {
            
        }
    }
}