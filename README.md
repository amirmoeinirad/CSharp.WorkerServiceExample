# Worker/Background Service
<p>In this example, a <strong>.NET Worker service</strong> is converted to a <strong>Windows service</strong>.</p>
<p>Steps needed for the conversion:</p>
1) dotnet add package Microsoft.Extensions.Hosting.WindowsServices<br>
2) Add to Program.cs:

```
	if (OperatingSystem.IsWindows())
    {
    builder.Services.AddSingleton<IHostLifetime, WindowsServiceLifetime>();
    }
```

3) dotnet publish --configuration Release --output ./publish<br>
4) In Command Prompt: sc create MyWorkerService binPath= "C:\path\to\your\app\publish\yourapp.exe" or<br>
5) In Command Prompt: sc start MyWorkerService<br>
6) In Command Prompt: sc stop MyWorkerService<br>
7) In Command Prompt: sc delete MyWorkerService<br>
