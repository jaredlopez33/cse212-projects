using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities to the queue and dequeue them.
    // Expected Result: Items are returned in order of highest priority first (10, 5, 1), fulfilling requirements 1 and 2.
    // Defect(s) Found: The loop missed the last element (using index < Count - 1 instead of Count), used >= instead of >
    //  which corrupted priority comparison, and omitted removing the item from the queue list. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    
    // Scenario: Add multiple items with the same highest priority level to test FIFO tie-breaking behavior.
    // Expected Result: The item closest to the front of the queue is removed first among equals ("FirstHigh" before "SecondHigh"), fulfilling requirement 3.
    // Defect(s) Found: Using >= caused the last item added with the same priority to be chosen instead of the first one, violating FIFO order for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 10);
        priorityQueue.Enqueue("Low", 2);
        priorityQueue.Enqueue("SecondHigh", 10);
        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the exact message "The queue is empty.", fulfilling requirement 4.
    // Defect(s) Found: None (handled properly by the base check).
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}