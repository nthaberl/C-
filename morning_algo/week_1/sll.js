/**
 * Class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class Node {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {Node} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
    this.data = data;
    /**
       * This property is used to link this node to whichever node is next
       * in the list. By default, this new node is not linked to any other
       * nodes, so the setting / updating of this property will happen sometime
       * after this node is created.
       */
    this.next = null;
}
}

/**
   * Class to represent a list of linked nodes. Nodes CAN be linked together
   * without this class to form a linked list, but this class helps by providing
   * a place to keep track of the start node (head) of the list at all times and
   * as a place to add methods (functions inside an object) so that every new
   * linked list that is instantiated will inherit helpful the same helpful
   * methods, just like every array you create inherits helpful methods.
   */
class SinglyLinkedList {
/**
 * Constructs a new instance of an empty linked list that inherits all the
 * methods.
 * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
 *    returned without having to explicitly write "return".
 */
constructor() {
    this.head = null;
}

    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}

     */
    isEmpty() { 
        if (this.head == null){
            return true
        }
    else{
    return false;
    }
}

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
     */
//     insertAtBack(data) { 
//         if (this.isEmpty()){
//             this.head = new Node(data);
//         }
//         else{
//             var runner = this.head
//             while (runner.next !== null){
//                 runner = runner.next
//             }
//             runner.next = new Node(data)
//         }
//         return this
// }


insertAtBack(data){
    let node = new Node(data);
    let current;

    //if empty make head
    if(!this.head){
        this.head = node;
    }
    else{
        current = this.head;
        while (current.next){
            current = current.next;
        }
        current.next = node;
    }

}

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    seedFromArr(vals) {
    for (const item of vals) {
        this.insertAtBack(item);
    }
    return this;
}

    /**
     * Converts this list into an array containing the data of each node.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
     */

    toArr() {
    const arr = [];
    let runner = this.head;

    while (runner) {
    arr.push(runner.data);
    runner = runner.next;
    }
    return arr;
}

    /**
     * Creates a new node with the given data and inserts that node at the front
     * of this list.
     * - Time: (?).
     * - Space: (?).
     * @param {any} data The data for the new node.
     * @returns {SinglyLinkedList} This list.
     */
    //uses a temp variable and swaps them out
    // insertAtFront(data) {
    //     if (this.isEmpty()){
    //         this.head = new Node(data);
    //     }
    //     let temp = this.head;
    //     this.head = new Node(data);
    //     this.head.next = temp;
    //     return this;
    // }

    //OR
    //more clearcut approach
    insertAtFront(data) {
        var newHead = new Node(data);
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }

    //Insert value at an index
    insertAtIndex(data, index){
        // if (index > 0){
        //     return;
        // }

        //if first index
        // if (index === 0){
        //     this.head = new Node (data, this.head);
        //     return;
        // }

        //create new node
        const node = new Node (data);
        let current, previous;

        //set current to first
        current = this.head;
        let count = 0;

        while (count < index) {
            previous = current; //node before index we're inserting
            count ++;
            current = current.next; //node after index
        }

        node.next = current;
        previous.next = node;
    }


    //Get data at an index
    getAt(index){
        let current = this.head;
        let count = 0;

        while (current){
            if (count === index){
                console.log(current.data);
            }
            count ++;
            current = current.next;
        }

        return null;
    }

    /**
    * Removes the first node of this list.
    * - Time: (?).
    * - Space: (?).
    * @returns {any} The data from the removed node.
    */
    // removeHead() {
    //     if(this.head != null){
    //         this.head = this.head.next
    //     }
    //     return this
    // }

    removeHead(){
        //guard clause, can do an if/else or do an early return
        if (this.isEmpty()){
            return null;
        }

        const oldHead = this.head;
        this.head = oldHead.next;
        oldHead.next = null;
        return oldHead.data;
    }


    // EXTRA
    /**
    * Calculates the average of this list.
    * - Time: (?).
    * - Space: (?).
    * @returns {number|NaN} The average of the node's data.
    */
