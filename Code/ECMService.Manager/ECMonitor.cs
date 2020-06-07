using ECMService.Manager.DTO;
using ECMService.Manager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Manager
{
    public enum ResultOperation
    {
        NoChange,
        Success
    }

    public class ECMonitor : IDisposable
    {
        ConnectorsClient _clientService;
        IDictionary<int, EndPointDataDTO> _endPointsCashe;
        object _syncObject;

        public ECMonitor()
        {
            _clientService = new ConnectorsClient("BasicHttpBinding_IConnectors");
            _endPointsCashe = new Dictionary<int, EndPointDataDTO>();
            _syncObject = new object();
        }

        public void Dispose()
        {
            try
            {
                _clientService.Close();
                _clientService = null;
                lock (_syncObject)
                {
                    _endPointsCashe.Clear();
                }
            }
            catch { }
        }

        public ResultOperation GetDataByEndPointId(int endPointId, out EndPointDataDTO endPointData)
        {
            var res = ResultOperation.Success;
            var data = _clientService.GetDataByEndPointId(endPointId);
            endPointData = new EndPointDataDTO()
            {
                HttpErrorsCount = data.HttpErrorsCount,
                StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
            };

            lock (_syncObject)
            {
                if (!_endPointsCashe.ContainsKey(endPointId))
                {
                    _endPointsCashe.Add(endPointId, endPointData);
                }
                else
                {
                    var prvEndPointData = _endPointsCashe[endPointId];
                    if (endPointData.Equals(prvEndPointData))
                    {
                        return ResultOperation.NoChange;
                    }
                    else
                    {
                        _endPointsCashe[endPointId] = endPointData;
                    }
                }
            }

            // тут 07.06.2020 делать универсальную коллекцию (словарь) для хранеия данных разного типа с временем записи их в коллекцию как класс DataContainer
            // или делать две коллекции 1 - для конечных точкек 2 - для сервисов и переменная содержащая коллекцию всех данных.

            // решение коллекции 2 - словарь вида Dictionary<int,  DataContainer<EndPointDataDTO>>, вторая Dictionary<int,  DataContainer<ServiceDataDTO>>
            // ипеременная типа DataContainer<ECMonitorDataDTO>

            var t = new DataContainer<EndPointDataDTO>();

            var t1 = t.DataObject;


            return res;
        }
    }
}
