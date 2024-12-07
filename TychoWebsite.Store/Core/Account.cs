namespace TychoWebsite.Store.Core;

internal class Account(int id, decimal balance)
{
    public int Id { get; private set; } = id;

    public decimal Balance { get; private set; } = balance;

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}