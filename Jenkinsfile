pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore"
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build"
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