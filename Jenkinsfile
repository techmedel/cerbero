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

                bat "del \"${WORKSPACE}\\bin\\Debug\\netcoreapp2.2\\publish\\web.config"
                bat "xcopy \"${WORKSPACE}\\src\\bin\\Debug\\netcoreapp2.2\\publish\" \"C:/proyectos/${JOB_NAME}\" /O /X /E /H /K /Y"
                bat "%SYSTEMROOT%/System32/inetsrv/appcmd start apppool /apppool.name:\"${JOB_NAME}\""
                bat "%SYSTEMROOT%/System32/inetsrv/appcmd start site /site.name:\"${JOB_NAME}\""
            }
        }
        stage('Notification') {
            steps {
                slackSend message: "Se ah actualizado \"${JOB_NAME}\""
            }
        }
    }
}