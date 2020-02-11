from queue_alt import QueueAlt

### File: queue_text.py
class QueueText(object):
    def __init__(self):
        self.items = []

    def isEmpty(self):
        return self.items == []

    def enqueue(self, item):
        self.items.insert(0,item)

    def dequeue(self):
        return self.items.pop()

    def peek(self):
        return self.items[-1]

    def size(self):
        return len(self.items)

    def __str__(self):
        resultStr = "(rear)"
        for item in self.items:
            resultStr = str(item) + " " + resultStr
        resultStr = "(front) " + resultStr
        return resultStr
def main():
    myQ = QueueAlt()
    while True:
        print("\nQueue Tester Menu")
        print("e - enqueue")
        print("d - dequeue")
        print("p - peek")
        print("s - size")
        print("x - eXit")
        print("\nThe current queue is:", str(myQ))
        command = input("\nEnter your choice: ").lower()
        if command == 'e':
            item = input("Enter item to enqueue:")
            myQ.enqueue(item)
        elif command == 'd':
            item = myQ.dequeue()
            print("The dequeued item was:",item)
        elif command == 'p':
            item = myQ.peek()
            print("The front item from peek is:",item)
        elif command == 's':
            print("The size of the queue is:",myQ.size())
        elif command == 'x':
            break
        else:
            print("\nInvalid command only 'e', 'd', 'p', 's', 'x' are valid\n")
    
        
main()
