
# Серверная часть приложения для продажи недвижимости

Этот документ описывает шаги по установке и настройке серверной части приложения для продажи недвижимости, использующего ASP.NET Core и MySQL.

---

## Установка на Linux

### 1. Обновление пакетов

Для начала обновите списки пакетов:
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

Для автоматического запуска приложения с использованием `systemd`, создайте службу.

### 1. Создание файла службы

Создайте новый файл службы:
```bash
sudo nano /etc/systemd/system/Ijora.RestAPI.service
```

Добавьте в файл следующий конфиг:

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

Замените:
- `/var/www/fastuser/data/www/manzilRestAPI` на путь к вашему приложению.
- `your_user` на имя пользователя, под которым будет работать приложение.

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
