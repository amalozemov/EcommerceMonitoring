using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using System.Xml;
//using GMCS.CrmCore.Logger;
//using GMCS.CrmCore.Logger.Soap;

namespace GMCS.MTT.XRM.Application.Api.Common
{
    public class ApiWcfServerActivityLogger : IDispatchMessageInspector
    {
        //private readonly ILogger logger;
        private Dictionary<string, string> HttpHeaderParams { get; set; }
        private IEnumerable<SoapHeader> SoapHeaderParams { get; set; }

        //private ActivityLogData logData;
        //private ActivityLogData ActivityLogData
        //{
        //    get
        //    {
        //        if (logData != null) return logData;
        //        logData = new ActivityLogData();
        //        return logData;
        //    }
        //    set
        //    {
        //        logData = value;
        //    }
        //}

        public ApiWcfServerActivityLogger(Type wcfServiceType, Dictionary<string, string> httpHeaderParams, IEnumerable<SoapHeader> soapHeaderParams)
        {
            //ActivityLogData = new ActivityLogData();
            //var loggerFactory = new NLogLoggerFactory();
            //logger = loggerFactory.GetLogger("XrmApi");//loggerFactory.GetLogger(wcfServiceType);
            HttpHeaderParams = httpHeaderParams;
            SoapHeaderParams = soapHeaderParams;
        }



        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //ActivityLogData.StartTime = DateTime.Now;
            //ActivityLogData.MethodName = request.Properties.Via.AbsolutePath;//request.Headers.Action.Substring(request.Headers.Action.LastIndexOf("/") + 1);
            //ActivityLogData.RequestSoap = request.ToString();
            //ActivityLogData.EndedInError = request.IsFault;
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (HttpHeaderParams != null)
            {
                HttpResponseMessageProperty httpResponseMessage;
                object httpRequestMessageObject;
                if (reply.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
                {
                    httpResponseMessage = httpRequestMessageObject as HttpResponseMessageProperty;
                    foreach (KeyValuePair<string, string> item in HttpHeaderParams)
                    {
                        if (item.Value != null)
                            httpResponseMessage.Headers.Add(item.Key, Uri.EscapeDataString(item.Value));
                    }
                }
                else
                {
                    httpResponseMessage = new HttpResponseMessageProperty();
                    foreach (KeyValuePair<string, string> item in HttpHeaderParams)
                    {
                        if (item.Value != null)
                            httpResponseMessage.Headers[item.Key] = Uri.EscapeDataString(item.Value);
                    }
                    reply.Properties.Add(HttpResponseMessageProperty.Name, httpResponseMessage);
                }
            }
            //if (ActivityLogData == null)
            //    return;
            //ActivityLogData.RequestHttpHeaders = HttpHeaderParams;
            //ActivityLogData.EndTime = DateTime.Now;
            //ActivityLogData.ResponseSoap = MessageToString(ref reply);//reply.ToString();
            //ActivityLogData.EndedInError = reply.IsFault;
            //if (reply.IsFault)
            //{
            //    logger.Error(ActivityLogDataFormatter.Format(ActivityLogData));
            //}
            //else
            //{
            //    logger.Info(ActivityLogDataFormatter.Format(ActivityLogData));
            //}
            //ActivityLogData = null;
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat;
                bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        private string MessageToString(ref Message message)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            // copy the message into a working buffer.
            MessageBuffer buffer = message.CreateBufferedCopy(int.MaxValue);

            // re-create the original message, because "copy" changes its state.
            message = buffer.CreateMessage();

            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately 
                    return this.ReadRawBody(ref message);
            }

            buffer.CreateMessage().WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());
            return messageBody;
        }

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message 
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
    }
}