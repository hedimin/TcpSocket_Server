# TcpSocket_Server
This is a server that uses TCP/IP socket type. It takes data from the client and deserealizes it to the custom type Person, that has two fields: Name and Message. 

Server accepts any IP adress and 8888 port number:
```C#
var tcpListener = new TcpListener(IPAddress.Any, 8888);
```
After running the server, it will message about waiting for incoming connections:
![image](https://user-images.githubusercontent.com/112476754/205512558-497b3e9f-3c0e-448d-b16a-7f3191b7cce5.png)

Then, when server receives data, it is deserealized and processesed using Messagepack. As a result, writes into console two fields of object (Person type):

![image](https://user-images.githubusercontent.com/112476754/205513620-17ffcc3a-a330-4549-96d3-81844d43f2d2.png)
