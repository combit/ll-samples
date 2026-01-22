# Build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/export

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/export ./

USER root

# Install List & Label CrossPlatform native dependencies
RUN apt-get update && \
    apt-get install -y \
        libc6 \
        libfontconfig1 \
        libfreetype6 \
        libpng16-16 \
        libjpeg62-turbo \
        libgif7 && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# If List & Label needs fonts (for text rendering)
RUN apt-get install -y fonts-dejavu-core && rm -rf /var/lib/apt/lists/*

ENTRYPOINT ["dotnet", "LLPDFGenerator.dll"]