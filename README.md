# SharpShell
A Simple Reverse Shell Listener written in C# that accepts connections to a TCP port and runs cmd.exe

To Compile
1. Open the SharpShell.sln file in Visual Studio -> Click "Build Solution"

To Run
1. Run the executable on the client you would like a remote command shell access to. By default the application listens on port 12345.
2. Use a utility like netcat.exe to connect to your listener on port 12345

**c:\> netcat.exe 10.0.0.55 12345**

To Modify
1. Edit the source code "Program.cs" and change the default port number. Then click "Build Solution"


![image](https://github.com/kpomeroy1979/SharpShell/assets/33209502/73fce603-9e24-46cd-92d5-963bd879c3cb)
