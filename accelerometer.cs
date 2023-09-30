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
        // �������� ��������� � �����
        string message = Input.acceleration.x.ToString() + " ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // ���������� ������ �� ������
        stream.Write(data, 0, data.Length);
    }

    public void click_start()
    {
        IPAddress serverIP = IPAddress.Parse("192.168.14.132");
        int serverPort = 555;

        // ������� TCP-�����
        client = new TcpClient();

        // ������������ � �������
        client.Connect(serverIP, serverPort);

        // �������� ����� ��� �������� ������
        stream = client.GetStream();
    }

    public void click_stop()
    {
        // ��������� ����������
        stream.Close();
        client.Close();
    }
    public void click_gas()
    {
        // �������� ��������� � �����
        string message = "gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // ���������� ������ �� ������
        stream.Write(data, 0, data.Length);
    }
    public void oclick_gas()
    {
        // �������� ��������� � �����
        string message = "-gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // ���������� ������ �� ������
        stream.Write(data, 0, data.Length);
    }
    public void click_drag()
    {
        // �������� ��������� � �����
        string message = "drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // ���������� ������ �� ������
        stream.Write(data, 0, data.Length);
    }
    public void oclick_drag()
    {
        // �������� ��������� � �����
        string message = "-drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // ���������� ������ �� ������
        stream.Write(data, 0, data.Length);
    }
}
