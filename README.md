
# Серверная часть приложения для продажи недвижимости

Этот документ описывает шаги по установке и настройке серверной части приложения для продажи недвижимости, использующего ASP.NET Core и MySQL.

---

## Установка на Linux

### 1. Обновление пакетов

Для начала обновляем списки пакетов:
```bash
sudo apt-get update
```

### 2. Установка ASP.NET Core Runtime 8.0

Установка необходимых компонентов для работы с приложением:
```bash
sudo apt-get install -y aspnetcore-runtime-8.0
```

### 3. Установка зависимостей

```bash
sudo apt install zlib1g
```

---

## Установка MySQL на Ubuntu

### 1. Обновление пакетов

Перед установкой MySQL :
```bash
sudo apt update
```

### 2. Установка MySQL

Установка сервер MySQL:
```bash
sudo apt install mysql-server -y
```

### 3. Запуск MySQL

Запускаем и включаем MySQL для автозапуска:
```bash
sudo systemctl start mysql
sudo systemctl enable mysql
```

### 4. Настройка безопасности MySQL

Настройки безопасности и установки пароля для пользователя `root`:
```bash
sudo mysql_secure_installation
```

### 5. Проверка статуса MySQL

Проверка, что MySQL работает корректно:
```bash
sudo systemctl status mysql
```

---

## Запуск приложения

### 1. Запуск приложения ASP.NET Core

Для запуска приложения нужно выполнить команду:
```bash
dotnet Ijora.RestAPI.dll
```

---

## Создание службы для автозапуска приложения

Для автоматического запуска приложения с использованием `systemd`, нужно службу.

### 1. Создание файла службы

Создание нового файла службы:
```bash
sudo nano /etc/systemd/system/Ijora.RestAPI.service
```

Добавляем конфиг:

```ini
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
```

Объянение:
- `/var/www/fastuser/data/www/manzilRestAPI` путь к приложению.
- `your_user` имя пользователя, под которым будет работать приложение.

### 2. Перезагрузка `systemd`

После создания службы нужно перезагрузить `systemd`, чтобы он распознал новый файл службы:
```bash
sudo systemctl daemon-reload
```

### 3. Запуск службы

Теперь можно запустить приложение через `systemd`:
```bash
sudo systemctl start Ijora.RestAPI.service
```

### 4. Настройка автозапуска при старте системы

Для того чтобы приложение запускалось автоматически при старте системы:
```bash
sudo systemctl enable Ijora.RestAPI.service
```

### 5. Проверка статуса службы

Чтобы проверить, работает ли служба:
```bash
sudo systemctl status Ijora.RestAPI.service
```

### 6. Логи приложения

Для просмотра логов приложения:
```bash
sudo journalctl -u Ijora.RestAPI.service -f
```

---

Теперь приложение будет автоматически запускаться при старте системы и работать в фоновом режиме как служба.


# Настройка Nginx для работы с ASP.NET Core

## 1. Открытие портов в файрволе

Необходимо открыть порты, чтобы приложение было доступно извне:

```bash
sudo ufw allow 5000/tcp   # Порт, на котором будет запускаться приложение
sudo ufw allow 80/tcp     # Порт для Nginx
```

Проверить текущий статус файрвола можно так:

```bash
sudo ufw status
```

## 2. Настройка Kestrel для прослушивания внешних адресов

В файле `appsettings.json` необходимо добавить настройки для Kestrel:

```json
"Kestrel": {
  "Endpoints": {
    "Http": {
      "Url": "http://0.0.0.0:5000"
    }
  }
}
```

Это позволит Kestrel прослушивать внешний интерфейс на порту 5000.

## 3. Настройка Nginx

Создайте файл конфигурации Nginx в директории `/etc/nginx/conf.d/`:

```bash
sudo nano /etc/nginx/conf.d/Ijora.RestAPI.conf
```

Добавьте следующую конфигурацию:

```nginx
server {
    listen 80;  # Порт, на который будет проксироваться запросы
    server_name mydomain.com;  # Домен сайта

    location / {
        proxy_pass http://localhost:5000;  # Прокси на Kestrel
        proxy_set_header Host $host;
        proxy_set_header X-Real-IP $remote_addr;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    }
}
```

## 4. Перезапуск Nginx

После добавления конфигурации необходимо перезапустить Nginx:

```bash
sudo systemctl restart nginx
```

Теперь приложение должно быть доступно через Nginx на порту 80, а запросы будут перенаправляться на Kestrel, работающий на порту 5000.

