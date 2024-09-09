using System;
using System.Collections.Generic;


public class CheckoutQueue
{
    // private field of type Queue<string> to store customers in the queue
    private Queue<string> queue;

    // constructor
    public CheckoutQueue()
    {
        queue = new Queue<string>();
    }

    // method for customers to join the queue
    public void GoToQueue(string customerName)
    {
        // enqueue the customer into the queue
        queue.Enqueue(customerName);
        // print a message indicating the customer has joined the queue
        Console.WriteLine($"{customerName} joined the queue.");
    }

    // method for customers to exit the queue
    public void ExitQueue()
    {
        // check if the queue is empty
        if (queue.Count == 0)
        {
            // print a message if the queue is empty
            Console.WriteLine("The queue is empty.");
        }
        else
        {
            // dequeue the customer from the front of the queue
            string exitedCustomer = queue.Dequeue();
            // print a message indicating the customer has exited the queue
            Console.WriteLine($"{exitedCustomer} exited the queue.");
        }
    }

    // property to get the current length of the queue
    public int Length
    {
        get { return queue.Count; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // creating an instance of the CheckoutQueue class
        CheckoutQueue checkoutQueue = new CheckoutQueue();

        // adding customers to the queue
        checkoutQueue.GoToQueue("Customer 1");
        checkoutQueue.GoToQueue("Customer 2");
        checkoutQueue.GoToQueue("Customer 3");

        // current length of the queue
        Console.WriteLine($"Queue Length: {checkoutQueue.Length}");

        // customers exit the queue
        checkoutQueue.ExitQueue();
        checkoutQueue.ExitQueue();
        checkoutQueue.ExitQueue();
        checkoutQueue.ExitQueue(); // trying to exit an empty queue

        // display the current length of the queue
        Console.WriteLine($"Queue Length: {checkoutQueue.Length}");
    }
}
