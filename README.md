# IoT-Manager

**IoT-Manager** is a cross-platform application for **home construction and IoT device planning**,  
built with **.NET**, **Avalonia** (Desktop), and **.NET MAUI** (Mobile), including **MQTT** integration for real-time communication with IoT devices.

---

## ✨ Features

- **Cross-platform**
  - Windows `.exe`
  - macOS `.dmg`
  - Android `.apk`
  - iOS (via macOS build)
- **MQTT Communication** (via [MQTTnet](https://github.com/dotnet/MQTTnet))
  - Connect to MQTT broker
  - Receive and send messages
- **IoT Device Planning**
  - Place devices in a floor plan
  - Plan cables and receivers
- **Future: Augmented Reality**
  - Virtually place devices in the room
  - Save layout in a proprietary format

---

## 📂 Project Structure

```
IoT-Manager/
 ├── IoT-Manager.sln                # Solution file
 ├── IoT-Manager.Avalonia/           # Avalonia Desktop App
 ├── IoT-Manager.Mobile/             # .NET MAUI Mobile App
 ├── IoT-Manager.Shared/             # Shared logic (ViewModels, Models, Services)
 │    └── ViewModels/
 │         └── IotViewModel.cs      # MQTT ViewModel
 └── README.md
```

---

## 🚀 Installation & Development

### 1. Requirements

- [.NET 7+ SDK](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/) or Visual Studio 2022
- Optional: Android SDK / Xcode for mobile builds
- Install Avalonia and MAUI templates:

```bash
dotnet new install Avalonia.Templates
dotnet workload install maui
dotnet workload install maui-android maui-ios
```

---

### 2. Install MQTTnet package

```bash
dotnet add IoT-Manager.Shared package MQTTnet
dotnet add IoT-Manager.Avalonia package MQTTnet
dotnet add IoT-Manager.Mobile package MQTTnet
```

---

### 3. Run Desktop App

**Windows**:
```bash
cd IoT-Manager.Avalonia
dotnet run
```

**macOS**:
```bash
cd IoT-Manager.Avalonia
dotnet run
```

---

### 4. Run Mobile App

**Android**:
```bash
cd IoT-Manager.Mobile
dotnet build -t:Run -f net7.0-android -p:Platform=Android
```

**iOS** (macOS with Xcode required):
```bash
cd IoT-Manager.Mobile
dotnet build -t:Run -f net7.0-ios
```

---

## 📦 Build & Deployment

### Windows `.exe`
```bash
dotnet publish IoT-Manager.Avalonia -c Release -r win-x64 --self-contained true -o publish/windows
```

### macOS `.dmg`
```bash
dotnet publish IoT-Manager.Avalonia -c Release -r osx-x64 --self-contained true -o publish/macos
hdiutil create -volname IoT-Manager -srcfolder publish/macos -ov -format UDZO IoT-Manager.dmg
```

### Android `.apk`
```bash
dotnet publish IoT-Manager.Mobile -c Release -f net7.0-android -p:Platform=Android -o publish/android
```

---

## 🛠 Architecture

- **MVVM Pattern**
- **Shared Logic**: `IoT-Manager.Shared` contains ViewModels, Models, and Services
- **Avalonia**: Desktop UI (Windows, macOS, Linux)
- **MAUI**: Mobile UI (Android, iOS)

---

## 📡 MQTT Example (IotViewModel.cs)

```csharp
public async Task ConnectAsync(string brokerHost, int port = 8883)
{
    var options = new MqttClientOptionsBuilder()
        .WithTcpServer(brokerHost, port)
        .WithCleanSession()
        .Build();

    await _client.ConnectAsync(options, CancellationToken.None);
    await _client.SubscribeAsync("house/+/status");
}
```

---

## 📜 License

© 2025
