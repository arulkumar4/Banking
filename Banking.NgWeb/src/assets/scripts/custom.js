export function myFunction() {
  var store = document.getElementById("myInput");
  if (store.type === "password") {
    store.type = "text";
  } else {
    store.type = "password";
  }
}
