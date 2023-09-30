using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Text;
using System.Net;

public class accelerometer : MonoBehaviour
{
    public Text x;
    NetworkStream stream;
    TcpClient client;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x.text = Input.acceleration.x.ToString();
        // Кодируем сообщение в байты
        string message = Input.acceleration.x.ToString() + " ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Отправляем данные на сервер
        stream.Write(data, 0, data.Length);
    }

    public void click_start()
    {
        IPAddress serverIP = IPAddress.Parse("192.168.14.132");
        int serverPort = 555;

        // Создаем TCP-сокет
        client = new TcpClient();

        // Подключаемся к серверу
        client.Connect(serverIP, serverPort);

        // Получаем поток для отправки данных
        stream = client.GetStream();
    }

    public void click_stop()
    {
        // Закрываем соединение
        stream.Close();
        client.Close();
    }
    public void click_gas()
    {
        // Кодируем сообщение в байты
        string message = "gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Отправляем данные на сервер
        stream.Write(data, 0, data.Length);
    }
    public void oclick_gas()
    {
        // Кодируем сообщение в байты
        string message = "-gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Отправляем данные на сервер
        stream.Write(data, 0, data.Length);
    }
    public void click_drag()
    {
        // Кодируем сообщение в байты
        string message = "drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Отправляем данные на сервер
        stream.Write(data, 0, data.Length);
    }
    public void oclick_drag()
    {
        // Кодируем сообщение в байты
        string message = "-drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Отправляем данные на сервер
        stream.Write(data, 0, data.Length);
    }
}
