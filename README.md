# Dining-philosopher-Unity

Dining philosophers problem is an example problem often used in concurrent algorithm design to illustrate synchronization issues and techniques for resolving them.

## 1. Problem statement
Five silent philosophers **(Cube in Demo)** sit at a round table with bowls of spaghetti **(2 Soda cane in demo)**. Forks **(glass in demo)** are placed between each pair of adjacent philosophers. Each Cube must alternately think and eat. But each  individual can eat using fork when they have a pair of fork, which mean that fork is not being used by another philosophers, 
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

<p align="center">
  <img style="border-radius:50%" width="500" src="https://user-images.githubusercontent.com/61487831/125204793-2d29da00-e2a9-11eb-9a44-e0ba8d48bed1.gif" />  
</p>

## 2. Solution
### Resource hierarchy solution

This solution to the problem is the one originally proposed by Dijkstra. It assigns a partial order to the resources (the forks, in this case), and establishes the convention that all resources will be requested in order, and that no two resources unrelated by order will ever be used by a single unit of work at the same time. Here, the resources (forks) will be numbered 1 through 5 and each unit of work (philosopher) will always pick up the lower-numbered fork first, and then the higher-numbered fork, from among the two forks they plan to use. The order in which each philosopher puts down the forks does not matter. In this case, if four of the five philosophers simultaneously pick up their lower-numbered fork, only the highest-numbered fork will remain on the table, so the fifth philosopher will not be able to pick up any fork. Moreover, only one philosopher will have access to that highest-numbered fork, so he will be able to eat using two forks. 

<p align="center">
  <img style="border-radius:50%" width="500" src="https://user-images.githubusercontent.com/61487831/125205704-d2df4800-e2ad-11eb-855a-3522ddda032d.gif" />  
</p>

## 3. Alternative solutions
### Arbitrator solution
approach is to guarantee that a philosopher can only pick up both forks, inorder to achieve this we introduct **arbitrator** or known as waiter. philosopher must ask waiter to gain permission in order to grab both fork, this approach can result in reduced parallelism

### Limiting the number of diners in the table
A solution presented by William Stallings[5] is to allow a maximum of n-1 philosophers to sit down at any time. The last philosopher would have to wait (for example, using a semaphore) for someone to finish dining before they "sit down" and request access to any fork. This guarantees at least one philosopher may always acquire both forks, allowing the system to make progress. 




