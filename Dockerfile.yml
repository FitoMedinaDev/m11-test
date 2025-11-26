FROM node:20-alpine AS frontend-build
WORKDIR /app
COPY SalesApp.Client/package*.json .
RUN npm install
COPY SalesApp.Client .
ARG VITE_API_URL
ENV VITE_API_URL=$VITE_API_URL
RUN echo "VITE_API_URL=$VITE_API_URL" > .env.production
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS backend-build
WORKDIR /src
COPY SalesApp.Api/SalesApp.Api.csproj SalesApp.Api/
RUN dotnet restore SalesApp.Api/SalesApp.Api.csproj

COPY SalesApp.Api SalesApp.Api
WORKDIR /src/SalesApp.Api
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
WORKDIR /app

COPY --from=frontend-build /app/dist /usr/share/nginx/html

COPY --from=backend-build /app/publish /app/api

EXPOSE 80
EXPOSE 8080

CMD ["sh", "-c", "dotnet /app/api/SalesApp.Api.dll & nginx -g 'daemon off;'"]
