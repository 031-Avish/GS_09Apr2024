class Student {
    constructor(name, grade) {
        this.name = name;
        this.grade = grade;
    }
    displayInfo() {
        console.log(`Name: ${this.name}`);
        console.log(`Grade: ${this.grade}`);
    }
}

class HighSchoolStudent extends Student {
    constructor(name, grade, major) {
        super(name, grade);
        this.major = major;
    }
    displayInfo() {
        super.displayInfo();
        console.log(`Major: ${this.major}`);
    }
}

class CollegeStudent extends Student {
    constructor(name, grade, major) {
        super(name, grade);
        this.major = major;
    }

    displayInfo() {
        super.displayInfo();
        console.log(`Major: ${this.major}`);
    }
}

const students = [
    new Student("John Doe", 10),
    new HighSchoolStudent("Jane Smith", 11, "Science"),
    new CollegeStudent("Alice Johnson", 12, "Computer Science")
];

students.forEach(student => {
    student.displayInfo();
    console.log("--------------------");
});