//     average() {
//         var sum = 0;
//         var length = 0;
//         let runner = this.head;
//     while (runner.next !=null) {
//         sum += runner.data
//         length+=1
//         runner = runner.next
//     }
//     sum += runner.data
//     length += 1
//     return (sum/length)
//     }
// }

average() {
    let sum = 0;
    let count = 0;
    let runner = this.head;

    while (runner) {
        sum += runner.data;
        count++;
        runner = runner.next;
    }

    return sum / count;
}

/**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed.
     */
// removeBack() { 
//     if (this.isEmpty() || this.head.next == null){
//         return null;
//     }
//     runner = this.head;
//     while (runner.next != null){
//         Node.data = Node.data.next;
//     }

//     return head
// }

removeBack() {
    /**
     * Edge Cases:
     *  - What if the list is empty?
     *  - What if the list only contains one element?
     */
    if (this.isEmpty()) {
        // well then, there's nothing to remove, so return null
        return null;
    } else if (this.head.next == null) {
        /**
         * If the list only contains 1 node, we just want to set the head to null,
         * and return the data in what we just chopped off. So first, let's store that 
         * node in a variable
         */
        const removed = this.head;
        // Then, set the head to null
        this.head = null;
        // And return the removed node's data
        return removed.data;
    } else {
        // If neither edge case was met, we need to start our runner at the head
        let runner = this.head;
        /**
         * How can we make our runner stop at the second to last node? Well, we have 2 
         * main options:
         *  1. Continue to move the runner as long as the runner's next node has a next node
         *  2. Make a second runner that'll lag one behind ur main runner, and stop once runner
         *    is at the last node
         * 
         * Because I'll be needing to hold onto the last node's value for our return statement,
         * I'll use option two
         */
        let walker = null; // Starting this at null because there's nothing before the head of the list

        while (runner.next) {
            walker = runner; // Set walker to be the node runner is referencing before moving runner forward
            runner = runner.next;
        }

        /**
         * Once we've broken out of the while loop, it means that runner is
         * situated at the last node, and walker is at the second to last.
         * 
         * So we'll remove walker's reference to runner (set .next to null)
         * and return runner's data
        */
        walker.next = null;
        return runner.data;
    }
}


removeAt(index){
    let current = this.head;
    let previous;
    let count = 0;

    //remove if only head
    if (index === 0){
        this.removeHead()
    }
    else {
        while (count < index){
            count ++;
            previous = current;
            current = current.next;
        }

        previous.next = current.next;
    }
}


clearList(){
    this.head = null;
}

/**
  * Determines whether or not the given search value exists in this list.
  * - Time: O(?).
  * - Space: O(?).
  * @param {any} val The data to search for in the nodes of this list.
  * @returns {boolean}

  */
contains(val) { 
    // checks to see if list is empty
    if(this.head == null){
        return false
    }
    let runner = this.head
    while(runner != null){
        if (runner.data == val){
            return true
        }
        runner = runner.next
    }
    return false
}

/**
  * Determines whether or not the given search value exists in this list.
  * - Time: O(?).
  * - Space: O(?).
  * @param {any} val The data to search for in the nodes of this list.
  * @param {?node} current The current node during the traversal of this list
  *    or null when the end of the list has been reached.
  * @returns {boolean}

  */
containsRecursive(val, current = this.head) { 
    if (current == null){
        return false;
    }
    else if (current.data == val){
        return true;
    }
    else{
        return this.containsRecursive(val, current = current.next)
    }
}

printListData() {
    let current = this.head;

    while(current){
        console.log(current.data);
        current = current.next;
    }
}

// EXTRA
/**
  * Recursively finds the maximum integer data of the nodes in this list.
  * - Time: O(?).
  * - Space: O(?).
  * @param {Node} runner The start or current node during traversal, or null
  *    when the end of the list is reached.
  * @param {Node} maxNode Keeps track of the node that contains the current
  *    max integer as it's data.
  * @returns {?number} The max int or null if none.
  */

