using System;
using System.Linq;


// https://ru.stackoverflow.com/questions/314289/%D0%A0%D0%B5%D0%B3%D1%83%D0%BB%D1%8F%D1%80%D0%BD%D1%8B%D0%B5-%D0%B2%D1%8B%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%BA%D0%B0%D0%BA-%D0%B8%D0%B7%D0%B2%D0%BB%D0%B5%D1%87%D1%8C-%D0%BF%D0%BE%D0%B4%D1%81%D1%82%D1%80%D0%BE%D0%BA%D1%83

namespace ECMonitoring.Core.Devices
{
    internal class HttpAnalyzer
    {
        public delegate void HttpAnalyzeCompleteHandler(object sender, LanDeviceHttpStatus httpStatus);
        public event HttpAnalyzeCompleteHandler HttpAnalyzeCompleteOn;
        private object _syncObject;
        private int _httpErrorsCount;


        public HttpAnalyzer()
        {
            _syncObject = new object();
        }

        public void Dispose()
        {
            //
        }

        internal void Analyze(LanDeviceEventArgs e)
        {
            lock (_syncObject)
            {
                if (e.IsHttpPresent)
                {
                    string errorMessage;
                    var httpStatusCode = GetHttpStatus(e.HttpContent.HttpHeader, out errorMessage);

                    if (httpStatusCode != 200)
                    {
                        _httpErrorsCount++;
                        var httpStatus =
                            new LanDeviceHttpStatus(e.DstIp, ServerHttpResponseStatus.Error,
                            "methodServiceSignature", errorMessage,
                            httpStatusCode, _httpErrorsCount);
                        HttpAnalyzeCompleteOn?.BeginInvoke(this, httpStatus, null, null);
                    }
                }
            }
        }

        private int GetHttpStatus(string httpHeader, out string errorMessage)
        {
            errorMessage = string.Empty;
            var errorCode = 200;
            var firstRow = httpHeader.Split('\n')[0].Split(' ');
            if (firstRow[1] != "200")
            {
                errorCode = Convert.ToInt32(firstRow[1]);
                errorMessage = string.Join(" ", firstRow.Skip(2)).Trim('\r').Trim('\n');
            }
            return errorCode;
        }
    }
}
