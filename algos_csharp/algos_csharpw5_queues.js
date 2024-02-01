/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    constructor() {
        this.items = [];
    }

    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    len() {
        return this.items.length;
    }

    /**
     * Adds a new given item to the back of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to add to the back.
     * @returns {number} The new size of this queue.
     */
    enqueue(item) {
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes and returns the first item of this queue.
     * - Time: O(n) linear, due to having to shift all the remaining items to
     *    the left after removing first elem.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    dequeue() {
        return this.items.shift();
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item or undefined if empty.
     */
    front() {
        return this.items[0];
    }

    /**
     * Returns whether or not this queue is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length === 0;
    }

    print() {
        console.log(this.items);
        return this.items;
    }
}

/* Rebuild the above class using a linked list instead of an array. */

/*
In order to maintain an O(1) enqueue time complexity like .push with an array
We add a tail to our linked list so we can go directly to the last node
*/

class QueueNode {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class LinkedListQueue {
    constructor() {
        this.head = null;
        this.tail = null; // Having a tail allows us to be as efficient as an array with .push, and more efficient than .shift.
        this.size = 0;    // We track the size similar to the length property of arrays.
    }
    /**
     * Retrieves the size of this queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    len() {
        // let count = 0
        // let runner = this.head;
        // while (runner)
        // {
        //     this.size += 1;
        // }

        // this.size = count;
        return this.size;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean} Indicates if the list is empty.
     */
    isEmpty() {
        return this.head === null;
    }

    /**
     * Adds a given val to the back of the queue.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} val
     * @returns {number} The new size of the queue.
     */
    enqueue(val) {
        let newNode = new QueueNode(val);
        if (this.isEmpty())
        {
            this.head = newNode;
            this.tail = newNode;

            this.size ++
            return this.size;
        }
        this.tail.next = newNode;
        this.tail = newNode

        this.size ++
        return this.size;
    }

    /**
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item.
     */
    dequeue() {
        // Similar to the shift() array method.
        // Remember to update the size property.
        if (this.isEmpty())
        {
            return null;
        }

        const temp = this.head;

        if (this.head == this.tail)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.next;
            temp.next = null;
        }

        this.size --;

        return temp.data;
    }

    /**
     * Retrieves the first item without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The first item.
     */
    front() {
        // Similar to peak from Stacks.
        if (this.isEmpty())
        {
            return null;
        }

        return this.head.data;
    }

    /**
     * Enqueues each of the given items.
     * - Time: O(n) linear since enqueue is O(1), n = vals.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals
     */
    seed(vals) {
        vals.forEach((val) => this.enqueue(val));
    }

    print() {
        let runner = this.head;
        let vals = "";

        while (runner) {
            vals += `${runner.data}${runner.next ? ", " : ""}`;
            runner = runner.next;
        }
        console.log(vals);
        return vals;
    }

}

// * compare q1 && q2 size?
// * the size property dictates the amount of passes the loop has to traverse

function compareQue(q1, q2)
{
    // * if ques do not have same size property value - we know ques are not equal - RETURN FALSE
    if (q1.len() !== q2.len())
    {
        return false;
    }

    if (q1.front() !== q2.front())
    {
        return false;
    }

    // * we always want to compare the value stored at q1.head && q2.head and then remove it?
    // * initialize Variable to return True -
    let isEqual = true;
    // * set up runner varaiables to represent the heads of the ques
    // * Remember heads of ques are the End of Que

    let countTracker = 0;
    let totalLength = q1.len();

    while (countTracker < totalLength)
    {
        let item1 = q1.dequeue();
        let item2 = q2.dequeue();

        if (item1 !== item2)
        {
            isEqual = false;
        }

        q1.enqueue(item1);
        q2.enqueue(item2);
        countTracker++;
    }
    return isEqual;
}

/**
 * Determines whether the sum of the left half of the queue items is equal to
 * the sum of the right half. Avoid indexing the queue items directly via
 * bracket notation, use the queue methods instead for practice.
 * Use no extra array or objects.
 * If queue cannot be evenly divided, return false.
 * The queue should be returned to it's original order when done.
 * - Time: O(n^2) quadratic, n = queue length. Quadratic due to dequeue on an
 *     array queue being O(n).
 * - Space: O(1) constant.
 * @returns {boolean} Whether the sum of the left and right halves is equal.
 */
function isSumOfHalvesEqual(q1) {
    // if the size of the queue is odd or if its empty, we will want to early exit.
    if (q1.len() % 2 != 0 || q1.isEmpty())
    {
        return false;
    }
    
    // Initialize a count variable as a stopping point for the while loop.
    let count = 0;

    // this gives us the length that each half should be.
    let halfLength = q1.len() / 2;

    // variables to keep tracck the sum of each half of the Queue
    let firstHalfSum = 0;
    let secondHalfSum = 0;


    // Runs until count is equal to the whole Queue's length.
    while (count < halfLength * 2)
    {
        // if count is less than the length of half of the Queue. We will add to the first sum.
        let item1 = q1.dequeue();

        if (count < halfLength)
        {
            firstHalfSum += item1;
        }
        // Otherwise we add to the second sum.
        else
        {
            secondHalfSum += item1;
        }

        q1.enqueue(item1);
        count++;
    }

    // return the comparison. (true or false)
    return firstHalfSum === secondHalfSum;
}



const arrayQueue = new Queue();
arrayQueue.items = [1, 2, 9, 3, 3, 6];
// arrayQueue.print();

const listQueueSame = new LinkedListQueue();
listQueueSame.seed([1, 2, 9, 3, 3, 6]);


const listQueueSame2 = new LinkedListQueue();
listQueueSame2.seed([1, 2, 9, 3, 3, 6]);

const listQueueDifferent = new LinkedListQueue();
listQueueDifferent.seed([1, 2, 9, 1, 2, 3]);

const sumOfHalvesNot = new LinkedListQueue();
sumOfHalvesNot.seed([1, 2, 9, 1, 2, 3, 20]);


console.log(isSumOfHalvesEqual(listQueueSame2));
listQueueSame2.print();
console.log("");
console.log(isSumOfHalvesEqual(sumOfHalvesNot));
sumOfHalvesNot.print();



const newList = new LinkedListQueue();
newList.enqueue(5);
newList.enqueue(4);
newList.enqueue(3);


// console.log(newList.dequeue());

// console.log(newList.front());

// console.log(newList.len);


// console.log("ListQueSame Before Compare" + listQueueSame.print())
// console.log("ListQueSame2 Before Compare" + listQueueSame.print())
// console.log("Should be true " + compareQue(listQueueSame, listQueueSame2));
// console.log("ListQueSame After Compare" + listQueueSame.print())
// console.log("ListQueSame2 After Compare" + listQueueSame.print())
// console.log("Should be false " + compareQue(listQueueSame, listQueueDifferent));