# .NET 6 JavaScript Rules Engine with Jint

## Overview

In the past, when I've needed a user-defined rules engine in .NET, [I've explored writing a custom domain specific language using the Irony language implementation kit](https://charliedigital.com/2010/10/01/irony-net-language-implementation-kit/). But mostly, I've used [SpringFramework.NET](https://www.springframework.net/) which includes an awesome [expression evaluation engine](https://www.springframework.net/doc-latest/reference/html/expressions.html).  The expression evaluation engine allowed writing string-based rules and even inline functions which allowed building a basic, user-configurable rules engine in .NET without too much fuss.

While the repository [still shows commits](https://github.com/spring-projects/spring-net/commits/main), the library seems to have fizzled out and [the maintainer has handed the reigns over to the community](https://github.com/spring-projects/spring-net/issues/187#issuecomment-891153665).

What to do if one needs a user-configurable, scriptable rules engine in 2022 with .NET 6?

Enter [Jint](https://github.com/sebastienros/jint).

> Jint is a Javascript interpreter for .NET which can run on any modern .NET platform as it supports .NET Standard 2.0 and .NET 4.6.1 targets (and up). Because Jint neither generates any .NET bytecode nor uses the DLR it runs relatively small scripts really fast.

This repository provides a sandbox solution which implements a front-end UI and back-end API For testing Jint for execution of user-defined JavaScript in .NET.

## Layout

- `/api` .NET 6 Web API in C#
- `/web` React with MUI scaffolded with Vite

## Run

Web

```
cd web
yarn 
yarn run dev
```

API

```
cd api
dotnet tool install SwashBuckle.AspNetCore.Cli
dotnet run
```

Alternatively, if you do not want to [install .NET SDKs](https://dotnet.microsoft.com/en-us/download) on your local machine (available for Mac/Linux/Windows), build the Docker container instead.

```
docker-compose up
```

If you use `docker-compose`, you will still need to `yarn run dev` (the UI hasn't been containerized as I would; normally push that into S3 or Azure Storage Static Web Sites and serve from a CDN so no need to containerize it.)

The front-end application loads at `http://localhost:3000` by default.

The back-end Swagger UI is available at `https://localhost:5001/swagger/index.html`.

## Before Putting This In Production... 

Before you put this into production, consider the following gaps:

- **Security**: need to lint or otherwise check the code
- **Logging/Observability/Telemetry**: need to add visibility to the scale out and performance.
- **Contrainting execution**: see the Jint documentation to better understand the controls available for constraining execution of JavaScript.

