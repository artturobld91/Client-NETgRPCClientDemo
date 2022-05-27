// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcServiceDemo;

Console.WriteLine("Hello gRPC!");

var channel = GrpcChannel.ForAddress("https://localhost:7024");
var client = new Greeter.GreeterClient(channel);

var response = await client.SayHelloAsync(
    new HelloRequest
    {
        Name = "Art"
    }
);

Console.WriteLine($"Response size (Bytes): {response.CalculateSize().ToString()}");
Console.WriteLine($"Response from server: {response.Message}");