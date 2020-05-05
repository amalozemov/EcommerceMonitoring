using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBaseService;

namespace ECMService.Core
{
    public class ClientService
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public bool IsConnectes { get; private set; }

        //List<ClientEndPoint> _clientEndPoints;

        //public ClientService()
        //{
        //    _clientEndPoints = new List<ClientEndPoint>();
        //}

        //public void Start()
        //{
        //    foreach (var ep in _clientEndPoints)
        //    {
        //        ep.Start();
        //    }
        //    IsConnectes = true;
        //}

        //public void Stop()
        //{
        //    foreach (var ep in _clientEndPoints)
        //    {
        //        ep.Stop();
        //    }
        //    IsConnectes = false;
        //}

        //public void CreateEndPoints(IRepository repository)
        //{
        //    var datas = repository.GetEndPoints(Id);

        //    foreach (var data in datas)
        //    {
        //        var ep = new ClientEndPoint()
        //        {
        //            Ip = data.Ip,
        //            Port = data.Port
        //        };

        //        _clientEndPoints.Add(ep);
        //    }
        //}
    }
}
