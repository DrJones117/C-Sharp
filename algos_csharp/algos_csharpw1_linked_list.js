/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         *
         * @type {ListNode|null}
       */
        this.next = null;
    }
}

/**
   * This class keeps track of the start (head) of the list and to store all the
   * functionality (methods) that each list should have.
   */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
      /** @type {ListNode|null} */
        this.head = null;
    }

    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isEmpty() {
        //your code here
        return this.head === null;
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
        let newEnd = new ListNode(data);
        if (this.isEmpty()) {
            this.head = newEnd;
            return;
        }
        let runner = this.head;
        while (runner.next !== null) {
            runner = runner.next;
        }
        runner.next = newEnd;
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @param {?ListNode} runner The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackRecursive(data, runner = this.head) {
        //your code here
        if (this.head === null) {
            this.head = new ListNode(data);
            return;
        }
        if (runner.next === null) {
            runner.next = new ListNode(data);
            return;
        }
        return this.insertAtBackRecursive(data, runner.next);
    }

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBackMany(vals) {
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
    insertAtFront(data) {
        //your code here
        let newHead = new ListNode(data);
        newHead.next = this.head;
        this.head = newHead;
        return this;
    }

    /**
     * Removes the first node of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {any} The data from the removed node or null if empty.
     */
    removeHead() {
        //your code here
        if (this.isEmpty()) return null;
        let removed = this.head;
        this.head = this.head.next;
        return removed.data;
    }

    // EXTRA
    /**
     * Calculates the average of this list.
     * - Time: (?).
     * - Space: (?).
     * @returns {number|NaN} The average of the node's data.
     */
    average() {
        //your code here
        if (this.isEmpty()) return null;
        let runner = this.head;
        let count = 0;
        let sum = 0;
        while (runner) {
            count++;
            sum += runner.data;
            runner = runner.next;
        }
        return sum / count;
    }

        /**
     * Removes the last node of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data from the node that was removed or null if no nodes were removed.
    */
    removeBack() {
        if (this.isEmpty()) {
            return null;
        }

        // only one node, remove the head
        if (this.head.next === null) {
            return this.removeHead();
        }
        //more than one node, move to one before the end
        let runner = this.head;
        while (runner.next.next) {
            runner = runner.next;
        }

        const removedData = runner.next.data;
        runner.next = null;
        return removedData;
    }

    /**
     * Determines whether or not the given search value exists in this list iteratively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
     */
    contains(val) {
        let runner = this.head;
        while (runner) {
            if (runner.data === val) return true;
            runner = runner.next;
        }
        return false;
    }

    /**
     * Determines whether or not the given search value exists in this list recursively.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?ListNode} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
     */
    containsRecursive(val, current = this.head) {
        //Your code here
        if (!current) return false;
        if (current.data === val) return true;
        return this.containsRecursive(val, current.next);
    }

    /**
     * Retrieves the data of the second to last node in this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {any} The data of the second to last node or null if there is no
     *    second to last node.
     */
    secondToLast() {
        if (!this.head || !this.head.next) {
            return null;
        }

        // There are at least 2 nodes since the above return hasn't happened.
        let runner = this.head;

        while (runner.next.next) {
            runner = runner.next;
        }
        return runner.data;
    }

    /**
     * Removes the node that has the matching given val as it's data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value to compare to the node's data to find the
     *    node to be removed.
     * @returns {boolean} Indicates if a node was removed or not.
     */
    removeVal(val) {
        if (this.isEmpty()) {
            return false;
        }

        if (this.head.data === val) {
            this.removeHead();
            return true;
        }

        let runner = this.head;

        while (runner.next) {
            if (runner.next.data === val) {
                runner.next = runner.next.next;
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    // EXTRA
    /**
     * Inserts a new node before a node that has the given value as its data.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} newVal The value to use for the new node that is being added.
     * @param {any} targetVal The value to use to find the node that the newVal
     *    should be inserted in front of.
     * @returns {boolean} To indicate whether the node was pre-pended or not.
     */
    prepend(newVal, targetVal) {
        if (this.isEmpty()) {
            return null;
        }

        if (this.head.data === targetVal) {
            this.insertAtFront(newVal);
            return this.head;
        }
        // we already know we're not going to need to prepend before the head
        let runner = this.head;

        while (runner) {
            // End of list and not found.
            if (runner.next === null) {
                return false;
            }

            if (runner.next.data === targetVal) {
                const prependNode = new ListNode(newVal);
                prependNode.next = runner.next;
                runner.next = prependNode;
                return prependNode;
            }
            runner = runner.next;
        }
    }
    /**
     * Concatenates the nodes of a given list onto the back of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {SinglyLinkedList} addList An instance of a different list whose
     *    whose nodes will be added to the back of this list.
     * @returns {SinglyLinkedList} This list with the added nodes.
     */
    concat(addList) {
        if (this.head === null)
        {
            return this;
        }

        if (addList.head === null) 
        {
            return this;
        }

        let runner = this.head;
        while (runner.next)
        {
            runner = runner.next;
        }

        runner.next = addList.head;

        return this;
    }

    /**
     * Finds the node with the smallest data and moves that node to the front of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {SinglyLinkedList} This list.
     */
    moveMinToFront() {
        if (this.head === null)
        {
            return null
        }

        let lowestNode = this.head;
        let runner = this.head;
        let pre = this.head;

        while (runner.next)
        {
            if (runner.next.data < lowestNode.data)
            {
                pre = runner;
                lowestNode = runner.next;
            }
        }
        if (lowestNode === this.head)
        {
            return this;
        }
        else
        {
            let randVar = lowestNode
            this.removeVal(lowestNode.data)
            this.insertAtFront(randVar.data)
            return this
        }
    }
}

/******************************************************************* 
Multiple test lists already constructed to test your methods on.
Below commented code depends on insertAtBack method to be completed,
after completing it, uncomment the code.
*/
const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
const firstThreeList = new SinglyLinkedList().insertAtBackMany([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
const unorderedList = new SinglyLinkedList().insertAtBackMany([
-5, -10, 4, -3, 6, 1, -7, -2
]);


// Test case for concat
// firstThreeList.concat(secondThreeList);
// console.log(firstThreeList.toArr(), "should be", "[1, 2, 3, 4, 5, 6]")

//Test case for move min to front
unorderedList.moveMinToFront();
console.log(unorderedList.toArr(), "should be", "[-10, -5, 4, -3, 6, 1, -7, 2]")


  /* node 4 connects to node 1, back to head */
  // const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
  // perfectLoopList.head.next.next.next = perfectLoopList.head;

  /* node 4 connects to node 2 */
  // const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
  // loopList.head.next.next.next = loopList.head.next;

  // const sortedDupeList = new SinglyLinkedList().insertAtBackMany([
  //   1, 1, 1, 2, 3, 3, 4, 5, 5,
  // ]);
  
  // Print your list like so:
  // console.log(firstThreeList.toArr());