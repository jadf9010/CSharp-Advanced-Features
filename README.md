# CSharp-Advanced-Features
Some examples of advanced feature in csharp

1 - Integer to string
  -
  Write an integer to string function without using any built-in functionality, conversions or castings with a base of up to 16. The allocation should be handled on behalf of the caller.

I’ve developed and implemented 2 solutions in a Visual Studio Project: 
  **A.Using Recursive Function** 
  **B.Using Recursive Function Using a non Recursive Function**
  
2 - Matrix traversal
  -
  Write a function that prints the values of the matrix clockwise.

**In this solution I’ve developed a reusable, extensible and maintainable solution.**

The main Class : MatrixMovementPattern has the main responsibility to move through the matrix.

We must to define an Iteration Pattern to set a path to move in the matrix. I’ve implemented 2 Iteration Pattern:

1. Clockwise Iteration Pattern
2. Counter Clockwise Iteration Pattern

Using the same algorithm to move in the matrix and only defining a new iteration pattern we can get different results.

3- C# Types
  -
  Difference between value, reference and pointer types in C#.
  
**Structs**
The structs are more efficient that class. Is more recommended use when we want to define small lightweight objects, if you want to use thousands or more objects of that type is more efficient to define them as structures.

Primitive Types:

Int\
Char\
Float\
Bool

Non-Primitive Types:

Classes\
Structures\
Arrays\
Strings

Primitives types are very small types and for that them are Structures.
The primitives and non-primitives Types are tried differently at runtime ways in terms of memories management.

**Reference Type** and **Value Type**

Value Types\

Structures:

-Allocated on the Stack
-Memory Allocations is done Automatically

Reference Types\

Classes:

-Allocated on the Heap
-We must to Allocate memory manually

When we created a variable that is a **value type** a part of memory called Stack is allocated for that variable. The memory allocation is done automatically we don’t have to worry about it. When this variable is out of the scope it’ll be immediately get remove.

We need to allocate memory by ourself when we use References Types. The new operator is used to do that. When it happens a part of the memory called Heap is used to allocate that kind of variable. This objects is a bit more unsustainable that the values types because when a variable is out of the scope it’ll be continues exits for a little while it won’t be remove immediately. There is a process called Garbage Collection that takes care of this.

C# supports pointers in a limited way. A C# pointer is a variable that hold the memory address of another type. Is only allowed to declare pointers to hold the memory address of the **values types and arrays.**

**Pointer types** are not followed by the garbage collection system. For that reason we can’t point to a **reference type.**

A pointer cannot point to a reference, because an object reference can be garbage collected even if a pointer is pointing to it. The garbage collector does not keep track of whether an object is being pointed to by any pointer types.

Type declarations of pointers:

```
int* ptr ——————ptr is a pointer to an integer
```

The operator * can be used to get the contents at the location pointed to by the pointer variable.

**int*** ptr indicate that the **int** variable found at the address contained in **ptr.**

4- Write a small JSON serializer in C#
  -
  Write an object serialization system that can serialize instances into JSON data and deserialize them again from JSON data. The main concerns are that the serializer should be declarative using attributes.
  
I’ve developed a system to deserialize objects but using c# natives functions.
I’ve written an Attribute Class (JSONFieldAttribute) to validate properties and field.

Using the attributes in a class that inherits the base serializable class we can validate before Serialize or Deserialize objects if these fields or properties aren’t null or they are the same type of the attributes.

5- Unity - Task Runner
  -
  Write a Producer/Consumer like task runner in Unity to be able to run long lasting tasks on different threads.
  
  I’ve developed the solution in a project in Unity.
