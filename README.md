# Custom Weather Client Tool

This is a custom weather client tool

## Run Locally

Clone the project

```console
  git clone https://github.com/kailash-behera/Custom-Weather-Client-Tool.git
```

Go to the project directory

```console
  cd Custom-Weather-Client-Tool
```

Install dependencies

```console
  dotnet restore
```

Run project

```console
  dotnet run
```

Nuget Package Build

```console
  dotnet pack
```

Install the weather cli tool to the system globaly

```console
  dotnet tool install --global --add-source ./nupkg CustomWeatherClientTool
```

Now the CLI Tool installed globaly. So use it like below

```console
  > weather
```

## Tech Stack

- .NET Core 7
- Console Application
