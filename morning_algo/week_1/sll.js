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
    insertAtBack(data) { 
        if (this.isEmpty()){
            this.head = new Node(data);
        }
        else{
            var runner = this.head
            while (runner.next !== null){
                runner = runner.next
            }
            runner.next = new Node(data)
        }
        return this
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
        newHead.next=this.head;
        this.head = newHead;
        return this;
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
removeBack() { 
    if (this.isEmpty() || this.head.next == null){
        return null;
    }
    runner = this.head;
    while (runner.next != null){
        Node.data = Node.data.next;
    }

    return head
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
        console.log("false")
        return false;
    }
    if (current.data == val){
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
recursiveMax(runner = this.head, maxNode = this.head) { }
}


// const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().seedFromArr([1]);
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

linkedList.printListData();
