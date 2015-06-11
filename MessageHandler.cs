using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Anteater
{
    public static class MessageTypes
    {
        public static string[] availableMsgTypes()
        {
            var streamData = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var mtRes = "anteater.messageTypes.txt";
            using (Stream stream = assembly.GetManifestResourceStream(mtRes))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    streamData.Add(line);
                }
            }
            string[] streamDataFinal = streamData.ToArray();
            return streamDataFinal;
        }
        public static string msgType(string msg, string[] msgTypes)
        {
            string message = msg;
            string[] messageTypes = msgTypes;
            return message;
        }
    }
    public static class Blah
    {
        public static string Type(string msg, string[] msgTypes)
        {
            string message = msg;
            return message;
        }
    }
}
