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
                bat "\"C:/Program Files/dotnet/dotnet.exe\" publish"
            }
        }
        stage('Publish') {
            steps {
                echo 'Deploying....'
                echo "${JOB_NAME}"
                echo "${BUILD_TAG}"
                echo "${BRANCH_NAME}"
            }
        }
    }
}