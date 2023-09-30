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
        // Êîäèðóåì ñîîáùåíèå â áàéòû
        string message = Input.acceleration.x.ToString() + " ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Îòïðàâëÿåì äàííûå íà ñåðâåð
        stream.Write(data, 0, data.Length);
    }

    public void click_start()
    {
        IPAddress serverIP = IPAddress.Parse("");
        int serverPort = 555;

        // Ñîçäàåì TCP-ñîêåò
        client = new TcpClient();

        // Ïîäêëþ÷àåìñÿ ê ñåðâåðó
        client.Connect(serverIP, serverPort);

        // Ïîëó÷àåì ïîòîê äëÿ îòïðàâêè äàííûõ
        stream = client.GetStream();
    }

    public void click_stop()
    {
        // Çàêðûâàåì ñîåäèíåíèå
        stream.Close();
        client.Close();
    }
    public void click_gas()
    {
        // Êîäèðóåì ñîîáùåíèå â áàéòû
        string message = "gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Îòïðàâëÿåì äàííûå íà ñåðâåð
        stream.Write(data, 0, data.Length);
    }
    public void oclick_gas()
    {
        // Êîäèðóåì ñîîáùåíèå â áàéòû
        string message = "-gas ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Îòïðàâëÿåì äàííûå íà ñåðâåð
        stream.Write(data, 0, data.Length);
    }
    public void click_drag()
    {
        // Êîäèðóåì ñîîáùåíèå â áàéòû
        string message = "drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Îòïðàâëÿåì äàííûå íà ñåðâåð
        stream.Write(data, 0, data.Length);
    }
    public void oclick_drag()
    {
        // Êîäèðóåì ñîîáùåíèå â áàéòû
        string message = "-drag ";
        byte[] data = Encoding.UTF8.GetBytes(message);

        // Îòïðàâëÿåì äàííûå íà ñåðâåð
        stream.Write(data, 0, data.Length);
    }
}
