from ordered_linked_list import OrderedList

def main():
    myList = OrderedList()
    while True:
        print("\nOrdered List Tester Menu")
        print("a - add")
        print("r - remove(item)")
        print("i - index(item)")
        print("p - pop()")
        print("pp - pop(position)")
        print("s - search(item)")
        print("l - length")
        print("x - eXit")
        print("\nThe current list is:", str(myList))
        command = input("\nEnter your choice: ").lower()
        if command == 'a':
            item = input("Enter item to add: ")
            myList.add(item)
        elif command == 'r':
            item = input("Enter item to remove from list")
            myList.remove(item)
        elif command == 'i':
            item = input("Enter item to determine index")
            index = myList.index(item)
            print("The item is at index:",index)
        elif command == 'p':
            item = myList.pop()
            print("The item popped from the tail was:",item)
        elif command == 'pp':
            index = eval(input("Enter index to pop from:"))
            item = myList.pop(index)
            print("The item popped from the index was:",item)
        elif command == 's':
            item = input("Enter item to search for ")
            found = myList.search(item)
            print("The item search result:",found)
        elif command == 'l':
            print("The length of the list is:",myList.length())
        elif command == 'x':
            break
        else:
            print("\nInvalid command only 'a', 'r', 'i', 'p', 'pp', 's', 'l', 'x' are valid\n")
    
        
main()
