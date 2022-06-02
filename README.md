
# Design Patterns Practice in Unity

## Content
2. [Command](#1-command)
3. [Flyweight](#2-flyweight)
4. [Observer](#3-observer)
5. [Prototype](#4-prototype)
6. [Singleton](#5-singleton)
7. [State](#6-state)
8. [Double Buffer](#7-double-buffer)
9. [Game Loop](#8-game-loop)
10. [Update Method](#9-update-method)
11. [Bytecode](#10-bytecode)
12. [Subclass Sandbox](#11-subclass-sandbox)
13. [Type Object](#12-type-object)
14. [Component](#13-component)
15. [Event Queue](#14-event-queue)
16. [Service Locator](#15-service-locator)
17. [Data Locality](#16-data-locality)
18. [Dirty Flag](#17-dirty-flag-bit)
19. [Object Pool](#18-object-pool)
20. [Spatial Partition](#19-spatial-partition)

## NUM. PATTERN
### Intent

### The Pattern

### Notes
-

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
- Using the [Component](#13-component) pattern makes this optimization easier. Since entities are updated one “domain” (AI, physics, etc.) at a time, splitting them out into components lets you slice a bunch of entities into the right pieces to be cache-friendly. But that doesn’t mean you can  _only_  use this pattern with components!

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

## References
1. [Game Programming Patterns book by Robert Nystrom](https://gameprogrammingpatterns.com/contents.html)
2. [Design Pattern in Object Oriented Programming playlist by Christopher Okhravi](https://youtube.com/playlist?list=PLrhzvIcii6GNjpARdnO4ueTUAVR9eMBpc)
3. [Refactoring Guru](https://refactoring.guru/design-patterns/catalog)
4. [Game programming patterns in Unity github by Habrador](https://github.com/Habrador/Unity-Programming-Patterns)
5. [Game Programming Patterns playlist by Jason Weimann](https://youtube.com/playlist?list=PLB5_EOMkLx_VOmnIytx37lFMiajPHppmj)
6. [Programming For Production playlist by iHeartGameDev](https://youtube.com/playlist?list=PLwyUzJb_FNeTR1Q7edAQuWkTKo_Ncq9ck)
7. [The Essays on Design by Jason Li](https://medium.com/@jasonzhenli)