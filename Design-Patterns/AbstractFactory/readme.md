Code structure

```Code
- IAbstractFactory
----- ||>  IAbstractProductA CreateProductA()
----- ||>  IAbstractProductB CreateProductB()

- IAbstractProductA
----- ||>  UsefulFunctionA()

- IAbstractProductB
----- ||>  string UsefulFunctionB();
----- ||>  string AnotherUsefulFunctionB(IAbstractProductA collaborator)

- ConcreteProductA1 <|-----| IAbstractProductA
----- ||> UsefulFunctionA()

- ConcreteProductA2 <|-----| IAbstractProductA
----- ||> UsefulFunctionA()

- ConcreteProductB1 <|-----| IAbstractProductB
----- ||> UsefulFunctionB()
----- ||> AnotherUsefulFunctionB()

- ConcreteProductB2 <|-----| IAbstractProductB
----- ||> UsefulFunctionB()
----- ||> AnotherUsefulFunctionB()

- ConcreteFactory1 <|-----| IAbstractFactory
----- ||> CreateProductA()
----- ||> CreateProductB()

- ConcreteFactory2 <|-----| IAbstractFactory
----- ||> CreateProductA()
----- ||> CreateProductB()

- Client
----- ||> ClientMethod(IAbstractFactory factory)
----------  ||> ClientMethod(new ConcreteFactory1());
----------  ||> ClientMethod(new ConcreteFactory2());
```