recursiveMax(runner = this.head, maxNode = this.head) { 
        // BASE CASE: runner has reached null
        if(runner == null) {
            // EDGE CASE: if runner is null because the list is empty
            if(maxNode == null) {
                // return null
                return null;
            } else {
                // otherwise, it reached null because it reached the end, so return maxNode's data
                return maxNode.data
            }
        }

        /**
         * If we haven't fallen into our base case, then we need to check if the runner's data
         * is larger than our maxNode's data
         */
        if(runner.data > maxNode.data) {
            // if it is, set maxNode to be the runner
            maxNode = runner;
        }
        /**
         * RECURSIVE CALL:
         * We've checked our node's value against our maxNode, so it's on
         * to the next! Recursively!
         * 
         * Dive deeper into our function-ception, where the next call's runner
         * will be this call's runner's next, and maxNode is whatever maxNode is
         * at this point
         */
        return this.recursiveMax(runner.next, maxNode);
    }


/**
     * Retrieves the data of the second to last node in this list.
     * - Time: O(n) linear since the number of iterations is related to how many nodes are in the list
     * - Space: O(1) constant, because regardless of size..
     * @returns {any} The data of the second to last node or null if there is no
     *    second to last node.
    */

secondToLast(){ 
    // * Edge Cases:
    // *  - What if the list is empty?
    // *  - What if the list only contains one element?
    // */
    if (this.isEmpty() || this.head.next == null) {
        //empty list returns null
        return null;
    } 
    else {
        // If neither edge case was met, we need to start our runner at the head
        let runner = this.head;
        while (runner.next.next) {
         // Set walker to be the node runner is referencing before moving runner forward
            runner = runner.next;
        }
        // /**
        // * Once we've broken out of the while loop, it means that runner is
        // * situated at the second to last node.
        return runner.data;
    }
}

/**
 * Removes the node that has the matching given val as it's data.
 * - Time: O(n).
 * - Space: O(1) constant, size of list has no impact on amount of memory used.
 * @param {any} val The value to compare to the node's data to find the
 *    node to be removed.
 * @returns {boolean} Indicates if a node was removed or not.
 */
removeVal(val) { 
    if (this.head.data == val){
        this.removeHead();
        return true;
    }
    let runner = this.head;
    while(runner){
        if (runner.next.data == val){
            runner.next == runner.next.next;
            return true;
        }
        else {
            runner = runner.next
        }
    }
    return false
}

// EXTRA
    /**
     * Inserts a new node before a node that has the given value as its data.
     * - Time: O(n) - Linear: worst case scenario is what we use, and worst case
     *      is that the node to prepend to is the last one or doesn't exist, meaning
     *      we would check each of the n nodes once.
     * - Space: O(1) - Constant, because the amount of variables/size of the data structures
     *      declared does not change based on the size of the list.
     * @param {any} newVal The value to use for the new node that is being added.
     * @param {any} targetVal The value to use to find the node that the newVal
     *    should be inserted in front of.
     * @returns {boolean} To indicate whether the node was pre-pended or not.
     */

    prepend(newVal, targetVal) { 
        // THIS ONE IS JUICY

        // EDGE CASE: targetVal is our first node??
        if(this.head.data == targetVal) {
            // Well, prepending to the first node is just adding to the front, right? RIGHT!
            this.insertAtFront(newVal);
            return true;
        }

        /*
            Ok, back to our scheduled programming.
            If our SLL looks like THIS:
            H
            1 -> 2 -> 4 -> 5 -> 6 -> 
            And we call prepend(3,4)
            We need to make THIS:
            H
            1 -> 2 -> 4 -> 5 -> 6 -> 
            Look like THIS:
            H
            1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 
            So, similar to our removeVal, I'll be using a runner, but 
            checking its .next
        */
        let runner = this.head;

        while(runner.next) {
            // We need to check the next node's data against targetVal
            if(runner.next.data == targetVal) {
                // Well golly shucks dang, we found a match! Ok cool, now what?
                // We need to create our new node (duh)
                let newNode = new Node(newVal);

                // Assign its .next to the node we want to prepend to (aka runner.next)
                newNode.next = runner.next;

                /*
                    But, right now, our list looks something like this:
                .             3
                    H         ↓ (don't ask how I got that arrow in there)
                    1 -> 2 -> 4 -> 5 -> 6 ->
                .        r
                    We need that 2 node to point at the 3 node. Oh wait! That's our runner!
                */
                runner.next = newNode;
                /*
                    And now, our list is:
                    H
                    1 -> 2 -> 3 -> 4 -> 5 -> 6 ->
                */
                return true;
            }
            // And if the next node ISN'T supposed to be prepended to?
            runner = runner.next;
        }
        // Again, making it out of the loop means we never found our prependable node
        return false;
    }

