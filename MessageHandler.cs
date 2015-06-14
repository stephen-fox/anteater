using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

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

    public static class Message
    {
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

        // Return true if the message is interesting.
        public static bool isInteresting(string msg, string[] interestingMsgs)
        {
            if (interestingMsgs != null)
            {
                foreach (string s in interestingMsgs)
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

    public static class MessageInfo
    {
        // Return an array of available message types.
        public static string[] getMsgTypes()
        {
            StringCollection mtSettings = 
                Properties.Settings.Default.messageTypes;
            string [] msgTypes = new string[mtSettings.Count];
            mtSettings.CopyTo( msgTypes,0 );
            return msgTypes;
        }

        // Returns an array of interesting strings.
        public static string[] getInterestingMsgs()
        {
            StringCollection intStrsSettings = 
                Properties.Settings.Default.interestingStrings;
            string[] interestingMsgs = new string[intStrsSettings.Count];
            intStrsSettings.CopyTo(interestingMsgs, 0);
            return interestingMsgs;
        }
    }
}
