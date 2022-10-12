FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["ShopOnline.Web/ShopOnline.Web.csproj", "ShopOnline.Web/"]
RUN dotnet restore "ShopOnline.Web/ShopOnline.Web.csproj"
COPY . .
WORKDIR "/src/ShopOnline.Web"
RUN dotnet build "ShopOnline.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopOnline.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ShopOnline.Web/nginx.conf /etc/nginx/nginx.conf
