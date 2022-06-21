

# Design Patterns Practice in Unity

## Content
2. [Command](#2-command)
3. [Flyweight](#3-flyweight)
4. [Observer](#4-observer)
5. [Prototype](#5-prototype)
6. [Singleton](#6-singleton)
7. [State](#7-state)
8. [Double Buffer](#8-double-buffer)
9. [Game Loop](#9-game-loop)
10. [Update Method](#10-update-method)
11. [Bytecode](#11-bytecode)
12. [Subclass Sandbox](#12-subclass-sandbox)
13. [Type Object](#13-type-object)
14. [Component](#14-component)
15. [Event Queue](#15-event-queue)
16. [Service Locator](#16-service-locator)
17. [Data Locality](#17-data-locality)
18. [Dirty Flag](#18-dirty-flag-bit)
19. [Object Pool](#19-object-pool)
20. [Spatial Partition](#20-spatial-partition)

## 2. Command
### Intent
_Turn a request into a stand-alone object that contains all information about the request._

### The Pattern
Declare behaviours into stand-alone commands that implement `Execute`, `Undo`, and `Redo` methods.

### Notes
-

## 3. Flyweight
### Intent
_Fit more objects into the available amount of RAM by sharing common parts of state between multiple objects instead of keeping all of the data in each object._

### The Pattern
Define common and unique data of an object. Allocate the shared data to a separate object to which all instances will refer to.

### Notes
- [Particle System](https://docs.unity3d.com/Manual/ParticleSystems.html) in [Unity](http://unity3d.com/) implements flyweight pattern.
- [Scriptable Object](https://docs.unity3d.com/Manual/class-ScriptableObject.html) in [Unity](http://unity3d.com/) is one way to store shared data.

## 4. Observer
### Intent
_Define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing._

### The Pattern
Provide observer objects a way to _subscribe_ to updates of observed object states.

### Notes
- The notification order is mostly random.
- [Examples](https://youtu.be/HoA4LZ7a-OI) of the observer pattern in Assassin's Creed: Revelations.

## 5. Prototype
### Intent
_Duplicate existing objects without making your code dependent on their classes._

### The Pattern
Create a specific `clone` method that copies all the necessary parameters of itself into a new object and returns it.

### Notes
- Exists in Unity in the form of the [Instantiate-method](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html). But it assumes that the object you want to duplicate inherits from Object, which is a class in UnityEngine.

## 6. Singleton
### Intent
_Let several classes communicate through one "connector"-class._

### The Pattern
Ensure a class has one instance, and provide a global point of access to it.

### Notes
- An implementation most likely will violates the _Single Responsibility Principle from SOLID_.
- Another option is to define a class whose sole reason for being is to give global access to objects. This common pattern is called a [Service Locator](#16-service-locator).

## 7. State
### Intent
_Avoid a bunch of "isDoing" booleans and if-else conditions dependent on them._

### The Pattern
Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.

### Notes
- Finite state machines are useful when:
	-   You have an entity whose behavior changes based on some internal state.
	-   That state can be rigidly divided into one of a relatively small number of distinct options.
	-   The entity responds to a series of inputs or events over time.

## 8. Double Buffer
### Intent
_Cause a series of sequential operations to appear instantaneous or simultaneous._

### The Pattern
A  **buffered class**  encapsulates a  **buffer**: a piece of state that can be modified. This buffer is edited incrementally, but we want all outside code to see the edit as a single atomic change. To do this, the class keeps  _two_  instances of the buffer: a  **next buffer**  and a  **current buffer**.

When information is read  _from_  a buffer, it is always from the  _current_  buffer. When information is written  _to_  a buffer, it occurs on the  _next_  buffer. When the changes are complete, a  **swap**  operation swaps the next and current buffers instantly so that the new buffer is now publicly visible. The old current buffer is now available to be reused as the new next buffer.

### Notes
-

## 9. Game Loop
### Intent
_Decouple the progression of game time from user input and processor speed._

### The Pattern
A **game loop** runs continuously during gameplay. Each turn of the loop, it **processes user input** without blocking, **updates the game state**, and **renders the game**. It tracks the passage of time to **control the rate of gameplay**.

### Notes
- The [Unity](http://unity3d.com/) framework has a complex game loop detailed in the [order of execution for event functions](http://docs.unity3d.com/Manual/ExecutionOrder.html).

## 10. Update Method
### Intent
_Simulate a collection of independent objects by telling each to process one frame of behavior at a time._

### The Pattern
The **game world** maintains a **collection of objects**. Each object implements an **update method** that **simulates one frame** of the object’s behavior. Each frame, the game updates every object in the collection.

### Notes
- The  [Unity](http://unity3d.com/)  framework uses this pattern in several classes, including  [`MonoBehaviour`](http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Update.html).
- Update Method, along with  [Game Loop](https://gameprogrammingpatterns.com/game-loop.html)  and  [Component](https://gameprogrammingpatterns.com/component.html), is part of a trinity that often forms the nucleus of a game engine.

## 11.Bytecode
### Intent
_Give behavior the flexibility of data by encoding it as instructions for a virtual machine._

### The Pattern
An **instruction set** defines the low-level operations that can be performed. A series of instructions is encoded as a **sequence of bytes**. A **virtual machine** executes these instructions one at a time, using a **stack for intermediate values**. By combining instructions, complex high-level behavior can be defined.

### Notes
- Command-Line based games use this pattern.

## 12. Subclass Sandbox
### Intent
_Define behavior in a subclass using a set of operations provided by its base class._

### The Pattern
A **base class** defines an abstract **sandbox method** and several **provided operations**. Marking them protected makes it clear that they are for use by derived classes. Each derived **sandboxed subclass** implements the sandbox method using the provided operations.

### Notes
- The base class ends up coupled to every system _any_ derived class needs to talk to.
- Can be very hard to change the base class without breaking something.
- When you apply the [Update Method](#10-update-method)  pattern, your update method will often also be a sandbox method.

## 13. Type Object
### Intent
_Allow the flexible creation of new “classes” by creating a single class, each instance of which represents a different type of object._

### The Pattern
Define a **type object** class and a **typed object** class. Each type object instance represents a different logical type. Each typed object stores a **reference to the type object that describes its type**.

### Notes
- Easy to define type-specific _data_, but hard to define type-specific _behavior_.
- The high-level problem this pattern addresses is sharing data and behavior between several objects. Another pattern that addresses the same problem in a different way is [Prototype](#4-prototype)
- Type Object is a close cousin to [Flyweight](#3-flyweight). Both let you share data across instances. With Flyweight, the intent is on saving memory, and the shared data may not represent any conceptual “type” of object. With the Type Object pattern, the focus is on organization and flexibility.
- There’s a lot of similarity between this pattern and the [State](#7-state) pattern. Both patterns let an object delegate part of what defines itself to another object. With a type object, we’re usually delegating what the object _is_: invariant data that broadly describes the object. With State, we delegate what an object _is right now_: temporal data that describes an object’s current configuration.

## 14. Component
### Intent
_Allow a single entity to span multiple domains without coupling the domains to each other._

### The Pattern
A **single entity spans multiple domains**. To keep the domains isolated, the code for each is placed in its own **component  class**. The entity is reduced to a simple **container of components**.

### Notes
- The  [Unity](http://unity3d.com/)  framework’s core  [`GameObject`](http://docs.unity3d.com/Documentation/Manual/GameObjects.html)  class is designed entirely around  [components](http://docs.unity3d.com/Manual/UsingComponents.html).
- Communication between the different components becomes more challenging, and controlling how they occupy memory is more complex.

## 15. Event Queue
### Intent
_Decouple when a message or event is sent from when it is processed._

### The Pattern
A **queue** stores a series of **notifications or requests** in first-in, first-out order. Sending a notification **enqueues the request and returns**. The request processor then **processes items from the queue** at a later time. Requests can be **handled directly** or **routed to interested parties**. This **decouples the sender from the receiver** both **statically** and **in time**.

### Notes
- Asynchronous cousin to the [Observer](#4-observer).
- An “event” or “notification” describes something that _already_ happened, like “monster died”.
- A “message” or “request” describes an action that we _want_ to happen _in the future_, like “play sound”.

## 16. Service Locator

### Intent
_Provide a global point of access to a service without coupling users to the concrete class that implements it._

### The Pattern
A **service** class defines an abstract interface to a set of operations. A concrete **service provider** implements this interface. A separate **service locator** provides access to the service by finding an appropriate provider while hiding both the provider’s concrete type and the process used to locate it.

### Notes
- Contrast with [Singleton](#6-singleton): As far as a service interface isn't aware of the fact that it's begin accessed in most places through a service locator, we can apply this pattern to *existing* classes that weren't necessarily designed around it. Singleton affects the design of the service class itself.
- Anytime you make something accessible to every part of your program, you're asking for trouble. This gives you flexibility, but the price you pay is that it’s harder to understand what your dependencies are by reading the code.

## 17. Data Locality

### Intent
_Accelerate memory access by arranging data to take advantage of CPU caching._

### The Pattern
Modern CPUs have **caches to speed up memory access**. These can access memory **adjacent to recently accessed memory much quicker**. Take advantage of that to improve performance by **increasing data locality**— keeping data in **contiguous memory in the order that you process it**.

### Notes
- The CPU grabs a whole chunk of contiguous memory   and puts it in a **_cache line_**.
![A cache line showing the one byte requested along with the adjacent bytes that also get loaded into the cache.](https://gameprogrammingpatterns.com/images/data-locality-cache-line.png)
- If the next byte of data you need happens to be in that chunk, the CPU reads it straight from the cache, which is _much_ faster than hitting RAM. Successfully finding a piece of data in the cache is called a **_cache hit_**. 
- If it can’t find it in there and has to go to main memory, that’s a **_cache miss_**. Our mission is to avoid that.
- The goal is to  _organize your data structures so that the things you’re processing are next to each other in memory_. In other words, if your code is crunching on `Thing`, then `Another`, then `Also`, you want them laid out in memory like this:
![Thing, Another, and Also laid out directly next to each other in order in memory.](https://gameprogrammingpatterns.com/images/data-locality-things.png)
- Using the [Component](#14-component) pattern makes this optimization easier. Since entities are updated one “domain” (AI, physics, etc.) at a time, splitting them out into components lets you slice a bunch of entities into the right pieces to be cache-friendly. But that doesn’t mean you can  _only_  use this pattern with components!

## 18. Dirty Flag (Bit)

### Intent
_Avoid unnecessary work by deferring it until the result is needed._

### The pattern
A set of **primary data** changes over time. A set of **derived data** is determined from this using some **expensive process**. A **“dirty” flag** tracks when the derived data is out of sync with the primary data. It is **set when the primary data changes**. If the flag is set when the derived data is needed, then **it is reprocessed and the flag is cleared.** Otherwise, the previous **cached derived data** is used.

### Notes
- Calculation of the world position of the child object relative to the change in the position of the parent object.
- Text editors know if your document has “unsaved changes”. That little bullet or star in your file’s title bar is literally the dirty flag visualized. The primary data is the open document in memory, and the derived data is the file on disk.
- “Flag” and “bit” are synonymous in programming — they both mean a single micron of data that can be in one of two states. We call those “true” and “false”, or sometimes “set” and “cleared”.

## 19. Object Pool
### Intent
_Improve performance and memory use by reusing objects from a fixed pool instead of allocating and freeing them individually._

### The Pattern
Define a  **pool**  class that maintains a collection of  **reusable objects**. Each object supports an  **“in use” query**  to tell if it is currently “alive”. When the pool is initialized, it creates the entire collection of objects up front (usually in a single contiguous allocation) and initializes them all to the “not in use” state.

When you want a new object, ask the pool for one. It finds an available object, initializes it to “in use”, and returns it. When the object is no longer needed, it is set back to the “not in use” state. This way, objects can be freely created and destroyed without needing to allocate memory or other resources.

### Notes
- "Soak tests" - leave the game running in demo mode for several days. While soak tests sometimes fail because of a rarely occurring bug, it’s usually creeping fragmentation or memory leakage that brings the game down.
- You normally rely on a garbage collector or `new` and `delete` to handle memory management for you. By using an object pool, you’re saying, “I know better how these bytes should be handled.” That means the onus is on you to deal with this pattern’s limitations.
- If you do use an object pool in concert with a garbage collector, beware of a potential conflict. Since the pool doesn’t actually deallocate objects when they’re no longer in use, they remain in memory. If they contain references to _other_ objects, it will prevent the collector from reclaiming those too. To avoid this, when a pooled object is no longer in use, clear any references it has to other objects.

## 20. Spatial Partition
### Intent
_Efficiently locate objects by storing them in a data structure organized by their positions._

### The Pattern
For a set of **objects**, each has a **position in space**. Store them in a **spatial data structure** that organizes the objects by their positions. This data structure lets you **efficiently query for objects at or near a location**. When an object’s position changes, **update the spatial data structure** so that it can continue to find the object.

### Notes
- Each of spatial data structures basically extends an existing well-known data structure from 1D into more dimensions:
	- A grid is a persistent  [bucket sort](http://en.wikipedia.org/wiki/Bucket_sort).
	- BSPs, k-d trees, and bounding volume hierarchies are  [binary search trees](http://en.wikipedia.org/wiki/Binary_search_tree).
	- Quadtrees and octrees are  [tries](http://en.wikipedia.org/wiki/Trie).

## References
1. [Game Programming Patterns book by Robert Nystrom](https://gameprogrammingpatterns.com/contents.html)
2. [Design Pattern in Object Oriented Programming playlist by Christopher Okhravi](https://youtube.com/playlist?list=PLrhzvIcii6GNjpARdnO4ueTUAVR9eMBpc)
3. [Refactoring Guru](https://refactoring.guru/design-patterns/catalog)
4. [Game programming patterns in Unity github by Habrador](https://github.com/Habrador/Unity-Programming-Patterns)
5. [Game Programming Patterns playlist by Jason Weimann](https://youtube.com/playlist?list=PLB5_EOMkLx_VOmnIytx37lFMiajPHppmj)
6. [Programming For Production playlist by iHeartGameDev](https://youtube.com/playlist?list=PLwyUzJb_FNeTR1Q7edAQuWkTKo_Ncq9ck)
7. [The Essays on Design by Jason Li](https://medium.com/@jasonzhenli)
