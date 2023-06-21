namespace EmployeeCrudTeste.Models.Domain
{
    public class Category
    {
        public int Id { get; set; } //no migration foi como int. Mudei pra string pra usar o metodo 'Add' na controller
        public string Name { get; set; }
    }
}
