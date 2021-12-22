/**
 * Class to represent a Node in a Binary Search Tree (BST).
 */
 class Node {
    /**
     * Constructs a new instance of a BST node.
     * @param {number} data The integer to store in the node.
     */
    constructor(data) {
        this.data = data;
        /**
         * These properties are how this node is connected to other nodes to form
         * the tree. Similar to .next in a SinglyLinkedList except a BST node can
         * be connected to two other nodes. To start, new nodes will not be
         * connected to any other nodes, these properties will be set after
         * the new node is instantiated.
         */
        this.left = null;
        this.right = null;
    }
}

/**
 * Represents an ordered tree of nodes where the data of left nodes are <= to
 * their parent and the data of nodes to the right are > their parent's data.
 */
class BinarySearchTree {
    constructor() {
        /**
         * Just like the head of a linked list, this is the start of our tree which
         * branches downward from here.
         */
        this.root = null;
    }

    // Logs this tree horizontally with the root on the left.
    print(node = this.root, spaceCnt = 0, spaceIncr = 10) {
        if (!node) {
            return;
        }

        spaceCnt += spaceIncr;
        this.print(node.right, spaceCnt);

        console.log(
            " ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
            `${node.data}`
        );

        this.print(node.left, spaceCnt);
    }

    /**
     * Determines if this tree is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean} Indicates if this tree is empty.
     */
    isEmpty() { 
        return this.root == null;
    }

    /**
     * Retrieves the smallest integer data from this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */

    min(current = this.root) { 
        // Edge Case: Empty tree
        if(!current) {
            return null;
        }
        // Finding the smallest is just going to the left as much as you can
        while(current.left) {
            current = current.left;
        }

        return current.data;
        
    }
    // min(current = this.root) { 
    //     if (current == null) {
    //         return null;
    //     } 
    //     while(current.left!=null){
    //         current=current.left;
    //     }
    //     return current.data;
    // }

    /**
     * Retrieves the largest integer data from this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    // max(current = this.root) { 
    //     if (current == null) {
    //         return null;
    //     }
    //     while(current.right!=null) {
    //         current = current.right;
    //     }
    //     return current.data
    // }

    max(current = this.root) { 
        // This is going to be identical to min, but to the right
        if(!current) {
            return null;
        }

        while(current.right) {
            current = current.right;
        }

        return current.data;
    }

    // Bonus Challenges
    /**
     * Retrieves the smallest integer data from this tree.
     * - Time: O(h) - Linear, with respect to the depth of the tree.
     * - Space: O(h) - Linear in relation to the depth of the tree
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The smallest integer from this tree.
     */
    // minRecursive(current = this.root) { 
    //     if (current.data == null){
    //         return null;
    //     }
    //     if(current.left!=null){
    //         return this.minRecursive(current = current.left);
    //     }
    //     return current.data;
    // }


    minRecursive(current = this.root) { 
        if(!current) {
            return null;
        } else if(!current.left) {
            return current.data;
        } else {
            return this.minRecursive(current.left);
        }
    }


    /**
     * Retrieves the largest integer data from this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} current The node that is currently accessed from the tree as
     *    the tree is being traversed.
     * @returns {number} The largest integer from this tree.
     */
    // maxRecursive(current = this.root) { 
    //     if(current.data==null) {
    //         return null;
    //     } else if (current.right!=null) {
    //         return this.maxRecursive(current = current.right);
    //     }
    //     return current.data;
    // }

    maxRecursive(current = this.root) { 
        if(!current) {
            return null;
        } else if(!current.right) {
            return current.data;
        } else {
            return this.maxRecursive(current.right);
        }
    }


    /**
     * Determines if this tree contains the given searchVal.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} searchVal The number to search for in the node's data.
     * @returns {boolean} Indicates if the searchVal was found.
     */
    contains(searchVal) { 
        let current = this.root;
        while (current)
        {
            if (searchVal === current.data)
            {
                return true;
            }
            if (searchVal < current.data){
                current = current.left;
            } else {
                current = current.right;
            }
        }
        return false;
    }

    /**
       * Determines if this tree contains the given searchVal.
       * - Time: O(?).
       * - Space: O(?).
       * @param {number} searchVal The number to search for in the node's data.
       * @returns {boolean} Indicates if the searchVal was found.
       */
    containsRecursive(searchVal, current = this.root) { 
        if (current === null){
            return false;
        }
        if (current.data === searchVal){
            return true;
        }
        if (searchVal < current.data && current.left){
            return this.containsRecursive(searchVal, current.left);
        }
        else if (searchVal > current.data && current.right){
            return this.containsRecursive(searchVal, current.right)
        }
        else
        {
            return false;
        }
    }

