""" Lab 6 Starter File """

# PART A
def factorial(n):
    """ Recursive factorial function. """
    if n == 0:
        return 1
    else:
        return n*factorial(n-1)

def C(n,k):
    """ Calculates binomial coefficient from formula (2). """
    return (factorial(n))/((factorial(k))*(factorial(n-k)))

# PART B
def DC(n,k):
    """ Divide-and-Conquer recursive binomial coefficient (formula (3)). """
    if 1 <= k <= (n-1):
        return DC(n-1,k-1)+DC(n-1,k)
    elif k == 0 or k == n:
        return 1

# PART C
def DP(n, k):
    """ Dynamic Programming binomial coefficient using a list of lists to
        store rows of Pascal's triangle. """

    # Initial two rows of Pascal's triangle
    pascalsTriangle = [[1], [1,1]]

    for row in range (2,n+1) :
        nextRow = [1] # 1 in column 0

        # Inner for-loop to calculate the middle portion of the next row
        for c in range (1,row):
            nextRow.append(pascalsTriangle[-1][c] + pascalsTriangle[-1][c-1])

        nextRow.append(1)   # 1 along diagonal

        # Add nextRow to pascalsTriangle
        pascalsTriangle.append(nextRow)
        
    # COMPLETE THE RETURN STATEMENT BY RETURNING THE C(n, k) ITEM REQUESTED
    return pascalsTriangle([n][k])

# PART D - EXTRA CREDIT
def DP_Extra_Credit(n, k):
    """ Dynamic Programming binomial coefficient using two lists:
        binoCoeff - previous row of Pascal's triangle
        buildList - next row built from binoCoeff. """

    # Initial row of Pascal's triangle
    binoCoeff = [1]

    for row in range (1,n+1) :
        buildList = [1] # 1 in column 0

        for c in range (1,row):
            pass    # COMPLETE THIS LINE OF CODE

        buildList.append(1)   # 1 along diagonal

        # Remember new row as previous row
        binoCoeff = buildList
        
    # COMPLETE THE RETURN STATEMENT
    return 

print('C(28,14) ',C(28,14))
print('DC(28,14)',DC(28,14))
print('DP(28,14)',DP(28,14))
# print('DP_Extra_Credit(28,14)', DP_Extra_Credit(28,14))

