# Goal of this Assignment
The goal of this assignment is to introduce you to Game-Server-Development using `C#` and the `TCP` and `UDP` Protocols.\
In total, our steps will include:
- Creating a small Time-Server using TCP Technology
- Building a Unity Client to connect to that server and receive the time
- Building a small Word-Game-Server using UDP Technology
- Building a Unity Client to connect to that server and play the game
- Building a Game similar to Agar.io
  - A game server that handles multiple player states
  - A unity client that 
    - can display those players' states
    - and forward any input to the server

# Grading
|Grade  |  Requirement |
|-------|:-------------|
|Summa Cum laude (A*)| Clean Code|
|Magna Cum Laude (A)| Agar.io playable in Multiplayer.\*\*|
|Cum Laude (B)| Agar.io playable with Server. Other players may behave glitchy.\*\*|
|Passed (C)| 6 Points of Agar.io done. (or Bonus for Clean Code\*)|
|Barely Passed (D)| UDP OpenWord-MMO Server and Client implemented. |
|Insufficient (E)| TCP Time Server and Client implemented. |
|Failed (F)| |
-------------------------------
Each of these grades expects the previous requirements as well as its own requirements to be fulfilled.\
\* Bonus for Clean Code requires ALL previous requirements to be fulfilled as well as the Code to be tidy and cleaned up.\
\*\* For these grades, it's more important to show that the network communication is happening. Gameplay goes second.

# Prerequisites / Requirements
- Make sure, that .NET Core 6 SDK is installed from https://www.microsoft.com/net/download
- I recommend to use Jetbrains Rider as an IDE.\
- Install Unity Hub & Unity.

For Testing you can either...
- Run multiple Clients on one Computer
- Use multiple computers on the same Local Area Network (LAN)
  - You can also use VPNs or Software like Hamachi to fake a Remote-LAN
- Or configure Port Forwarding in your Router for a certain Port or Port Range (Security Risk)
  - Make the router forward e.g. Port 4444 to your Computer's Local IP (usually 192.168.0.xxx)
  - Run the Server on Port 4444
  - Connect from the outside using your router's Public IP - [What Is my IP?](https://www.whatismyip.com) and the Port
- Or find a way of hosting your .NET Application somewhere in the Azure Cloud or so.
  - Unfortunately, I did not get to prepare this for this year :(

Assignments
- [1 - Time Server](./assignments/part1-timeserver.md)
- [2 - Time Client](./assignments/part2-timeclient.md)
- [3 - Open Word Server](./assignments/part3-openwordserver.md)
- [4 - Open word Client](./assignments/part4-openwordclient.md)
- [5 - Agar.io](./assignments/part5-agario.md)

# Videos and screenshots
Assignments 1-4:



https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/b1852026-0e36-477b-8e81-9d0baa537ca3



https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/45ed530e-e8b0-4142-923a-56ae256e1163




![Screenshot 2023-10-11 200459](https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/25142a26-4d95-42ab-8772-2311e27e72c3)
![Screenshot 2023-10-12 034600](https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/0b581858-5036-48f4-8d7d-42cb1a11017f)
![Screenshot 2023-10-11 230703](https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/80e79684-014e-4396-a7a9-64153f4cd575)
![image](https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/cd79b815-5158-4b9c-ac58-39c15ab7b275)
![Screenshot 2023-10-12 035606](https://github.com/forsbergsskola-se/gp21-22-0427-agario-sara/assets/20385915/ba10cce6-3e12-40a4-b346-38319f8fa998)




# Remarks
- In the first four exercises, we are not using any advanced classes for working with `Streams`
  - it is slightly tedious, but it will teach you about how `byte[]` can be used as buffers
- Refer to the Slides `030 - Internet` for details on TCP / UDP.
- Be wary of following Tutorials or downloading Sample Code. Chances are that it's extremely over-engineered and that I'll notice tha the code is not yours.
- Especially exercises 1-4 do not require any complex code.
- For Exercise 5, it's also best to start very small and slowly scale it up when required.


