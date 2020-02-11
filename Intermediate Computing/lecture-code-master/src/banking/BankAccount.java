package banking;

public class BankAccount
{
    private int totalBalance;
    private int accountNumber;

    private static int accountCount = 0;

    public BankAccount( int startingBalance )
    {
        totalBalance = startingBalance;
        accountNumber = accountCount++;
    }

    public synchronized void adjustBalance( int amount )
            throws EmptyAccountBalanceException
    {
        if( totalBalance + amount < 0 )
        {
            throw new EmptyAccountBalanceException( );
        }
        totalBalance = totalBalance + amount;
    }

    public int getBalance( )
    {
        return totalBalance;
    }

    public int getAccountNumber( )
    {
        return accountNumber;
    }
}
