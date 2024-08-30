const img = document.getElementById('lh-profileimage');
const fileInput = document.getElementById('lh-profile-fileInput');

img.onclick = () => fileInput.click();

fileInput.onchange = e => img.src = URL.createObjectURL(e.target.files[0]);