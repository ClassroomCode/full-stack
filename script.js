
document.getElementById("login-button").addEventListener("click", function(event) {
  const username = document.getElementById("username").value.trim();
  const password = document.getElementById("password").value.trim();

  if (username.length < 5 || password.length < 5) {
  	const errorMsg = document.querySelector(".error-message");
  	errorMsg.innerHTML = "Not long enough";
  	event.preventDefault();
  } 
});