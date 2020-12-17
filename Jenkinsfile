pipeline {
    agent any
    triggers {
        pollSCM("* * * * *")
    }
    stages {
        stage("Build") {
            steps {
                sh "dotnet build API/API.csproj"
            }
        }
        stage("Test") {
            steps {
                sh "dotnet test API/API.csproj"
            }
        }
        stage("Deliver") {
            steps {
                unstable "Delivery not yet implemented"
            }
        }
    }
}