Eco Tools
=========
Helps to develop high-performance applications on .NET Framework

Hot to get?
-----------
Nuget-package (will be available soon).

Features
-----------

### Performance & Memory
#### Global cache for boxed values
Value types (structures) support in .NET Framework is a great and fast thing. But sometimes structures can
cause performance problems when they, for example, are frequently passed to
methods that accepts only `Object` or interface parameters.

Frequent boxing is a big problem of high-loaded applications cause it produces a
lot of objects in heap that then needs to be collected by GC. Unintended load to
GC leaves less CPU resources and memory for payload. Sometimes it's very
complicated to avoid unnecessary boxing when using external libraries or heavily
modifiable code. For such cases using [Box()][1] and [BoxGeneric()][2] extension
methods is the best solution.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Int32 x = 25;

Object xBoxed1 = x.Box();
Object xBoxed2 = x.Box();

(xBoxed1 == xBoxed2) // is true
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Both `Box<T>()` and `BoxGeneric<T>()` extension methods use a multi-level boxed
value cache implemented in `BoxedValuesCache<TKey, TValue>` class and avoid
creating a multiple boxed instances of the same value type instance.

[BoxedValuesCache<TKey, TValue>][3] class provides a multi-level cache of
boxed structures (`TValue`) identified by any key (`TKey`). `TKey` can be any
type like `String` or be the same as TValue, which means that value type
instance identifies its boxed value by itself. `BoxedValuesCache<TKey, TValue>`
tries to avoid unintended contentions for frequently requested values using
thread-local storages.

[BoxedValuesCache][4] is almost the same as `BoxedValuesCache<TKey, TValue>`
with type arguments places in methods. Note that `Box()` extension method is
available for all structures that implements `IEquatable<T>` interface.

With Eco Tools each value type instance that needs to be boxed multiple times
can be boxed just once which incredibly decrease GC load and memory consumption
in most of cases.

#### Recycle Factories
.NET Framework provides Garbage Collector that detects unused objects and
collects them. In most cases GC do its work well and doesn't require any attention. 

But sometimes when system runs under pressure and allocates to much memory, GC (especially in server mode)
have not enaugh time to do its job. This means that even if application looses reference to some object 
it takes a lot of time for GC to collect it and release memory.

In that case the collection speed of GC is less than allocation speed and memory usage of application 
increases constantly.

To prevent such situation we needs to reuse some object to decrease allocation speed.

Eco Tools Library provides special RecycleFactory<T> base class and IRecyclable interface to implement 
a simple object pooling mechanism.
 
Instead of creating objects with `new` operator request it from [`RecycleFactory<T>`][5] 
calling the `Create()` method.
When object that implements [`IRecyclable`][6] interface is no longer needed call `Free()` extension method 
to put it back to source `RecycleFactory<T>`.

... *not finished yet* ...

### Tools & Extensions
#### Limited collections
*description will be available soon*

#### Thread-local storage
*description will be available soon*

#### Time extensions
*description will be available soon*

[1]: </Sources/Ecore/Boxing/Structure.cs#L18>
[2]: </Sources/Ecore/Boxing/Structure.cs#L29>
[3]: </Sources/Ecore/Boxing/BoxedValuesCache%602.cs>
[4]: </Sources/Ecore/Boxing/BoxedValuesCache.cs>
[5]: </Sources/Eco.Recycling/RecycleFactory.cs>
[6]: </Sources/Eco.Recycling/IRecyclable.cs>