    /**
       * Calculates the range (max - min) from the given startNode.
       * - Time: O(hL + hR). - linear with relation to the left and right heights
       * - Space: O(1) - constant
       * @param {Node} startNode The node to start from to calculate the range.
       * @returns {number|null} The range of this tree or a sub tree depending on if the
       *    startNode is the root or not.
       */
    range(startNode = this.root) { 
        if (startNode === null){
            return null;
        }
        return this.max(startNode) - this.min(startNode);
    }



    /**
     * Inserts a new node with the given newVal in the right place to preserve
     * the order of this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {number} newVal The data to be added to a new node.
     * @returns {BinarySearchTree} This tree.
     */
    insert(newVal) { 
        if(this.root == null){
            this.root = new Node(newVal)
        }
        else{
            let runner = this.root;
            while(runner) {
                if (runner.left == null && newVal < runner.data){
                    runner.left = new Node(newVal);
                    break;
                } else if (runner.right == null && newVal >= runner.data){
                    runner.right = new Node(newVal);
                    break;
                }
                if (newVal < runner.data){
                    runner = runner.left;
                }else if (
                    newVal >= runner.data){
                        runner = runner.right;
                    }
                }
            }
            return this;
        }




    /**
       * Inserts a new node with the given newVal in the right place to preserve
       * the order of this tree.
       * - Time: O(?).
       * - Space: O(?).
       * @param {number} newVal The data to be added to a new node.
       * @param {Node} curr The node that is currently accessed from the tree as
       *    the tree is being traversed.
       * @returns {BinarySearchTree} This tree.
    //    */
    // insertRecursive(newVal, curr = this.root) { 
    //     if(this.root == null){
    //         this.root = new Node(newVal);
    //         return this;
    //     } else {
    //         if (curr.left == null && newVal < curr.data){
    //             curr.left = new Node(newVal);
    //             return this;
    //         } else if (curr.right == null && newVal >= curr.data){
    //             curr.right = new Node(newVal);
    //             return this;
    //         }
    //         if(newVal < curr.data)
    //         {
    //             return this.insertRecursive(newVal, curr = curr.left);
    //         } else if (newVal >= curr.data){
    //             return this.insertRecursive(newVal, curr = curr.right);
    //         }
    //     }
    // }

    insertRecursive(newVal, curr = this.root) {
        if(curr == null){
            this.root = new Node(newVal)
            return this
        }
        if(newVal < curr.data){
            if(curr.left == null){
                curr.left = new Node(newVal)
                return this
            }
            return this.insertRecursive(newVal, curr.left)
        }
        else{
            if(curr.right == null){
                curr.right = new Node(newVal)
                return this
            }
            return this.insertRecursive(newVal, curr.right)
        }
    }



        /**
     * DFS Preorder: (CurrNode, Left, Right)
     * Converts this BST into an array following Depth First Search preorder.
     * Example on the fullTree var:
     * [25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90]
     * 
     * - time O(n) - linear
     * - space O(n) - linear in relation to the size of the tree 
     * @param {Node} node The current node during the traversal of this tree.
     * @param {Array<number>} vals The data that has been visited so far.
     * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
     */
        toArrPreorder(node = this.root, vals = []) {
            if (node == null)
            {
                return null;
            }
            else{
                vals.push(node.data);
                this.toArrPreorder(node.left, vals);
                this.toArrPreorder(node.right, vals);
            }
            return vals;
        }

        /**
          * DFS Inorder: (Left, CurrNode, Right)
          * Converts this BST into an array following Depth First Search inorder.
          * See debugger call stack to help understand the recursion.
          * Example on the fullTree var:
          * [4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90]
          * @param {Node} node The current node during the traversal of this tree.
          * @param {Array<number>} vals The data that has been visited so far.
          * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
          */
        toArrInorder(node = this.root, vals = []) { 
            if (node == null)
            {
                return null;
            }
            else{
                this.toArrPreorder(node.left, vals);
                vals.push(node.data);
                this.toArrPreorder(node.right, vals);
            }
            return vals;
        }
        // Left current right

        /**
          * DFS Postorder (Left, Right, CurrNode)
          * Converts this BST into an array following Depth First Search postorder.
          * Example on the fullTree var:
          * [4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25]
          * @param {Node} node The current node during the traversal of this tree.
          * @param {Array<number>} vals The data that has been visited so far.
          * @returns {Array<number>} The vals in DFS Preorder once all nodes visited.
          */
        toArrPostorder(node = this.root, vals = []) {
            if (node == null)
            {
                return null;
            }
            else{
                this.toArrPreorder(node.left, vals);
                this.toArrPreorder(node.right, vals);
                vals.push(node.data);
            }
            return vals;
        }


