pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/*.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/*.sln\""
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
        stage('Publish') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}