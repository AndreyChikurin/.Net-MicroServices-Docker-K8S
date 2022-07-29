![Снимок экрана (20)](https://user-images.githubusercontent.com/87278338/181697753-aea360f4-a7b5-4202-a5fb-152ae67d4a17.png)
![Снимок экрана (19)](https://user-images.githubusercontent.com/87278338/181697771-f6794561-4207-48be-bfd9-80c99bf27679.png)

## Процесс сборки

# Запуск docker контейнеров
1 - docker build -t имяДокерХаба/platformservice .
2 - docker push имяДокерХаба/platformservice
3 - docker build -t имяДокерХаба/commandservice .
4 - docker push имяДокерХаба/commandservice

# Запуск K8S
1 - Поменять названия image в yaml файлах поменять с hrago на имяДокерХаба
2 - kubectl apply -f platforms-depl.yaml
3 - kubectl apply -f commands-depl.yaml
4 - kubectl apply -f platforms-np-srv.yaml
5 - kubectl apply -f ingress-srv.yaml
6 - kubectl apply -f local-pvc.yaml
7 - добавить строчку в файл host ![image](https://user-images.githubusercontent.com/87278338/181699618-c58ce878-214c-4cfb-a512-5b8e63bf699b.png)
8 - Создать пароль для базы kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55worD!"
9 - kubectl apply -f mssql-plat-depl.yaml
10 - Поключиться к БД через SQL ManagemenStudio (localhost,1433 sa pa55worD!)
11 - kubectl apply -f rabbitmq-depl.yaml
