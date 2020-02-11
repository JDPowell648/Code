package banking;

public class BankDriver
{
    public static void main( String[] args )
    {
        BankAccount account = new BankAccount( 0 );

        Thread t1 = new Thread( new Runnable() {
            public void run( ) {
                for( int i = 0; i < 1000; i++ )
                {
                    try
                    {
                        account.adjustBalance(1);
                    }
                    catch (EmptyAccountBalanceException e)
                    {
                        System.out.println( e.getStackTrace( ) );
                    }
                }
            }
        });

        Thread t2 = new Thread( new Runnable() {
            public void run( ) {
                for( int i = 0; i < 1000; i++ )
                {
                    try
                    {
                        account.adjustBalance(1);
                    }
                    catch (EmptyAccountBalanceException e)
                    {
                        System.out.println( e.getStackTrace( ) );
                    }
                }
            }
        });

        t1.start( );
        t2.start( );


        try
        {
            // t1.join() will 'hold' this thread until t1 is done executing
            t1.join();
            t2.join();
        } catch (InterruptedException e)
        {
            System.out.println( e );
        }

        System.out.println( "Total Balance: " + account.getBalance( ) );
    }
}
