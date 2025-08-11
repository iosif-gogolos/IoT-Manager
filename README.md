# IoTPlanner

**IoTPlanner** ist eine plattformübergreifende Anwendung für **Hausbau- und IoT-Planung**,  
erstellt mit **.NET**, **Avalonia** (Desktop) und **.NET MAUI** (Mobile), inklusive **MQTT**-Integration für die Echtzeit-Kommunikation mit IoT-Geräten.

---

## ✨ Features

- **Plattformübergreifend**
  - Windows `.exe`
  - macOS `.dmg`
  - Android `.apk`
  - iOS (via macOS Build)
- **MQTT Kommunikation** (via [MQTTnet](https://github.com/dotnet/MQTTnet))
  - Verbindung zu MQTT-Broker
  - Nachrichten empfangen & senden
- **IoT Geräteplanung**
  - Geräte platzieren
  - Kabel & Receiver planen
- **Zukunft: Augmented Reality**
  - Geräte im Raum virtuell platzieren
  - Layout speichern in proprietärem Format

---

## 📂 Projektstruktur

```
IoTPlanner/
 ├── IoTPlanner.sln                # Solution File
 ├── IoTPlanner.Avalonia/           # Avalonia Desktop App
 ├── IoTPlanner.Mobile/             # .NET MAUI Mobile App
 ├── IoTPlanner.Shared/             # Gemeinsame Logik (ViewModels, Models, Services)
 │    └── ViewModels/
 │         └── IotViewModel.cs      # MQTT ViewModel
 └── README.md
```

---

## 🚀 Installation & Entwicklung

### 1. Voraussetzungen

- [.NET 7+ SDK](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/) oder Visual Studio 2022
- Optional: Android SDK / Xcode für mobile Builds
- Avalonia und MAUI Templates installieren:

```bash
dotnet new install Avalonia.Templates
dotnet workload install maui
dotnet workload install maui-android maui-ios
```

---

### 2. MQTTnet Paket installieren

```bash
dotnet add IoTPlanner.Shared package MQTTnet
dotnet add IoTPlanner.Avalonia package MQTTnet
dotnet add IoTPlanner.Mobile package MQTTnet
```

---

### 3. Desktop starten

**Windows**:
```bash
cd IoTPlanner.Avalonia
dotnet run
```

**macOS**:
```bash
cd IoTPlanner.Avalonia
dotnet run
```

---

### 4. Mobile starten

**Android**:
```bash
cd IoTPlanner.Mobile
dotnet build -t:Run -f net7.0-android -p:Platform=Android
```

**iOS** (nur unter macOS mit Xcode):
```bash
cd IoTPlanner.Mobile
dotnet build -t:Run -f net7.0-ios
```

---

## 📦 Build & Deployment

### Windows `.exe`
```bash
dotnet publish IoTPlanner.Avalonia -c Release -r win-x64 --self-contained true -o publish/windows
```

### macOS `.dmg`
```bash
dotnet publish IoTPlanner.Avalonia -c Release -r osx-x64 --self-contained true -o publish/macos
hdiutil create -volname IoTPlanner -srcfolder publish/macos -ov -format UDZO IoTPlanner.dmg
```

### Android `.apk`
```bash
dotnet publish IoTPlanner.Mobile -c Release -f net7.0-android -p:Platform=Android -o publish/android
```

---

## 🛠 Architektur

- **MVVM Pattern**
- **Shared Logic**: `IoTPlanner.Shared` enthält ViewModels, Models und Services
- **Avalonia**: Desktop UI (Windows, macOS, Linux)
- **MAUI**: Mobile UI (Android, iOS)

---

## 📡 MQTT Beispiel (IotViewModel.cs)

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

## 📜 Lizenz

MIT License © 2025 Dein Name