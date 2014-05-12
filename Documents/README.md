# What we've seen so far

*Assemblies are auto-descriptive Packages of Types (class, enums, etc.)
*Namespaces (and ‘using’ keyword use to avoid using the full name of Types in code).
*ValueType vs. ReferenceType
	..*Boxing (creating an object around an Int32) and Unboxing (extracting the ValueType from the Box) is done automatically.
*Fields/Methods : static vs. Instance.
*Unit tests (Arrange/Act/Assert)
*Object paradigm : 
	..*Inheritance 
		...*Layout of instances in memory.
		...*Instance Methods actually are static methods that accepts an implicit ‘this’ parameter.
	..*GetType() that gives the running instance type.
		...*using ‘is’ and ‘as’ keyword to test the running type (this respects the Liskov Substitution Principle)
	..*virtual/override
	..*Virtual Method Tables (a call to a virtual method occurs one indirection based on the running type of the instance)
	..*‘sealed’ keyword (to forbid override)
*Interface are Contracts
	..*Abstract classes can offer base implementation (but recall that a class can only have one base class).
	..*Interface members can be explicitely implemented.
		...*Enables support of different returned types (for identical parameters)
		...*Enables to « close » an implementation (like ‘sealed’ keyword can do).
*IDisposable
	..*Acquire & Release as soon as possible
*‘using’ keyword is a syntactic sugar that guaranties try {…} finally {  Dispose ! }
*IEnumerable & IEnumerator
	..*‘foreach’ keyword is a syntactic sugar for GetEnumerator/MoveNext/Current/Dispose.
**Generics