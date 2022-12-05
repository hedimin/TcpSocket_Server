namespace TcpSocket_Server.IntegrationTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReceivesConnection()
    {
        //Arrange
        using TcpClient tcpClient = new TcpClient();
        
        //Act
        tcpClient.Connect("127.1.199.250",8888);
        
        //Assert
        Assert.That(tcpClient.Connected, Is.EqualTo(true));
    }

    [Test]
    public async Task ReceivesData()
    {
        //Arrange
        using TcpClient tcpClient = new TcpClient();
        await tcpClient.ConnectAsync("127.1.199.150",8888);
        
        //Act
        try
        {
            await using var stream = tcpClient.GetStream();
            Person person = new Person("Tom", "Message");
            var sentData = MessagePackSerializer.Serialize(person);
            await stream.WriteAsync(sentData);
        }
        catch (Exception e)
        {
            //Assert
            Assert.That(e == null, Is.EqualTo(true));
        }
        
    }
}