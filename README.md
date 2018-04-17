# SoftEtherVPNCmdWrapper
SoftEther VPNCmd .NET wrapper, written in C#.
The new project is located in SoftEtherVPNCmdNETCore.

## Why?
There is no C# wrapper so I decieded to make one. This way by making a .NET Core 2.0 library, you can easily integrate the shared library in any .NET project and use vpncmd.

## How?
For now only the .NET Core version of library can be used.

Simple example of how to connect to VPN server if you have the connection already setup:
```
//Create the cmd object that can execute commands
cSoftEtherVPNCmdNETCore cmd = new cSoftEtherVPNCmdNETCore();
//Connect to VPN L10
cmd.ExecuteCommand("127.0.0.1", "CLIENT", "AccountConnect", "ConnectionName");
```

Get the status of the connection in Dictionary (key, value) format:
```
//Check connection status
var res = cmd.ExecuteCommandAndParse("127.0.0.1", "CLIENT", "AccountStatusGet", "ConnectionName");
```

`ExecuteCommand` returns the output of the command. You should familiarize yourself with *vpncmd* utility, as the ExecuteCommand starts the process of *vpncmd* with some arguments like type of connection CLIENT, SERVER, HUB. You can pass extra arguments to the utility also.
General usage is `ExecuteCommand(clientHostPort, type, command, parametersOfThatCommand, extraArguments)`.

## Contributions?
Contributions are always welcome. The idea is to utilize `ExecuteCommand` where it can be utilized and implement interfaces `iVPNClient` and `iVPNServer`.
In order to contribute just for the repo, do your changes and open a pull request.
