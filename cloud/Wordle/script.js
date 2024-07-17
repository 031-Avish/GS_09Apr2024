const wordList = ['apple', 'grape', 'lemon', 'berry', 'melon']; // Sample word list
const secret = wordList[Math.floor(Math.random() * wordList.length)].toUpperCase();
let currentRow = 0;
let currentTile = 0;
let guess = '';
const maxGuesses = 6;

document.addEventListener('DOMContentLoaded', () => {
    createBoard();
    createKeyboard();
});

function createBoard() {
    const board = document.getElementById('board');
    for (let i = 0; i < maxGuesses * 5; i++) {
        const tile = document.createElement('div');
        tile.classList.add('tile');
        board.appendChild(tile);
    }
}

function createKeyboard() {
    const keyboard = document.getElementById('keyboard');
    const keys = 'QWERTYUIOPASDFGHJKLZXCVBNM'.split('');
    keys.forEach(key => {
        const keyElement = document.createElement('div');
        keyElement.classList.add('key');
        keyElement.textContent = key;
        keyElement.addEventListener('click', () => handleKeyClick(key));
        keyboard.appendChild(keyElement);
    });

    const enterKey = document.createElement('div');
    enterKey.classList.add('key');
    enterKey.textContent = 'ENTER';
    enterKey.addEventListener('click', checkGuess);
    keyboard.appendChild(enterKey);

    const backspaceKey = document.createElement('div');
    backspaceKey.classList.add('key');
    backspaceKey.textContent = '⌫';
    backspaceKey.addEventListener('click', handleBackspace);
    keyboard.appendChild(backspaceKey);
}

function handleKeyClick(letter) {
    if (currentTile < 5) {
        guess += letter;
        const tile = document.querySelectorAll('.tile')[currentRow * 5 + currentTile];
        tile.textContent = letter;
        currentTile++;
    }
}

function handleBackspace() {
    if (currentTile > 0) {
        currentTile--;
        guess = guess.slice(0, -1);
        const tile = document.querySelectorAll('.tile')[currentRow * 5 + currentTile];
        tile.textContent = '';
    }
}

function checkGuess() {
    if (guess.length === 5) {
        const guessArray = guess.split('');
        const secretArray = secret.split('');
        let correctCount = 0;

        // Check for correct letters
        guessArray.forEach((letter, index) => {
            const tile = document.querySelectorAll('.tile')[currentRow * 5 + index];
            if (letter === secretArray[index]) {
                tile.classList.add('correct');
                markKeyAs(letter, 'correct');
                correctCount++;
            } else if (secret.includes(letter)) {
                tile.classList.add('present');
                markKeyAs(letter, 'present');
            } else {
                tile.classList.add('absent');
                markKeyAs(letter, 'absent');
            }
        });

        if (correctCount === 5) {
            alert('Congratulations! You guessed the word!');
            return;
        }

        currentRow++;
        currentTile = 0;
        guess = '';

        if (currentRow === maxGuesses) {
            alert(`Game Over! The word was ${secret}`);
            window.location.reload();   
        }
    }
}

function markKeyAs(letter, status) {
    const keys = document.querySelectorAll('.key');
    keys.forEach(key => {
        if (key.textContent === letter) {
            key.classList.add(status);
        }
    });
}
