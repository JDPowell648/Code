
def fib(n):
    """ Recursive divide-and-conquer algorithm. """
    if n == 0:
        return 0
    elif n == 1:
        return 1
    else:
        return fib(n-1) + fib(n-2)
    

def fib_DP(n):
    """Dynamic programming solution to find the nth number in the Fibonacci seq."""

    # List to hold the solutions to the smaller problems
    fibonacci = []

    # Step 1:  Store base case solutions
    fibonacci.append(0)
    fibonacci.append(1)

    # Step 2:  Loop from base cases to biggest problem of interest  
    for position in range(2, n+1):
        fibonacci.append(fibonacci[position-1] + fibonacci[position-2])

    # return nth number in the Fibonacci sequence
    return fibonacci[n]

def fib_DP2(n):
    """Dynamic programming solution to find the nth number in the Fibonacci seq.
       that uses minimal storage."""
    if n <= 1:
        return n
    else:
        previous = 0
        current = 1
        for position in range(2,n+1):
            next = current + previous
            previous = current
            current = next

        return next





        
