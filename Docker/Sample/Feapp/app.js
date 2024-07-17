const express = require('express');
const app = express();
const port = 3232;
app.get('/', (req, res) => {
    res.send('Hello World-with changes!');
});
app.listen(port, () => {
    console.log(`Server running on port ${port}`);
});
