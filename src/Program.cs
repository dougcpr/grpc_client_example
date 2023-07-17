#region snippet2
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcRobot;
using GrpcGreeterClient;
using System.Reflection.Metadata.Ecma335;

#region snippet
// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:63620");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("Greeting: " + reply.Message);
// make a new client for the robot channel
var robotClient = new Robot.RobotClient(channel);
Console.WriteLine("Enter number 1 through 3: ");
string numberCaptured = Console.ReadLine();
var robotData = await robotClient.ReturnSingleDeviceDataAsync(
                  new RobotDataRequest { DeviceId = numberCaptured });
Console.WriteLine(robotData);
Console.WriteLine("Press any key to exit");
Console.ReadLine();

#endregion
#endregion
