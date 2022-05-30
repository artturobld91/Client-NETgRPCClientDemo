// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcServiceDemo;
using NETGrpcServiceDemo.Protos;

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

Console.WriteLine("Demo gRPC!");

var channeldemo = GrpcChannel.ForAddress("https://localhost:7024");
var clientdemo = new Demo.DemoClient(channeldemo);

var responsedemo = await clientdemo.DemoRPCAsync(
    new DemoRequest
    {
        DesiredResults = 2
    }
);

Console.WriteLine($"Demo Response size (Bytes): {responsedemo.CalculateSize().ToString()}");
Console.WriteLine($"Demo Response from server: {responsedemo.DemoList}");