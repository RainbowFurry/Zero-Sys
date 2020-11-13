using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ZeroSys.Manager
{
    /// <summary>
    /// MQTTManager
    /// </summary>
    public class MQTTManager
    {

        private static MqttClient client;
        private static string clientID;

        /// <summary>
        /// Initialize MQTTManager
        /// </summary>
        public MQTTManager()
        {
            //
        }

        /// <summary>
        /// Initialize MQTTManager
        /// </summary>
        public MQTTManager(string address)
        {
            client = new MqttClient(address);
        }

        /// <summary>
        /// Create Connection to MQTT Server
        /// </summary>
        /// <param name="address"></param>
        public void CreateConnection(string address)
        {
            client = new MqttClient(address);
        }

        /// <summary>
        /// The Client will join the Channel
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void ClientJoinChannel(string channelID, string username, string password)
        {
            client.Connect(channelID, username, password);
        }

        /// <summary>
        /// The Client will disconnect
        /// </summary>
        public void ClientLeaveChannel()
        {
            client.Disconnect();
        }

        /// <summary>
        /// Client send Message to Channel
        /// </summary>
        /// <param name="channelID"></param>
        /// <param name="content"></param>
        public void ClientSendMessage(string channelID, string content)
        {
            try
            {
                client.Publish(channelID, Encoding.UTF8.GetBytes(content), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            }
            catch (Exception)
            {
                throw new Exception("Client is not connected to Channel");
            }
        }

        //
        public void ClientSubscribeChannel()
        {

        }

        //
        public void ClientUnSubscribeChannel()
        {

        }



        /// <summary>
        /// Create random Client ID
        /// </summary>
        /// <returns></returns>
        public string RandomClientID()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
