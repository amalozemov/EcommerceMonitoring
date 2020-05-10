using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SharpPcap;

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
                    var pattern = ".+(OK|ERROR)";
                    Match match = Regex.Match(e.HttpContent.HttpHeader, pattern);
                    var partHttpHeader = match.ToString().Split(' ');

                    if (partHttpHeader[2] == "ERROR")
                    {
                        _httpErrorsCount++;
                        var httpStatus =
                            new LanDeviceHttpStatus(e.DstIp, ServerHttpResponseStatus.Error, 
                            "methodServiceSignature", "Тестовое описание ошибки HTTP", 
                            partHttpHeader[1], _httpErrorsCount);
                        HttpAnalyzeCompleteOn?.BeginInvoke(this, httpStatus, null, null);
                    }
                }
            }
        }


    }
}
