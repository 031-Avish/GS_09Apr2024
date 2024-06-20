// // Function to validate the login form
// function validateLoginForm() {
//     // Get the email and password fields
//     const email = document.getElementById('email').value;
//     const password = document.getElementById('password').value;

//     // Validate email format
//     const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//     if (!emailRegex.test(email)) {
//         document.getElementById('email').style.borderColor = 'red';
//         return false;
//     }

//     // Validate password length
//     if (password.length < 6) {
//         document.getElementById('password').style.borderColor = 'red';
//         return false;
//     }

//     // If all validations pass, return true
//     return true;
// }

// // Function to validate the registration form
// function validateRegistrationForm() {
//     // Get the form fields
//     const registerName = document.getElementById('registerName').value;
//     const email = document.getElementById('email').value;
//     const phone = document.getElementById('phone').value;
//     const password = document.getElementById('password').value;
//     const confirmPassword = document.getElementById('confirmPassword').value;

//     // Validate registerName length
//     if (registerName.length < 3) {
//         document.getElementById('registerName').style.borderColor = 'red';
//         return false;
//     }

//     // Validate email format
//     const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
//     if (!emailRegex.test(email)) {
//         document.getElementById('email').style.borderColor = 'red';
//         return false;
//     }

//     // Validate phone length
//     if (phone.length !== 10) {
//         document.getElementById('phone').style.borderColor = 'red';
//         return false;
//     }

//     // Validate password and confirm password match
//     if (password !== confirmPassword) {
//         document.getElementById('password').style.borderColor = 'red';
//         document.getElementById('confirmPassword').style.borderColor = 'red';
//         return false;
//     }

//     // If all validations pass, return true
//     return true;
// }


document.getElementById('registerEmail').addEventListener('blur', function() {
    const email = document.getElementById('registerEmail').value;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (emailRegex.test(email)) {
        document.getElementById('registerEmail').style.borderColor = 'green';
    } else {
        document.getElementById('registerEmail').style.borderColor = 'red';
    }
});



document.getElementById('registerName').addEventListener('blur', function() {
    const registerName = document.getElementById('registerName').value;
    if (registerName.length >= 3) {
        document.getElementById('registerName').style.borderColor = 'green';
    } else {
        document.getElementById('registerName').style.borderColor = 'red';
    }
});

document.getElementById('registerPhone').addEventListener('blur', function() {
    const phone = document.getElementById('registerPhone').value;
    const phoneRegex = /^\d+$/;
    if (phoneRegex.test(phone) && phone.length === 10) {
        document.getElementById('registerPhone').style.borderColor = 'green';
    } else {
        document.getElementById('registerPhone').style.borderColor = 'red';
    }
});

document.getElementById('registerPassword').addEventListener('blur', function() {
    const password = document.getElementById('registerPassword').value;
    if (password.length >= 6) {
        document.getElementById('registerPassword').style.borderColor = 'green';
    } else {
        document.getElementById('registerPassword').style.borderColor = 'red';
    }
});

document.getElementById('confirmPassword').addEventListener('blur', function() {
    const password = document.getElementById('registerPassword').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    if (password === confirmPassword) {
        document.getElementById('confirmPassword').style.borderColor = 'green';
    } else {
        document.getElementById('confirmPassword').style.borderColor = 'red';
    }
});