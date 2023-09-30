import socket
import time
import vgamepad as vg
import threading
import pyautogui

# Устанавливаем IP-адрес и порт сервера
server_ip = ""
server_port = 555

# Создаем TCP-сокет
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Привязываем сокет к IP-адресу и порту
server_socket.bind((server_ip, server_port))

# Ожидаем подключения клиента
server_socket.listen(1)
print("Ожидание подключения клиента...")
# Принимаем подключение от клиента
client_socket, client_address = server_socket.accept()
print("Подключение установлено:", client_address)
countup = 0
countpad = 0
x = 0
def update():
    while True:
        global x
        data = client_socket.recv(1024).decode("utf-8")
        for i in data.split():
            if i == "gas":
                gamepad.right_trigger_float(1)
                gamepad.update()
                print(i)
            elif i == "-gas":
                gamepad.right_trigger_float(0)
                gamepad.update()
                print(i)
            elif i == "drag":
                gamepad.left_trigger_float(1)
                gamepad.update()
                print(i)
            elif i == "-drag":
                gamepad.left_trigger_float(0)
                gamepad.update()
                print(i)
            elif float(i.replace(",", ".")) > 1:
                x = 1
            elif float(i.replace(",", ".")) < -1:
                x = -1
            else:
                x = float(i.replace(",", "."))

t = time.time()
gamepad = vg.VX360Gamepad()
th = threading.Thread(target=update)
th.start()

    # Получаем данные от клиента
while True:
    gamepad.left_joystick_float(x_value_float=x, y_value_float=0)
    gamepad.update()


# Закрываем соединение
client_socket.close()
server_socket.close()