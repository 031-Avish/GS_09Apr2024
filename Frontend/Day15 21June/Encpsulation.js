class Student {
    // private fields
    #name;
    #age;
    #grade;
    constructor(name, age, grade) {
        this.#name = name;
        this.#age = age;
        this.#grade = grade;
    }
    // Public method
    getDetails() {
        return `Name: ${this.#name}, Age: ${this.#age}, Grade: ${this.#grade}`;
    }
    updateGrade(newGrade) {
        this.#grade = newGrade;
    }
}

const student1 = new Student('Alice', 20, 'A');

console.log(student1.getDetails()); 
student1.updateGrade('A+');
console.log(student1.getDetails());
