
// Extend jQuery validation with custom password rules
$.validator.addMethod("passwordrules", function (value, element) {
    // Password must have at least 8 characters
    if (value.length < 8) {
        return false;
    }

    // Check for at least one uppercase letter
    if (!/[A-Z]/.test(value)) {
        return false;
    }

    // Check for at least one lowercase letter
    if (!/[a-z]/.test(value)) {
        return false;
    }

    // Check for at least one digit
    if (!/[0-9]/.test(value)) {
        return false;
    }

    // Check for at least one special character
    if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
        return false;
    }

    return true; // If all checks pass, the password is valid
}, "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

$(document).ready(function () {
    // Apply the validation rule to the password field
    $("form").validate({
        rules: {
            Password: {
                required: true,
                passwordrules: true
            }
        },
        messages: {
            Password: {
                required: "Password is required",
                passwordrules: "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character."
            }
        }
    });
});
