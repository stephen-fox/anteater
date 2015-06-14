using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Anteater
{
    public static class ResourceReader
    {
        // Return an array of strings from the specified resource file.
        public static string[] readResources(string resFilename)
        {
            var streamData = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            resFilename = "Anteater." + resFilename;
            using (Stream stream = assembly.GetManifestResourceStream(resFilename))
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
    }

    public static class MessageInfo
    {
        // Return an array of available message types.
        public static string[] getMsgTypes()
        {
            string resFilename = "messageTypes.txt";
            string[] msgTypes = ResourceReader.readResources(resFilename);
            return msgTypes;
        }

        // Return a string containing the message's type.
        public static string setMsgType(string msg, string[] msgTypes)
        {
            string type = null;
            if (msgTypes != null)
            {
                foreach (string s in msgTypes)
                {
                    if (msg.Contains(s))
                    {
                        type = s;
                        return type;
                    }
                }
            }
            return type;
        }

        //
        public static string[] getImportantMsgs()
        {
            string resFilename = "stringsOfInterest.txt";
            string[] importantMsgs = ResourceReader.readResources(resFilename);
            return importantMsgs;
        }

        //
        public static bool isImportant(string msg, string[] importantMsgs)
        {
            if (importantMsgs != null)
            {
                foreach (string s in importantMsgs)
                {
                    if (msg.Contains(s))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
