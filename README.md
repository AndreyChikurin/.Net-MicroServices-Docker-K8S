![Снимок экрана (20)](https://user-images.githubusercontent.com/87278338/181697753-aea360f4-a7b5-4202-a5fb-152ae67d4a17.png)
![Снимок экрана (19)](https://user-images.githubusercontent.com/87278338/181697771-f6794561-4207-48be-bfd9-80c99bf27679.png)

## Процесс сборки

# Запуск docker контейнеров
1. docker build -t имяДокерХаба/platformservice .
2. docker push имяДокерХаба/platformservice
3. docker build -t имяДокерХаба/commandservice .
4. docker push имяДокерХаба/commandservice

# Запуск K8S
1. Поменять названия image в yaml файлах поменять с hrago на имяДокерХаба
2. kubectl apply -f platforms-depl.yaml
3. kubectl apply -f commands-depl.yaml
4. kubectl apply -f platforms-np-srv.yaml
5. kubectl apply -f ingress-srv.yaml
6. kubectl apply -f local-pvc.yaml
7. добавить строчку в файл host ![image](https://user-images.githubusercontent.com/87278338/182035247-aca99d7e-85c7-414c-8fa3-24a75a6a8cfc.png)
8. Создать пароль для базы kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55worD!"
9. kubectl apply -f mssql-plat-depl.yaml
10. Поключиться к БД через SQL ManagemenStudio (localhost,1433 sa pa55worD!)
11. kubectl apply -f rabbitmq-depl.yaml

# Запросы для проверки
## K8S Platform Service (Node Port)
1. Get All Platform http://localhost:32650/api/platforms/ (порт проверяется в созданном сервисе k8s)
2. Create Platform http://localhost:32650/api/platforms/ {"name": "Docker", "publisher": "Docker", "cost": "Free" }
## K8S Platform Service (Njinx)
1. Get All Platform http://acme.com/api/platforms/
2. Create Platform http://acme.com/api/platforms/ {"name": "Docker", "publisher": "Docker", "cost": "Free" }
## K8S Commands Service (Njinx)
1. Get All Platform http://acme.com/api/c/platforms/
2. Create Command for Platform http://acme.com/api/c/platforms/8/commands/ {"HowTo": "Push a docker container to hub", "CommandLine": "docker push <name of container>"}
3. Get all commands for platform http://acme.com/api/c/platforms/номерПлатформы/commands/
## Local Command Service
1. Get All Platform https://localhost:6001/api/c/platforms/
2. Get All Commands for Platform https://localhost:6001/api/c/platforms/номерПлатформы/commands
3. Get Command for Platform https://localhost:6001/api/c/platforms/номерПлатформы/commands/номерКоманды
4. Create command for platform https://localhost:6001/api/c/platforms/номерПлатформы/commands {"HowTo": "Push a docker container to hub", "CommandLine": "docker push <name of container>"}
## Local Platform Service
1. Get All Platforms https://localhost:5001/api/platforms/
2. Create Platform https://localhost:5001/api/platforms/  {"name": "Docker", "publisher": "Docker", "cost": "Free" }