/**
     * Concatenates the nodes of a given list onto the back of this list.
     * - Time: O(n+m).
     * - Space: O(?).
     * @param {SinglyLinkedList} addList An instance of a different list whose
     *    whose nodes will be added to the back of this list.
     * @returns {SinglyLinkedList} This list with the added nodes.
     */
concat(addList) { 
    //dont need to check if addList is empty, because it'll be null, then just add null to the end
    if(this.head == null){
        this.head = addList.head;
    }
    let runner = this.head;
    while(runner.next != null){
        runner = runner.next;
    }
    runner.next = addList.head
    return this;

}

/**
 * Finds the node with the smallest number as data and moves it to the front
 * of this list.
 * - Time: O(?).
 * - Space: O(?).
 * @returns {SinglyLinkedList} This list.
 */
moveMinToFront() { 
    if (this.head === null){
        return false
    }
    if (this.head.next < this.head){

    }

}

// EXTRA
/**
 * Splits this list into two lists where the 2nd list starts with the node
 * that has the given value.
 * splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3)
 * and the return value will be a new list containing (5=>2=>4)
 * - Time: O(?).
 * - Space: O(?).
 * @param {any} val The value in the node that the list should be split on.
 * @returns {SinglyLinkedList} The split list containing the nodes that are
 *    no longer in this list.
 */
splitOnVal(val) {
    if (val == this.contains(val)){

    }
}

}

// const emptyList = new SinglyLinkedList();

// const singleNodeList = new SinglyLinkedList().seedFromArr([1]);
// const biNodeList = new SinglyLinkedList().seedFromArr([1, 2]);
// const firstThreeList = new SinglyLinkedList().seedFromArr([1, 2, 3]);
// const secondThreeList = new SinglyLinkedList().seedFromArr([4, 5, 6]);
// const unorderedList = new SinglyLinkedList().seedFromArr([
// -5, -10, 4, -3, 6, 1, -7, -2,
// ]);

// // node 4 connects to node 1, back to head
// const perfectLoopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
// perfectLoopList.head.next.next.next = perfectLoopList.head;

// // node 4 connects to node 2
// const loopList = new SinglyLinkedList().seedFromArr([1, 2, 3, 4]);
// loopList.head.next.next.next = loopList.head.next;

// const sortedDupeList = new SinglyLinkedList().seedFromArr([
// 1, 1, 1, 2, 3, 3, 4, 5, 5,
// ]);

const linkedList = new SinglyLinkedList();
linkedList.insertAtFront(100)
linkedList.insertAtFront(200);
linkedList.insertAtFront(300);
linkedList.insertAtBack(400);
linkedList.insertAtIndex(500, 2);
// linkedList.clearList();
// linkedList.removeAt(2);

linkedList.printListData();
console.log("-----");
console.log(linkedList.secondToLast());
// linkedList.getAt(10);
