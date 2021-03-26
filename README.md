## IG Web API .NET Sample

### Overview
This repository contains a .NET WPF sample application written in C# to access the IG REST and Streaming APIs.

### Getting started

1) Clone the repository

2) Create a new file **IgWebApiConnection.config** in the SampleWPFTrader folder containing your Connection Data:

```xml
  <IgWebApiConnection>
    <!-- environment = demo|live -->
    <add key="environment" value="demo" />
    <add key="username" value="mydemouser" />
    <add key="password" value="mydemopassword" />
    <add key="apikey" value="3b577d884a6ba7d2b0d036f443bec954ebf3cf14" />
  </IgWebApiConnection>
```

3) Open the solution with Visual Studio 2015 or later.

4) Use the NuGet Package manager if necessary to update assembly references.

5) Build and run the sample application.

### Solution details

**SampleWPFTrader** contains the WPF implementation.

**IGWebApiClient** contains a REST and streaming client with DTO classes to access the IG Web API.

**packages** contains 3rd party libraries located under **packages/3rdPartyDlls** (e.g. Lightstreamer client's DotNetClient_N2.dll) and those managed by NuGet's package manager.

