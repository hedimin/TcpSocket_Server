//Creating server
var tcpListener = new TcpListener(IPAddress.Any, 8888);
try
{
    //Starting the server
    tcpListener.Start();
    Console.WriteLine("Server is currently run, waiting for incoming connections");
    while (true)
    {
        //Accepting connections from the clients
        using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        //Getting stream to deserialize data
        await using var stream = tcpClient.GetStream();
        //Using own static method to deserialize data in order to deal with message framing
        var deserealizedPerson = DeserializeHelper.Deserealize(stream);
        //Using another static method to write person's name and message in console
        DeserializeHelper.WriteMessage(deserealizedPerson.Result);
    }
}
finally
{
    tcpListener.Stop();
}

//Type for de/serealizing
[MessagePackObject]
public class Person
    {
        [Key(0)]
        public string Name { get; set; }
        [Key(1)]
        public string Message { get; set; }

        public Person(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }

    
