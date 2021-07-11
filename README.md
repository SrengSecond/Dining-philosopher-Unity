# Dining-philosopher-Unity

Dining philosophers problem is an example problem often used in concurrent algorithm design to illustrate synchronization issues and techniques for resolving them.

## 1. Problem statement
Five silent philosophers (Cube in Demo) sit at a round table with bowls of spaghetti. Forks are placed between each pair of adjacent philosophers. Each Cube must alternately think and eat. But each  individual can eat using fork when they have a pair of fork, which mean that fork is not being used by another philosophers, 
when individual philosopher done eating, they left avaiable to other.
### Problem 
The problem was designed to illustrate the challenges of avoiding deadlock, a system state in which no progress is possible.
consider a proposal in which each philosopher is instructed to behave as follows: 
+ think until the left fork is available; when it is, pick it up;
+ think until the right fork is available; when it is, pick it up;
+ when both forks are held, eat for a fixed amount of time;
+ then, put the right fork down;
+ then, put the left fork down;
+ repeat from the beginning.
![](Deadlock-gif.git)
