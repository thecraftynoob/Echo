# Echo Application

A simple Windows application that echoes back user text input with timestamps.

## Prerequisites

### Option 1: .NET 6.0 SDK (Recommended)
1. Download and install .NET 6.0 SDK from: https://dotnet.microsoft.com/download/dotnet/6.0
2. Choose the "SDK" version for Windows x64
3. After installation, restart your command prompt/PowerShell
4. Verify installation by running: `dotnet --version`

### Option 2: Visual Studio (Alternative)
1. Install Visual Studio Community (free) from: https://visualstudio.microsoft.com/vs/community/
2. Make sure to include ".NET desktop development" workload during installation

## Building and Running

### Using .NET CLI:
```bash
# Restore dependencies
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run
```

### Using Visual Studio:
1. Open `EchoApp.csproj` in Visual Studio
2. Press F5 to build and run

## Features

- **Text Input**: Enter text in the input field
- **Echo Functionality**: Click "Echo" button or press Enter to echo the text
- **Timestamp**: Each echoed text includes a timestamp
- **Clear Function**: Clear both input and output with the "Clear" button
- **Modern UI**: Clean, responsive Windows Forms interface

## Usage

1. Launch the application
2. Type some text in the input field
3. Click "Echo" or press Enter
4. See your text echoed back with a timestamp
5. Use "Clear" to reset the form

## Project Structure

- `EchoApp.csproj` - Project configuration file
- `Program.cs` - Application entry point
- `MainForm.cs` - Main form with UI and echo functionality


Angela helped me!!!!!!!!!!!

