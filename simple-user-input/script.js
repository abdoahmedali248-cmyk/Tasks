const form = document.getElementById("userForm");

form.addEventListener("submit", function (event) {

    event.preventDefault();

    
    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;

    
    console.log("User Name:", name);
    console.log("User Email:", email);

    
    form.reset();
});