from queue_text import QueueText
import time

def main():
    n = 100000
    myQueue = QueueText()
    start = time.perf_counter()
    for count in range(n):
        myQueue.enqueue(count)

    end = time.perf_counter()
    print("Time to enqueue",n, "items to a QueueText was %.9f seconds" % (end-start))

    start = time.perf_counter()
    for count in range(n):
        temp = myQueue.dequeue()

    end = time.perf_counter()
    print("Time to dequeue",n, "items to a QueueText was %.9f seconds" % (end-start))

main()
input("Hit Enter to continue")
