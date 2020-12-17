pipeline {
    agent any
    stages {
        stage("Build") {
            sh "dotnet build API/API.csproj"
        }
        stage("Test") {
            sh "dotnet test API/API.csproj"
        }
        stage("Deliver") {
            unstable "Delivery not yet implemented"
        }
    }
}