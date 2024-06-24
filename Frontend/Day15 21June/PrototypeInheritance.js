function Animal(name) {
    this.name = name;
}

Animal.prototype.sayHello = function() {
    console.log("Hello, I'm " + this.name);
};

function Dog(name, breed) {
    Animal.call(this, name);
    this.breed = breed;
}

Dog.prototype = Object.create(Animal.prototype);
Dog.prototype.constructor = Dog;

Dog.prototype.bark = function() {
    console.log("Woof! I'm a " + this.breed);
};

var animal = new Animal("Generic Animal");
var dog = new Dog("Buddy", "Golden Retriever");

animal.sayHello(); 
dog.sayHello(); 
dog.bark();