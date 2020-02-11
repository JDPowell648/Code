from queue_alt import QueueAlt
import time

def main():
    n = 100000
    myQueue = QueueAlt()
    start = time.perf_counter()
    for count in range(n):
        myQueue.enqueue(count)

    end = time.perf_counter()
    print("Time to enqueue",n, "items to a QueueAlt was %.9f seconds" % (end-start))

    start = time.perf_counter()
    for count in range(n):
        temp = myQueue.dequeue()

    end = time.perf_counter()
    print("Time to dequeue",n, "items to a QueueAlt was %.9f seconds" % (end-start))

main()
input("Hit Enter to continue")
