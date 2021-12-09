/**
 * Class to represent a stack using an array to store the stacked items.
 * Follows a LIFO (Last In First Out) order where new items are stacked on
 * top (back of array) and removed items are removed from the top / back.
 */
class Stack {
    /**
     * The constructor is executed when instantiating a new Stack() to construct
     * a new instance.
     * @returns {Stack} This new Stack instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the top / back of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to be added to the top / back.
     * @returns {number} The new length of this stack.
     */
    push(item) { 
        // this.items is the array representing our stack, and so we can use the array's
        // built in push command
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes the top / last item from this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item or undefined if this stack was empty.
     */
    pop() { 
        return this.items.pop();
    }

    /**
     * Retrieves the top / last item from this stack without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The top / last item of this stack.
     */
    peek() { 
        return this.items[this.items.length - 1];
    }




    /**
     * Returns whether or not this stack is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() { 
        return this.items.length == 0;
    }

    /**
     * Returns the size of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() { 
        return this.items.length;
    }
}

class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

// NOW IT'S YOUR TURN!!
class LinkedListStack {
    constructor() {
        this.head = null;
    }

    /**
     * Adds a new given item to the top / back of this stack.
     * - Time: O(n) - Linear, because we're traversing to the back of the stack to find the length
     * - Space: O(1) - Constant
     * @param {any} item The new item to be added to the top / back.
     * @returns {number} The new length of this stack.
     */
    push(item) { 
        let newTopOfStack = new Node(item);

        newTopOfStack.next = this.head;
        this.head = newTopOfStack;

        return this.length();
    }

    /**
     * Removes the top / last item from this stack.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The removed item or null if this stack was empty.
     */
    pop() { 
        if(this.isEmpty()) {
            return null;
        }

        let removedItem = this.head;
        this.head = removedItem.next;

        return removedItem.data;
    }

    /**
     * Retrieves the top / last item from this stack without removing it.
     * - Time: O(1) - Linear
     * - Space: O(1) - Constant
     * @returns {any} The top / last item of this stack or null if empty.
     */
    peek() { 
        return this.head ? this.head.data : null; // OH HOW FANCY
    }

    /**
     * Returns whether or not this stack is empty.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {boolean}
     */
    isEmpty() { 
        return this.head == null;
    }

    /**
     * Returns the size of this stack.
     * - Time: O(n) - Linear
     * - Space: O(1) - Constant
     * @returns {number} The length.
     */
    size() { 
        let runner = this.head;
        let length = 0;
        while(runner) {
            length++;
            runner = runner.next;
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
compareQueues(q2) { 
    let thisLength = this.size();
    let q2Length = q2.size();

    if (thisLength != q2Length){
        return false;
    }

    while (counter < thisLength){
        let thisData = this.dequeue();
        let q2Data = q2.dequeue();
    }
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
isPalindrome() {
    if(this.isEmpty() || this.length == 1){
        return true
    }
    let stackCompare = new LinkedListStack()
    for(let i = 0; i < this.length; i ++){
        stackCompare.push(this.front())
        this.enqueue(this.dequeue())
    }
    let bool = true
    for(let i = 0; i < this.length; i ++){
        if(this.front() != stackCompare.pop()){
            bool = false
        }
        this.enqueue(this.dequeue())
    }
    return bool
    }

    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}

