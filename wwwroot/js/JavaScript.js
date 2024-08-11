
function updateCharCount() {
    const textarea = document.getElementById('descriptionTextarea');
    const charCount = document.getElementById('charCount');
    charCount.textContent = `${textarea.value.length}/500`;
}
document.addEventListener('DOMContentLoaded', function () {
    updateCommentCharCount();
});
    
    
function updateCommentCharCount() {
    const textarea = document.getElementById('commentTextarea');
    const charCount = document.getElementById('commentCharCount');
    charCount.textContent = `${textarea.value.length}/200`;
}

function validateComment() {
    const textarea = document.getElementById('commentTextarea');
    const errorDiv = document.getElementById('commentError');

    if (textarea.value.trim() === '') {
        if (!errorDiv) {
            const newErrorDiv = document.createElement('div');
            newErrorDiv.id = 'commentError';
            newErrorDiv.className = 'text-red-500 mt-2';
            newErrorDiv.innerText = 'Content cannot be empty.';
            textarea.parentNode.appendChild(newErrorDiv);
        } else {
            errorDiv.style.display = 'block';

        }
        return false; // Prevent form submission
    } else {
        if (errorDiv) {
            errorDiv.style.display = 'none';
        }
        return true; // Allow form submission
    }
}
        
function previewImage(event) {
    const input = event.target;
    const img = document.getElementById('animalImage');
    const errorMessage = document.getElementById('errorMessage');
    const file = input.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            img.src = e.target.result;
            errorMessage.classList.add('hidden');
        };
        reader.onerror = function () {
            img.src = '~/Images/NewDefault.jpg';
            errorMessage.classList.remove('hidden');
        };
        reader.readAsDataURL(file);
    } else {
        img.src = '~/Images/NewDefault.jpg';
        errorMessage.classList.remove('hidden');
    }
}       

    