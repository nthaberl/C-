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
     * - Time: O(?)
     * - Space: O(?)
     * @returns {any} The item at the front of the queue
     */
    front() {
        if (this.isEmpty()){
            return null
        }
        return this.head.data;
    }
}