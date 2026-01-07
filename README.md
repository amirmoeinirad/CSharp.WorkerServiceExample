# Worker/Background Service
<p>In this example, a .NET worker service is converted to a Windows service.</p>
<p>Steps needed for the conversion:</p>
```csharp
		1) dotnet add package Microsoft.Extensions.Hosting.WindowsServices
		2) Add to Program.cs:
		   if (OperatingSystem.IsWindows())
          {
             builder.Services.AddSingleton<IHostLifetime, WindowsServiceLifetime>();
          }
		3) dotnet publish --configuration Release --output ./publish
		4) In Command Prompt: sc create MyWorkerService binPath= "C:\path\to\your\app\publish\yourapp.exe" or
		In PowerShell: New-Service -Name "MyWorkerService" -Binary "C:\path\to\your\app\publish\yourapp.exe"
		5) sc start MyWorkerService
		6) sc stop MyWorkerService
    7) sc delete MyWorkerService
```