            /**
     * BFS order: horizontal rows top-down left-to-right.
     * Converts this BST into an array following Breadth First Search order.
     * Example on the fullTree var:
     * [25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90]
     * HINT: Use a stack (maybe 2? I honestly don't remember off the top of my head)
     * jk use a queue
     * @param {Node} current The current node during the traversal of this tree.
     * @returns {Array<number>} The data of all nodes in BFS order.
     */
    toArrLevelorder(current = this.root) { 
        let queue = [];
        let returnVals = [];

        if (current)
        {
            queue.push(current);
        }
        while (queue.length > 0){
            let dequeueNode = queue[0];
            for (let i = 1; i < queue.length; i++){
                queue[i-1] = queue[i];
                queue[i] = dequeueNode;
            }

            queue.pop();
            returnVals.push(dequeueNode.data);

            if(dequeueNode.left){
                queue.push(dequeueNode.left)
            }
            if(dequeueNode.right){
                queue.push(dequeueNode.right)
            }
        }
        return returnVals
    }

    /**
     * Recursively counts the total number of nodes in this tree.
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} node The current node during the traversal of this tree.
     * @returns {number} The total number of nodes.
     */
    size(node = this.root, total = 0) { 
        if (node == null){
            return 0;
        }
        return 1 + this.size(node.left, total) + this.size(node.right, total);

    }

    /**
     * Calculates the height of the tree which is based on how many nodes from
     * top to bottom (whichever side is taller).
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} node The current node during traversal of this tree.
     * @returns {number} The height of the tree.
     */
    height(node = this.root, height = 0) { 
        if(node == null)
        {
            return 0
        }
        else
        {
            let lHeight = this.height(node.left);
            let rHeight = this.height(node.right);

            if (lHeight > rHeight)
                return lHeight + 1;
                else
                return rHeight + 1;
        }
    }

    /**
     * Determines if this tree is a full tree. A full tree is a tree where every
     * node has both a left and a right except for the leaf nodes (last nodes)
     * - Time: O(?).
     * - Space: O(?).
     * @param {Node} node The current node during traversal of this tree.
     * @returns {boolean} Indicates if this tree is full.
     */
    isFull(node = this.root) { 
        if (node == null){
            return true;
        }

    if (node.left == null && node.right == null){
        return true;
    }

    if ((node.left != null) && (node.right != null)){
        return (this.isFull(node.left) && this.isFull(node.right))
    }
    return false;
}
}

    // Left right current

// const emptyTree = new BinarySearchTree();
// const oneNodeTree = new BinarySearchTree();
// oneNodeTree.root = new Node(10);

/* twoLevelTree
        root
        10
      /   \
    5     15
*/
// const twoLevelTree = new BinarySearchTree();
// twoLevelTree.root = new Node(10);
// twoLevelTree.root.left = new Node(5);
// twoLevelTree.root.right = new Node(15);

// twoLevelTree.print();

/**  fullTree
 *                 root
 *              <-- 25 -->
 *            /            \
 *           15             50
 *         /    \         /    \
 *       10      22      35     70
 *      /  \    /  \    /  \   /  \
 *     4   12  18  24  31  44 66  90
 */
const fullTree = new BinarySearchTree();
// fullTree.root = new Node(25);

// left sub-tree
// fullTree.root.left = new Node(15);
// fullTree.root.left.left = new Node(10);
// fullTree.root.left.right = new Node(22);
// fullTree.root.left.left.left = new Node(4);
// fullTree.root.left.left.right = new Node(12);
// fullTree.root.left.right.left = new Node(18);
// fullTree.root.left.right.right = new Node(24);

// right sub-tree
// fullTree.root.right = new Node(50);
// fullTree.root.right.left = new Node(35);
// fullTree.root.right.right = new Node(70);
// fullTree.root.right.left.left = new Node(31);
// fullTree.root.right.left.right = new Node(44);
// fullTree.root.right.right.left = new Node(66);
// fullTree.root.right.right.right = new Node(90);

// console.log('min:')
// console.log(fullTree.min());
// console.log('max:')
// console.log(fullTree.max());
// console.log('max RECURSIVE:')
// console.log(fullTree.maxRecursive());
// console.log('min RECURSIVE:')
// console.log(fullTree.minRecursive());
// console.log(fullTree.containsRecursive(70));
// console.log(fullTree.containsRecursive(27));
// console.log(fullTree.contains(70));
// console.log(fullTree.contains(55));
// console.log(fullTree.containsRecursive(35));
// console.log(fullTree.containsRecursive(55));
// console.log(fullTree.range());
fullTree
    .insert(25)
    .insert(15)
    .insert(10)
    .insert(22)
    .insert(4)
    .insert(12)
    .insert(18)
    .insert(24)
    .insert(50)
    .insert(35)
    .insert(70)
    .insert(31)
    .insert(44)
    .insert(66)
    .insert(90);
fullTree.print();

// fullTree
// .insertRecursive(25)
// .insertRecursive(15)
// .insertRecursive(10)
// .insertRecursive(22)
// .insertRecursive(4)
// .insertRecursive(12)
// .insertRecursive(18)
// .insertRecursive(24)
// .insertRecursive(50)

// console.log(fullTree.toArrPostorder());

// console.log(fullTree.size());
// console.log(fullTree.height());
// console.log(fullTree.isFull());
console.log(fullTree.toArrLevelorder());