const { MongoClient } = require('mongodb');

// Connection string
// this connection string is for CosmosDB's MongoDB API
// but now the string will not work as the resource is deleted
const uri = "";

// Create a new MongoClient
const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });

async function run() {
    try {
        // Connect to the MongoDB cluster
        await client.connect();

        // Specify the database and collection
        const database = client.db('sample_database');
        const collection = database.collection('sample_collection');

        // Create a document to insert
        const doc = {
            name: "John Doe",
            email: "john.doe@example.com",
            age: 29,
            address: {
                street: "123 Main St",
                city: "Anytown",
                state: "Anystate",
                zip: "12345"
            }
        };

        // Insert the document into the collection
        const result = await collection.insertOne(doc);

        console.log(`New listing created with the following id: ${result.insertedId}`);
    } finally {
        // Close the connection to the MongoDB cluster
        await client.close();
    }
}

run().catch(console.dir);
