namespace TcpSocket_Server;

public static class DeserializeHelper 
{
    //Method to deal with message framing, write data from the stream to array of bytes so it would be able to
    //deserialize it
    private static async Task<byte[]> ConverteToBytes(NetworkStream stream)
    {
        await using var ms = new MemoryStream();
        byte[] bytesData = null;
        int count = 0;
        do
        {
            byte[] buffer = new byte[1024];
            count = await stream.ReadAsync(buffer,0,1024);
            ms.Write(buffer,0,count);
            
        } while (stream.CanRead && count > 0);
        
        return bytesData = ms.ToArray();
    }
    //Deserializing array of bytes to the Person type
    public static async Task<Person> Deserealize(NetworkStream stream)
    {
        var incomeData = await ConverteToBytes(stream);
        var incomePerson = MessagePackSerializer.Deserialize<Person>(incomeData);
        return incomePerson;
    }
    
    //Writing Person type object's fields in console
    public static void WriteMessage(Person person)
    {
        Console.WriteLine($"Income message from {person.Name}: '{person.Message}'");
    }
}