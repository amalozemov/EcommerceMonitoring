using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
//using GMCS.CrmCore.Domain.Repository;
//using GMCS.CrmCore.Domain.Service;
//using GMCS.CrmCore.Domain.UnitOfWork;
//using GMCS.CrmCore.Logger;
//using GMCS.CrmCore.Logger.Soap;
//using GMCS.CrmCore.XRM.Domain.IntegrationBus;

namespace GMCS.MTT.XRM.Application.Services.Common
{
    public class WcfServiceBase : IServiceBehavior
    {
        public WcfServiceBase() { }
        //public WcfServiceBase(ILogger logger, IUnitOfWorkFactory unitOfWorkFactory, ICommonRepository commonRepository,
        //    ICrmMetadataService metadataService)
        //{
        //    this.UnitOfWorkFactory = unitOfWorkFactory;
        //    this.CommonRepository = commonRepository;
        //    this.MetadataService = metadataService;
        //    this.Logger = logger;
        //}

        //public WcfServiceBase(ILogger logger, IUnitOfWorkFactory unitOfWorkFactory, ICommonRepository commonRepository,
        //    ICrmMetadataService metadataService, IBus bus) : this(logger, unitOfWorkFactory, commonRepository, metadataService)
        //{
        //    this.Bus = bus;
        //}

        //protected ILogger Logger { get; set; }
        //protected IUnitOfWorkFactory UnitOfWorkFactory { get; set; }
        //protected ICommonRepository CommonRepository { get; set; }
        //protected ICrmMetadataService MetadataService { get; set; }
        //protected IBus Bus { get; set; }

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            //return;
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                    epDisp.DispatchRuntime.MessageInspectors.Add(new Api.Common.ApiWcfServerActivityLogger(this.GetType(), null, null));
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            return;
        }
    }
}