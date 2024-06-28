# Sort score and name of players print the top 10

players = {
    "Jadeja": 65,
    "Bumrah": 60,
    "Shami": 55,
    "Sachin": 95,
    "Aswin": 95,
    "Rohit": 90,
    "Dhoni": 85,
    "Rahul": 80,
    "Shikhar": 75,
    "Hardik": 70,
    "Ishant": 50,
    "Ashwin": 45,
    "Pant": 40,
    "Kohli": 35,
    "Rahane": 30,
    "Pujara": 25,
    "Rohit": 20,
    "Gill": 15,
    "Siraj": 10,
    "Axar": 5
}

#sort by score , if score is same then sort by name
sorted_players = sorted(players.items(), key=lambda x: (-x[1], x[0]))

top_10_players = sorted_players[:10]

for player, score in top_10_players:
    print(f"{player}: {score}")
