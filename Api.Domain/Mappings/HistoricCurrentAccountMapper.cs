namespace Api.Domain.Mappings
{
    public class HistoricCurrentAccountMapper
    {
        public class Description
        {
            public static MapperCharacter Deposit = new MapperCharacter() { Key = "D", Description = "Depósito" };
            public static MapperCharacter Payment = new MapperCharacter() { Key = "P", Description = "Pagamento" };
            public static MapperCharacter Transfer = new MapperCharacter() { Key = "T", Description = "Transferência" };
            public static MapperCharacter TransferReceived = new MapperCharacter() { Key = "X", Description = "Transferência recebida" };
            public static MapperCharacter Withdraw = new MapperCharacter() { Key = "W", Description = "Retirada" };
            public static MapperCharacter Yield = new MapperCharacter() { Key = "R", Description = "Rendimento" };
        }
    }
}
