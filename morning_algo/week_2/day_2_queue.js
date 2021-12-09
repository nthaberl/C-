/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    /**
     * The constructor is executed when instantiating a new Queue() to construct
     * a new instance.
     * @returns {Queue} This new Queue instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the back of the queue and returns the new size of the queue
     * - Time: O(?)
     * - Space: O(?)
     * @param {any} item - The item to be added to the back of the queue
     * @returns {number} The new size of the queue
     */
    enqueue(item) {
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes the item from the front of the queue
     * - Time: O(n)
     * - Space: O(?)
     * @returns {any} The removed item or undefined if the queue was empty
     */
    dequeue() {
        for (var i = 0; i < this.items.length -1; i++){
            let temp = this.items[i];
            this.items[i] = this.items[i + 1];
            this.items[i  +1] = temp;
        }
        return this.items.pop();
    }

    /**
     * Returns whether or not this queue is empty
     * - Time: O(?)
     * - Space: O(?)
     * @returns {boolean} Whether or not the queue is empty
     */
    isEmpty() {
        return this.items.length == 0;
    }

    /**
     * Returns the length of the queue
     * - Time: O(?)
     * - Space: O(?)
     * @returns {number} The length of the queue
     */
    size() {
        return this.items.length;
    }

    /**
     * Retrieves the item at the front of the queue without removing it.
     * - Time: O(?)
     * - Space: O(?)
     * @returns {any} The item at the front of the queue
     */
    front() {
        var front = this.items[0];
        return front;
    }
}

class Node {
    constructor(value) {
        this.data = value;
        this.next = null;
    }
}

/**
 * Class to represent a queue using a Linked List to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class LinkedListQueue {
    /**
     * The constructor is executed when instantiating a new LinkedListQueue() to construct
     * a new instance.
     * @returns {Queue} This new LinkedListQueue instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.head = null;
        this.tail = null;
        this.length = 0;
    }

    /**
     * Adds a new given item to the back of the queue and returns the new size of the queue
     * - Time: O(?)
     * - Space: O(?)
     * @param {any} item - The item to be added to the back of the queue
     * @returns {number} The new size of the queue
     */
    enqueue(item) {
        if(this.isEmpty()){
            this.head = new Node(item);
            this.tail = this.head;
            this.length += 1;
            return this.length;
        }
        this.tail.next = new Node(item);
        this.tail = this.tail.next;
        this.length++;
        return this.length;
    }

    /**
     * Removes the item from the front of the queue
     * - Time: O(?)
     * - Space: O(?)
     * @returns {any} The removed item or undefined if the queue was empty
     */
    dequeue() {
        if (this.isEmpty()){
            return null
        }
        let temp = this.head;
        this.head = this.head.next;
        this.length --;
        return temp;
        }

    /**
     * Returns whether or not this queue is empty
     * - Time: O(?)
     * - Space: O(?)
     * @returns {boolean} Whether or not the queue is empty
     */
    isEmpty() {
        return this.head == null;
    }

    /**
     * Returns the length of the queue
     * - Time: O(?)
     * - Space: O(?)
     * @returns {number} The length of the queue
     */
    size() {
        let current = this.head;
        let length = 0;
        while (current){
            length ++;
            current = current.next;
        }
        return length;
    }

/**
     * Retrieves the item at the front of the queue without removing it.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The item at the front of the queue
     */
 front() {
    // Gotta love ternary operators
    return this.head ? this.head.data : undefined;

    // The above line of code is just a shorthand for:
    if (this.head) {
        return this.head.data;
    } else {
        return undefined;
    }

    //    front() {
        if (this.isEmpty()){
            return null
        }
        return this.head.data;
}

/**
 * Compares this queue to another given queue to see if they are equal.
 * Avoid indexing the queue items directly via bracket notation, use the
 * queue methods instead for practice.
 * Use no extra array or objects.
 * The queues should be returned to their original order when done.
 * - Time: O(?).
 * - Space: O(?).
 * @param {Queue} q2 The queue to be compared against this queue.
 * @returns {boolean} Whether all the items of the two queues are equal and
 *    in the same order.
 */
// compareQueues(q2) { 
//     let thisLength = this.size();
//     let q2Length = q2.size();

//     if (thisLength != q2Length){
//         return false;
//     }

//     while (counter < thisLength){
//         let thisData = this.dequeue();
//         let q2Data = q2.dequeue();
//     }
// }

compareQueues(q2) { 
/*
    Steps:
        1. Find the length of both this queue and q2
        2. Right away, if they're different lengths, return false
        3. Set a flag to true
        4. For each queue, one node at a time (up to the length), dequeue, 
            compare, and enqueue again. If the data isn't the same, 
            set our flag to false.
        5. After you've done it length number of times, it's in the
            same order, so return the flag.
*/

    let thisLength = this.size();
    let q2Length = q2.size();

    if(thisLength != q2Length) {
        return false;
    }

    let counter = 0;
    let isTheSame = true;

    while(counter < thisLength) {
        let thisData = this.dequeue();
        let thatData = q2.dequeue();

        if(thisData != thatData) {
            isTheSame = false;
        }
        this.enqueue(thisData);
        q2.enqueue(thatData);

        counter++;
    }

    return isTheSame;
}


/**
 * Determines if the queue is a palindrome (same items forward and backwards).
 * Avoid indexing queue items directly via bracket notation, instead use the
 * queue methods for practice.
 * Use only 1 stack as additional storage, no other arrays or objects.
 * The queue should be returned to its original order when done.
 * - Time: O(?).
 * - Space: O(?).
 * @returns {boolean}

 */
// isPalindrome() {
//     if(this.isEmpty() || this.length == 1){
//         return true
//     }
//     let stackCompare = new LinkedListStack()
//     for(let i = 0; i < this.length; i ++){
//         stackCompare.push(this.front())
//         this.enqueue(this.dequeue())
//     }
//     let bool = true
//     for(let i = 0; i < this.length; i ++){
//         if(this.front() != stackCompare.pop()){
//             bool = false
//         }
//         this.enqueue(this.dequeue())
//     }
//     return bool
//     }

isPalindrome() { 
/*
    Steps:
        1. Create a stack
        2. One node at a time, dequeue an item, push it to the stack,
            then re-enqueue it, until the queue and stack have the
            same size.
        3. At this point, the queue and stack contain the same data,
            but in opposite orders.
        4. Until the stack is empty, pop from the stack, dequeue from the 
            queue, compare each value, then re-enqueue (throw away the stack one).
        5. If each item from the queue and stack are equal, it's a palindrome.
*/
    // create stack
    let reverseQueue = new LinkedListStack();
    let isPal = true;

    while(reverseQueue.size() != this.size()) {
        let removedQueue = this.dequeue();
        let removedStack = reverseQueue.pop();
        if(removedQueue != removedStack) {
            isPal = false;
        }
        this.enqueue(removedQueue);
    }

    return isPal;
}

toArr() {
    const array = [];
    let runner = this.head;

    while (runner) {
        array.push(runner.data);
        runner = runner.next;
    }
    return array;
}

/**
     * Determines whether the sum of the left half of the queue items is equal to
     * the sum of the right half. Avoid indexing the queue items directly via
     * bracket notation, and avoid iterating through using a runner. Instead, use the queue 
     * methods for practice. Use no extra array or objects.
     * The queue should be returned to its original order when done.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean} Whether the sum of the left and right halves is equal.
     */
isSumOfHalvesEqual() { 
    if(this.isEmpty() || this.length == 1){
        return false
        }
    }
}
