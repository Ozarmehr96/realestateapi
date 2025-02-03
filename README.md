Серверная часть приложения продажи недвижимости.

#Устнановка на Linux 
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-8.0

sudo apt install zlib1g -- зависимости

#Установка MySQL на Ubuntu, шаги выполнения:
1. Обновление пакетов
sudo apt update
2. Установка MySQL
sudo apt install mysql-server -y
3. Запуск MySQLbash
sudo systemctl start mysql
sudo systemctl enable mysql
4. Настройка безопасности MySQL
sudo mysql_secure_installation
Установки пароля root и настройки безопасности.
5. Проверка статуса MySQL
sudo systemctl status mysql

#Запуск приложения 
dotnet Ijora.RestAPI.dll

#Создание службы
sudo nano /etc/systemd/system/Ijora.RestAPI.service

[Unit]
Description=ASP.NET Core RestAPI Продажа недвижимости
After=network.target

[Service]
WorkingDirectory=/var/www/fastuser/data/www/manzilRestAPI
ExecStart=/usr/bin/dotnet /var/www/fastuser/data/www/manzilRestAPI/Ijora.RestAPI.dll
Restart=always
User=your_user
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target

3. Перезагрузка systemd
После создания службы нужно перезагрузить systemd, чтобы он распознал новый файл службы:
sudo systemctl daemon-reload

4. Запуск службы
Теперь можно запустить приложение через systemd:

sudo systemctl start Ijora.RestAPI.service

5. Настройка автоматического запуска при старте системы
Чтобы приложение запускалось автоматически при старте системы, нужно выполнить команду:
sudo systemctl enable Ijora.RestAPI.service


6. Проверка статус службы
Чтобы проверить, работает ли служба:
sudo systemctl status Ijora.RestAPI.service

7. Логи приложения
sudo journalctl -u  Ijora.RestAPI.service -f
