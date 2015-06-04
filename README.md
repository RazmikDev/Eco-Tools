
# Eco Tools
Helps to develop high-performance applications on .NET Framework

----------


## Hot to get?
Nuget-package (will be available soon).

----------

##Features
### Performance & Memory
#### Global cache for boxed values
Structures in .NET Framework is a great and fast thing. But sometimes they can cause performance problems when they, for example, are frequently passed to methods that accepts only `Object` or interface parameters.

Frequent boxing is a big problem of high-loaded applications cause it produces a lot of objects in heap that then needs to be collected by GC. Unintended load to GC leaves less CPU resources and memory for payload.
Sometimes it's very complicated to avoid unnecessary boxing when using external libraries or heavily modifiable code. For that cases using `Box()` and `BoxGeneric()` extension methods is the best solution.

```
Int32 x = 25;

Object xBoxed1 = x.Box();
Object xBoxed2 = x.Box();

(xBoxed1 == xBoxed2) // is true
```

Both `Box<T>()` and `BoxGeneric<T>()` extension methods use a multi-level boxed value cache implemented in `BoxedValuesCache<TKey, TValue>` class and avoid creating a multiple boxed instances of the same value type instance.

`BoxedValuesCache<TKey, TValue>` class provides a multi-level cache of boxed structures (`TValue`) identified by any key (`TKey`). `TKey` can be any type like `String` or be the same as TValue, which means that value type instance identifies itself its boxed value.
`BoxedValuesCache<TKey, TValue>` tries to avoid unintended contentions for frequently requested values using thread-local storages.

`BoxedValuesCache` ia almost the same as `BoxedValuesCache<TKey, TValue>` with type arguments places in methods.
Note that `Box()` extension method is available for all structures that implements `IEquatable<T>` interface.

With Eco Tools each value type instance that needs to be boxed multiple times can be boxed just once which incredibly decrease GC load and memory consumption in most cases.

#### Recycle Factories
*description will be available soon*

### Tools & Extensions 
#### Limited collections
*description will be available soon*

#### Thread-local storage
*description will be available soon*

#### Time extensions
*description will be available soon*